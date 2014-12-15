using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    private UiManager ui;

    public GameObject cardHolderObject;
    private CardHolder cardHolder;

    private PhotonView photonView;

    private Player player;
    private Player opponent;

    private bool attackCanceled;
    public static bool gameOver;
    private bool disconnected;

    void Start()
    {
        gameOver = false;
        disconnected = false;
        photonView = GetComponent<PhotonView>();
        cardHolder = cardHolderObject.GetComponent<CardHolder>();
        ui = GetComponent<UiManager>();

        Application.ExternalCall("OnBattleLoad");

        // init players ==============================================
        string name = PlayerPrefs.GetString("playerName");
        player = new Player(name, 100);
        opponent = new Player("@QI", 100);
        photonView.RPC("SetOpponentName", PhotonTargets.Others, name);
        // ===========================================================
    }

    void Update()
    {
        if (!IsGameOver())
        {   // if there is no CountDown
            if (!ui.CountDown())
            {     // checks game over
                IsGameOver();
                if (cardHolder.IsReleaseOver())
                {   // if the release animation is over
                    if (!cardHolder.IsCanceled())
                    {   // & attack is not canceled: deal damage
                        int damage = cardHolder.TotalDamage();
                        opponent.UpdateHealth(damage);
                        photonView.RPC("UpdateHealth", PhotonTargets.Others, damage);
                        ui.UpdateOpponentHealthBar(opponent.GetHealth());
                    }
                    // init cardholder with a card
                    cardHolder.Init();
                    ui.NewTagCloud();
                }

                // if some card is active
                if (cardHolder.IsInputReady())
                {   // listen to input
                    InputListener.Listen(true);
                    if (Input.GetKeyDown("return") && cardHolder.IsReleaseReady())
                    {
                        InputListener.Listen(false);
                        StartCoroutine(QueryManager.QueryDamageDistribution(InputListener.GetInput(), OnResponce));
                        ui.RemoveTagCloud();
                    }
                }
                else
                {   // Cancel or Release attack
                    cardHolder.HandleAttack();
                }
            }
        }
        else
        {
            gameOver = true;
            if (!disconnected)
            {
                photonView.RPC("GameOver", PhotonTargets.All);
            }
            else
            {
                if (ui.ExitGame() || ui.Concede())
                {
                    Application.LoadLevel("MainMenu");
                }
            }
        }
    }

    public bool IsGameOver()
    {
        // forced by other player (concede)
        if (gameOver) return true;

        if (!ui.Concede())
        {  
            if (player.GetHealth() <= 0)
            {
                ui.DisplayGameOver("defeat");
                return true;
            }
            else if (opponent.GetHealth() <= 0)
            {
                ui.DisplayGameOver("victory");
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {   // if the player concedes, display victory for opponent
            photonView.RPC("DisplayVictory", PhotonTargets.Others);
            return true;
        }
        
    }

    [RPC]
    private void DisplayVictory()
    {
        ui.DisplayGameOver("victory");
        disconnected = true;
        gameOver = true;
    }

    [RPC]
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.1f);
        NetworkManager.Disconnect();
        disconnected = true;
    }

    [RPC]
    private void UpdateHealth(int damage)
    {
        player.UpdateHealth(damage);
        ui.UpdatePlayerHealthBar(player.GetHealth());
    }

    [RPC]
    private void SetOpponentName(string name)
    {
        opponent.SetName(name);
    }

    // ================================================================================
    /* this function is passed in QueryDamageDistribution 
     * it gets executed when we get a responce */
    private void RequestImage(string url)
    {
        StartCoroutine(QueryManager.QueryImage(true, url, SetImages));
        photonView.RPC("RequestEnemyImage", PhotonTargets.Others, url);
    }

    [RPC]
    private void RequestEnemyImage(string url)
    {
        StartCoroutine(QueryManager.QueryImage(false, url, SetEnemyImage));
    }

    private void SetImages()
    {
        ui.InitPlayerNames(player.GetName(), opponent.GetName());
        ui.SetProfilePic(QueryManager.GetProfilePic());
    }

    private void SetEnemyImage()
    {
        ui.SetEnemyPic(QueryManager.GetEnemyPic());
    }

    private void OnResponce()
    {
        cardHolder.LaunchCard(InputListener.GetInput(), QueryManager.GetDistribution());
        // cardholder is no longer input ready
        Debug.Log("CHARGING ATTACK");
    }
    // ================================================================================
}

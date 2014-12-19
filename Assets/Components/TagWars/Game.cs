using UnityEngine;
using System.Collections;

/* Game Class:
 * the main class of TagWars, contains the main game loop
 * as well as a few other helper methods */

public class Game : MonoBehaviour
{
    private UiManager ui;

    public GameObject cardHolderObject;
    private CardHolder cardHolder;

    private PhotonView photonView;

    private Player player;
    private Player opponent;

    private bool attackCanceled;
    private bool disconnected;

    public static bool gameOver { get; private set; }

    void Start()
    {
        Application.ExternalCall("OnBattleLoad");

        gameOver = false;
        disconnected = false;
        photonView = GetComponent<PhotonView>();
        cardHolder = cardHolderObject.GetComponent<CardHolder>();
        ui = GetComponent<UiManager>();

       // init players ==============================================
        string name = PlayerPrefs.GetString("playerName");
        player = new Player(name, 100);
        opponent = new Player("@QI", 100);
        photonView.RPC("SetOpponentName", PhotonTargets.Others, name);
        // ===========================================================

        StartCoroutine(QueryManager.QueryValidTag());
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
                        player.lastDamage = damage;
                        ui.UpdateOpponentHealthBar(opponent.health);
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
                        string newTag = InputListener.GetInput();
                        if (player.lastTag == "") player.lastTag = "nothing_here";
                        StartCoroutine(QueryManager.QueryDamageDistribution(newTag, player.lastTag, player.lastDamage, OnResponce));
                        ui.RemoveTagCloud();
                        player.lastTag = newTag;
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
                if (ui.ExitGame() || ui.concede)
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

        if (!ui.concede)
        {  
            if (player.health <= 0)
            {
                ui.DisplayGameOver("defeat");
                return true;
            }
            else if (opponent.health <= 0)
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
        ui.UpdatePlayerHealthBar(player.health);
    }

    [RPC]
    private void SetOpponentName(string name)
    {
        opponent.name = name;
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
        ui.InitPlayerNames(player.name, opponent.name);
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

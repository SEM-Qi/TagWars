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

    void Start()
    {
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
        if (!GameOver())
        {   // if there is no CountDown
            if (!ui.CountDown())
            {     // checks game over
                GameOver();
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
            if (ui.ExitGame())
            {
                NetworkManager.Disconnect();
                Application.LoadLevel("MainMenu");
            }
        }
    }

    private bool GameOver()
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

using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    private UiManager ui;

    public GameObject cardHolderObject;
    private CardHolder cardHolder;

    private PhotonView photonView;

    // no MonoBehaviour
    private Player player;
    private Player opponent;

    private bool attackCanceled;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        cardHolder = cardHolderObject.GetComponent<CardHolder>();
        ui = GetComponent<UiManager>();

        // init players
        player = new Player("@aure", 100);
        opponent = new Player("@evil_aure", 100);

        // Updates the player name on UI
        ui.InitPlayerNames(player.GetName(), opponent.GetName());
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

    // ================================================================================
    /* this function is passed in QueryDamageDistribution 
     * it gets executed when we get a responce */
    private void OnResponce()
    {
        cardHolder.LaunchCard(InputListener.GetInput(), QueryManager.GetDistribution());
        // cardholder is no longer input ready
        Debug.Log("CHARGING ATTACK");
    }
    // ================================================================================
}

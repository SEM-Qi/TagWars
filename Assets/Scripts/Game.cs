using System.Collections;
using UnityEngine;

/* Game Class contains the main loop */

public class Game : MonoBehaviour
{
    private UIManager uiManager;
    private InputListener inputListener;
    private QueryManager queryManager;
    private Attack attack;
    private Controller controller;
    private PhotonView photonView;
    private CoolDown coolDown;
    
    // no MonoBehaviour
    private Player player;
    private Player opponent;

    // loop control values
    private bool gameOver = false;
    private bool inputField = false;
    private bool attackLaunched = false;

    void Start()
    {
        uiManager = GetComponent<UIManager>();
        inputListener = GetComponent<InputListener>();
        queryManager = GetComponent<QueryManager>();
        attack = GetComponent<Attack>();
        controller = GetComponent<Controller>();
        photonView = GetComponent<PhotonView>();
        coolDown = GetComponent<CoolDown>();

        // init players
        player = new Player("Aure", 100);
        opponent = new Player("Evil Aure", 100);

        // Updates the player name on UI
        uiManager.InitPlayerNames(player.GetName(), opponent.GetName());
    }

    void Update()
    {
        if (!gameOver)
        {
            if (controller.TimerOver())
            {   // if the timer is done
                CheckGameOver();
                if (!inputField)
                {   // if there is no inputfield
                    NewInputField();
                    inputField = true;
                }
                else
                {
                    if (Input.GetKeyDown("return") && !attackLaunched)
                    {
                        if (inputListener.IsValid())
                        {
                            NewAttack();
                            attackLaunched = true;
                        }
                    }
                    else if (Input.GetKeyUp("return") && attackLaunched)
                    {
                        ReleaseAttack();
                        Debug.Log(attack.GetStrength());
                        coolDown.AddCoolDown(inputListener.GetInput(), attack.GetStrength());
                    }
                }
            }
        }
    }

    private void CheckGameOver()
    {
        if (player.GetHealth() <= 0)
        {
            gameOver = true;
            uiManager.DisplayGameOver("defeat");
        }
        else if (opponent.GetHealth() <= 0)
        {
            gameOver = true;
            uiManager.DisplayGameOver("victory");
        }
        else
        {
            gameOver = false;
        }
    }

    private void NewInputField()
    {
        uiManager.NewInputField();
        inputListener.ResetInput();
        inputListener.SetInputReady(true);
    }

    private void NewAttack()
    {
        inputListener.SetInputReady(false);
        SynchronizeNewAttackAnim();         // Synchronization
        StartCoroutine(queryManager.QueryDamageDistribution(inputListener.GetInput().Substring(1), OnResponce));
        Debug.Log("LAUNCH ATTACK");
    }

    // ================================================================================
    /* this function is passed in QueryDamageDistribution 
     * it gets executed when we get a responce */
    private void OnResponce()
    {
        attack.Init(queryManager.GetDistribution());
        attack.UpdateDamage();

        /* ensures that the CancelDamageUpdate()
         * is called even if the enter key is 
         * released before the responce happens */

        if (!Input.GetKey("return")){ attack.CancelDamageUpdate(); }

        Debug.Log("CHARGE ATTACK");
    }
    // ================================================================================

    private void ReleaseAttack()
    {
        SynchronizeAttackReleaseAnim();     // Synchronization
        attack.CancelDamageUpdate();
        Debug.Log("RELEASE ATTACK");
    }

    // when the release animation ends
    public void AfterRelease()
    {
        SynchronizeDamage();                // Synchronization
        inputField = false;
        attackLaunched = false;

        // ui update
        uiManager.UpdateOpponentHealthBar(opponent.GetHealth());
    }

    // Synchronization =================================================================
    public void SynchronizeNewAttackAnim() 
    {
        uiManager.NewAttackAnim();
        photonView.RPC("PlayEnemyAttack", PhotonTargets.Others, inputListener.GetInput()); 
    }

    public void SynchronizeAttackReleaseAnim() 
    {
        uiManager.ReleaseAttackAnim();
        photonView.RPC("ReleaseEnemyAttack", PhotonTargets.Others); 
    }

    public void SynchronizeDamage()
    {
        int damage = attack.GetDamage();
        attack.DealDamage(opponent, damage); 
        photonView.RPC("DealDamage", PhotonTargets.Others, damage);                             
    }
    
    [RPC]
    public void PlayEnemyAttack(string input) { uiManager.PlayEnemyAttackAnim(input); }

    [RPC]
    public void ReleaseEnemyAttack() { uiManager.ReleaseEnemyAttackAnim(); }

    [RPC]
    public void DealDamage(int damage) 
    { 
        attack.DealDamage(player, damage);
        uiManager.UpdatePlayerHealthBar(player.GetHealth());
    }
    // ==================================================================================
}

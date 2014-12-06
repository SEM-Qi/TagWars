using System.Collections;
using UnityEngine;

/* Game Class contains the main loop */

public class Game : MonoBehaviour
{
    public GameObject queryManagerObject;
    private QueryManager queryManager;

    public GameObject coolDownManagerObject;
    private CoolDown coolDown;

    private InputListener inputListener;
    
    private Attack attack;
    private PhotonView photonView;
    private NewuiManager newuiManager;

    // no MonoBehaviour
    private Player player;
    private Player opponent;

    // loop control values
    private bool gameOver = false;
    private bool inputField = false;
    private bool attackLaunched = false;

    void Start()
    {
        newuiManager = GetComponent<NewuiManager>();
        inputListener = GetComponent<InputListener>();
        queryManager = queryManagerObject.GetComponent<QueryManager>();
        attack = GetComponent<Attack>();
        photonView = GetComponent<PhotonView>();
        coolDown = coolDownManagerObject.GetComponent<CoolDown>();

        // init players
        player = new Player("@Aure", 100);
        opponent = new Player("@Evil Aure", 100);

        // Updates the player name on UI
        newuiManager.InitPlayerNames(player.GetName(), opponent.GetName());
    }

    void Update()
    {
        if (!gameOver)
        {
            if (newuiManager.TimerOver())
            {   // if the timer is done
                CheckGameOver();
                if (!inputField)
                {   // if there is no inputfield
                    newuiManager.InitOpponentCard();
                    newuiManager.NewCardHolder();
                    inputField = true;
                }
                else
                {
                    if (Input.GetKeyDown("return") && !attackLaunched)
                    {
                        if (newuiManager.IsReleaseReady())
                        {   // compare the current attacks
                            NewAttack();
                        }
                    }
                    else if (!Input.GetKey("return") && attackLaunched)
                    {
                        if (player.GetAttack() != "" && player.GetAttack() == opponent.GetAttack())
                        {
                            SynchronizeCancelAttack();
                        }
                        else
                        {
                            ReleaseAttack();
                        }
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
            newuiManager.DisplayGameOver("defeat");
        }
        else if (opponent.GetHealth() <= 0)
        {
            gameOver = true;
            newuiManager.DisplayGameOver("victory");
        }
        else
        {
            gameOver = false;
        }
    }

    private void NewAttack()
    {
        newuiManager.LaunchAttack();
        SynchronizeNewAttackAnim();         // Synchronization
        player.SetAttack(inputListener.GetInput());
        StartCoroutine(queryManager.QueryDamageDistribution(inputListener.GetInput(), OnResponce));
        Debug.Log("LAUNCH ATTACK");
    }

    // ================================================================================
    /* this function is passed in QueryDamageDistribution 
     * it gets executed when we get a responce */
    private void OnResponce()
    {
        attack.Init(queryManager.GetDistribution());
        attack.UpdateDamage();
        attackLaunched = true;
        Debug.Log("CHARGE ATTACK");
    }
    // ================================================================================

    private void ReleaseAttack()
    {
        attack.CancelDamageUpdate();
        SynchronizeAttackReleaseAnim();     // Synchronization
        attackLaunched = false;
        Debug.Log("RELEASE ATTACK");
    }

    // when the release animation ends
    public void AfterRelease()
    {
        SynchronizeDamage();                // Synchronization
        inputField = false;
       
        // ui update
        newuiManager.UpdateOpponentHealthBar(opponent.GetHealth());

        // we should make sure we got a responce first:
        coolDown.AddCoolDown(inputListener.GetInput(), attack.GetStrength());
        newuiManager.AddCoolDownBar(inputListener.GetInput(), attack.GetStrength());
    }

    [RPC]
    public void CancelAttack()
    {
        // Add damage reflection code 
        newuiManager.CancelAttackAnim();
        inputField = false;
        attackLaunched = false;
        Debug.Log("CANCEL ATTACK");
        attack.CancelDamageUpdate();
        player.SetAttack("");
        opponent.SetAttack("");

        coolDown.AddCoolDown(inputListener.GetInput(), attack.GetStrength());
        newuiManager.AddCoolDownBar(inputListener.GetInput(), attack.GetStrength());
    }

    // Synchronization =================================================================
    public void SynchronizeNewAttackAnim()
    {
        photonView.RPC("PlayEnemyAttack", PhotonTargets.Others, inputListener.GetInput());
    }

    public void SynchronizeAttackReleaseAnim()
    {
        newuiManager.ReleaseAttack();
        photonView.RPC("ReleaseEnemyAttack", PhotonTargets.Others);
    }

    public void SynchronizeDamage()
    {
        int damage = attack.GetDamage();
        attack.DealDamage(opponent, damage);
        photonView.RPC("DealDamage", PhotonTargets.Others, damage);
    }

    public void SynchronizeCancelAttack()
    {
        photonView.RPC("CancelAttack", PhotonTargets.All);
    }

    [RPC]
    public void PlayEnemyAttack(string input)
    {
        newuiManager.PlayEnemyAttackAnim(input);
        opponent.SetAttack(input); // Cancel Attack functionality
    }

    [RPC]
    public void ReleaseEnemyAttack()
    {
        newuiManager.ReleaseEnemyAttackAnim();
        opponent.SetAttack("");
    }

    [RPC]
    public void DealDamage(int damage)
    {
        attack.DealDamage(player, damage);
        newuiManager.UpdatePlayerHealthBar(player.GetHealth());
    }

    // ==================================================================================
}

using System.Collections;
using UnityEngine;

/* Game Class contains the main loop */

public class Game : MonoBehaviour
{
    private Player player;
    private UIManager uiManager;
    private InputListener inputListener;
    private QueryManager queryManager;
    private Attack attack;
    private Controller controller;
    private PhotonView photonView;

    // loop control values
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
        player = GetComponent<Player>();

        // Updates the player name on UI
        uiManager.InitPlayerNames("Aure", "Evil Aure");
    }

    void Update()
    {
        if (controller.TimerOver())
        {   // if the timer is done
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
                }
            }
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
        uiManager.NewAttackAnim();
        SynchronizeNewAttackAnim();     // Synchronization
        inputListener.SetInputReady(false);
        StartCoroutine(queryManager.QueryDamageDistribution(inputListener.GetInput().Substring(1), OnResponce));
        Debug.Log("LAUNCH ATTACK");
    }

    private void OnResponce()
    {
        attack.Init(queryManager.GetDistribution());

        // charge attack
        attack.UpdateDamage();

        /* ensures that the Invoke is cancelled 
         * if the enter key is released before 
         * the responce happens */

        if (!Input.GetKey("return"))
        {
            attack.CancelDamageUpdate();
        }

        Debug.Log("CHARGE ATTACK");
    }

    private void ReleaseAttack()
    {
        uiManager.ReleaseAttackAnim();
        SynchronizeAttackReleaseAnim(); // Synchronization
        attack.CancelDamageUpdate();
        Debug.Log("RELEASE ATTACK");
    }

    // TODO these methods might not belong here
    // Cross Player Communication -------------------------------------------
    public void SynchronizeNewAttackAnim() { photonView.RPC("PlayEnemyAttack", PhotonTargets.Others, inputListener.GetInput()); }

    public void SynchronizeAttackReleaseAnim() { photonView.RPC("ReleaseEnemyAttack", PhotonTargets.Others); }

    public void SynchronizeDamage() { photonView.RPC("DealDamage", PhotonTargets.Others, attack.GetDamage()); }

    [RPC]
    public void PlayEnemyAttack(string input) { uiManager.PlayEnemyAttackAnim(input); }

    [RPC]
    public void ReleaseEnemyAttack() { uiManager.ReleaseEnemyAttackAnim(); }

    [RPC]
    public void DealDamage(int damage)
    {
        attack.DealDamage(damage);
        uiManager.UpdatePlayerHealthBar(player.GetHealth());
    }
    // ----------------------------------------------------------------------

    // when the release animation ends
    public void OnAnimationEnd()
    {
        SynchronizeDamage();    // Synchronization
        uiManager.UpdateOpponentHealthBar(attack.GetDamage()); // Code Smell
        attack.SetDamage(0);
        inputField = false;
        attackLaunched = false;
    }
}

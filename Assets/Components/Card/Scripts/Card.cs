using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{

    private string enemyTag;
    private string cardTag;
    private int[] distribution;
    private int damage;
    private int chargeTime;
    private int strength;

    /* can't block if the enemy has released 
     * the attack or if you have already 
     * released the attack */

    private bool enemyRelease = false;
    private bool released = false;
    private bool canceled = false;
    private bool releaseOver = true;

    private CardUI cardUI;
    private PhotonView photonView;

    public GameObject enemyCardObject;
    private EnemyCard enemyCard;

    void Start()
    {
        enemyCard = enemyCardObject.GetComponent<EnemyCard>();
        cardUI = GetComponent<CardUI>();
        photonView = GetComponent<PhotonView>();
    }

    public void Init()
    {
        released = false;
        canceled = false;
        this.releaseOver = false;
        this.cardTag = "";
        this.enemyTag = "";
        this.damage = 0;
        this.chargeTime = 0;
        photonView.RPC("InitEnemyCard", PhotonTargets.Others);
    }

    public void Launch(string tag, int[] distribution)
    {
        this.cardTag = tag;
        this.distribution = distribution;
        this.strength = CalculateStrength();

        cardUI.Launch();
        photonView.RPC("EnemyLaunch", PhotonTargets.Others, cardTag);
        InvokeRepeating("UpdateDamage", 0, 1F); // Update Damage every second
    }

    public void Attack()
    {   // if the player hasn't released the attack yet
        if (!released)
        {
            if (cardTag != "" && cardTag == enemyTag && !enemyRelease)
            {   // Cancel Attack if the enemy hasn't released his attack yet
                Sync("Cancel");
            }
            else
            {
                if (!Input.GetKey("return"))
                {   // Release Attack
                    CancelInvoke();
                    cardUI.Release();
                    released = true;
                    photonView.RPC("EnemyRelease", PhotonTargets.Others);
                }
            }
        }
    }

    private void UpdateDamage()
    {
        if (chargeTime < distribution.Length)
        {   // deal at least some damage
            if (chargeTime == 0 && distribution[chargeTime] == 0)
            {
                damage += (strength / 20) + 1;
            }
            damage += distribution[chargeTime] * 2;
            chargeTime++;

            cardUI.Resize(damage);
            Debug.Log(damage);
        }
        else
        {
            CancelInvoke();
        }
    }

    private int CalculateStrength()
    {
        int strength = 1;

        for (int i = 0; i < distribution.Length; i++)
        {
            strength = strength + (distribution[i] * 2);
        }

        if (strength < 3) strength = 3;

        return strength;
    }

    public void Sync(string method)
    {
        photonView.RPC(method, PhotonTargets.All);
    }

    [RPC]
    private void Cancel()
    {
        CancelInvoke();
        cardUI.Cancel();
        enemyCard.Cancel();

        CoolDown.AddCoolDown(cardTag, strength);

        cardTag = "";
        enemyTag = "";
        releaseOver = true;
        canceled = true;
    }

    [RPC]
    private void InitEnemyCard()
    {
        enemyCard.Init();
        enemyRelease = false;
    }

    [RPC]
    private void EnemyLaunch(string tag)
    {
        enemyCard.Launch(tag);
        enemyTag = tag;
    }

    [RPC]
    private void EnemyRelease()
    {
        enemyRelease = true;
        enemyCard.Release();
        enemyTag = "";
    }

    public void AfterRelease()
    {
        releaseOver = true;
        CoolDown.AddCoolDown(cardTag, strength);
    }

    // Getters & Setters ======================================
    public int GetDamage() { return damage; }
    public bool ReleaseOver() { return releaseOver; }
    public string GetAttack() { return cardTag; }
    public string GetEnemyAttack() { return enemyTag; }
    public bool IsCanceled() { return canceled; }
    // ========================================================
}

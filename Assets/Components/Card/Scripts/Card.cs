using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

    private string enemyName;
    private string name;
    private int[] distribution;
    private int damage;
    private int chargeTime;
    private int strength;

    private bool releaseOver = true;

    private CardUI cardUI;
    private PhotonView photonView;

    public GameObject enemyCardObject;
    private EnemyCard enemyCard;

    // will be fixed when the cooldowns are fixed
    public GameObject scripts;
    private UiManager ui;

    void Start()
    {
        ui = scripts.GetComponent<UiManager>();

        enemyCard = enemyCardObject.GetComponent<EnemyCard>();
        cardUI = GetComponent<CardUI>();
        photonView = GetComponent<PhotonView>();
    }

    public void Init()
    {
        this.releaseOver = false;
        this.name = "";
        this.enemyName = "";
        this.damage = 0;
        this.chargeTime = 0;
        photonView.RPC("InitEnemyCard", PhotonTargets.Others);
    }

    public void Launch(string name, int[] distribution)
    {
        this.name = name;
        this.distribution = distribution;
        this.strength = CalculateStrength();

        cardUI.Launch();
        photonView.RPC("EnemyLaunch", PhotonTargets.Others, name);
        InvokeRepeating("UpdateDamage", 0, 1F); // Update Damage every second
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

        // cooldown system needs to be fixed
        CoolDown.AddCoolDown(name, strength);
        ui.AddCoolDownBar(name, strength);
        // -------------------------------

        name = "";
        enemyName = "";
        releaseOver = true;
    }

    [RPC]
    private void InitEnemyCard() { enemyCard.Init(); }

    [RPC]
    private void EnemyLaunch(string tag) 
    {
        enemyCard.Launch(tag);
        enemyName = tag;
    }

    [RPC]
    private void EnemyRelease() 
    {
        enemyCard.Release();
        enemyName = "";
    }

    public void Release()
    {
        CancelInvoke();
        cardUI.Release();

        photonView.RPC("EnemyRelease", PhotonTargets.Others);
    }

    public void AfterRelease()
    {
        releaseOver = true;
        CoolDown.AddCoolDown(name, strength);
        ui.AddCoolDownBar(name, strength);
    }

    // Getters & Setters ======================================
    public int GetDamage() { return damage; }
    public bool ReleaseOver() { return releaseOver; }
    public string GetAttack() { return name; }
    public string GetEnemyAttack() { return enemyName; }
    // ========================================================
}

using System.Collections;
using UnityEngine;

/* The ATTACK class updates and deals the damage */

public class Attack : MonoBehaviour
{
    private Player player;

    private string tag;
    private int chargeTime;
    private int damage;
    private int[] distribution;

    void Start()
    {
        player = GetComponent<Player>();
    }

    public void Init(int[] distribution)
    {
        for (int i = 0; i < distribution.Length; i++)
        {
            // Damage multiplier
            distribution[i] = distribution[i] * 5;
        }
        this.distribution = distribution;
        // resets the Damage when the Attack is initialized
        damage = 0;
    }

    // Damage Update ------------------
    public void UpdateDamage()
    {
        chargeTime = 0;
        InvokeRepeating("CalculateDamage", 1F, 1F);
    }

    private void CalculateDamage()
    {
        if (chargeTime < distribution.Length)
        {
            damage += distribution[chargeTime];
            chargeTime++;
            Debug.Log(damage);
        }
        else
        {
            CancelDamageUpdate();
        }
    }

    public void CancelDamageUpdate() { CancelInvoke(); }

    // Damage Dealing --------------------
    public void DealDamage(int damage)
    {
        player.SetHealth(player.GetHealth() - damage);
    }

    public void CancelAttack()
    {
        Debug.Log("attack canceled");
    }

    // Getters & Setters ----------------------
    public void SetDamage(int damage) { this.damage = damage; }

    public int GetDamage() { return damage; }
}

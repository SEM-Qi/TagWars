using System.Collections;
using UnityEngine;

/* The ATTACK class updates and deals the damage */

public class Attack : MonoBehaviour
{
    private int chargeTime;
    private int damage;
    private int[] distribution;

    public void Init(int[] distribution)
    {
        for (int i = 0; i < distribution.Length; i++)
        {   // Damage multiplier
            distribution[i] = distribution[i] * 2;
        }
        this.distribution = distribution;
        damage = 0; // resets the Damage when the Attack is initialized
    }

    // Damage Update ------------------
    public void UpdateDamage()
    {
        chargeTime = 0;
        CalculateDamage();
        InvokeRepeating("CalculateDamage", 1F, 1F);
    }

    private void CalculateDamage()
    {
        if (chargeTime < distribution.Length)
        {   // deal at least some damage
            // balancing =======================
            if (chargeTime == 0 && distribution[chargeTime] == 0) 
            {
                damage += (GetStrength() / 10) + 1;
            }
            // ==================================
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
    public void DealDamage(Player player, int damage)
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

    public int GetStrength()
    {
        int strength = 1;

        for (int i = 0; i < distribution.Length; i++)
        {
            strength = strength + (distribution[i]*2);
        }

        if (strength < 3) strength = 3;

        return strength;
    }
}

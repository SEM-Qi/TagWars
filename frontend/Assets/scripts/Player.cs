using System.Collections;
using UnityEngine;

/* The ANIM class is a wrapper for the Unity.Animator object
it stores all Animators in our project */

public class Player : MonoBehaviour
{
    private int health = 0;
    private string name = "none";
    private int id = 0;

    public Player(string name)
    {
        this.name = name;
    }

    void Update()
    {

    }

    public void Launch(Attack attack)
    {
        if (false)
        {
            Debug.Log("ATTACK CANCELED");
            attack.CancelAttack();
        }
        else
        {
            Debug.Log("ATTACK READY");
            Charge(attack);
        }
    }

    public Attack Charge(Attack attack)
    {
        Debug.Log("CHARGING ATTACK");
        attack.UpdateDamage(1);
        return attack;
    }

    public Attack Release(Attack attack)
    {
        Debug.Log("ATTACK RELEASED");
        return attack;
    }

    // GETTERS & SETTERS
    public string GetName()
    {
        return name;
    }

    public Tag[] GetInput()
    {
        return null;
    }
}

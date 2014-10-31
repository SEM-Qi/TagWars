using System.Collections;
using UnityEngine;

/* The ANIM class is a wrapper for the Unity.Animator object
it stores all Animators in our project */

public class Attack : MonoBehaviour
{
    private Tag[] tags;
    private int damage;
    
    private JSONParser jp;

    public Attack(Tag[] tags)
	{
        this.tags = tags;
        Debug.Log(tags);
	}

    void Awake()
    {
        jp = new JSONParser();
    }

    public void UpdateDamage(int second)
    {
        Debug.Log("updating damage at second: " + second);
    }

    public void DealDamage()
    {
        Debug.Log("dealing damage: " + damage);
    }

    public void CancelAttack()
    {
        Debug.Log("attack canceled");
    }
}

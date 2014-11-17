using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public GameObject healthbar;

    private int opponentHealth = 100; // CODE SMELL

	public void UpdateHealthBar (int health) 
    {
        healthbar.GetComponent("RectTransform").transform.localScale = new Vector3(1, Normalize(health), 1);
	}

    public void UpdateOpponentHealthBar(int damage)
    {
        opponentHealth = opponentHealth - damage;
        healthbar.GetComponent("RectTransform").transform.localScale = new Vector3(1, Normalize(opponentHealth), 1);
    }

    private float Normalize(int health)
    {
        float mappedHeath = health;
        mappedHeath = (((mappedHeath / 100) - 1) * -1);
        return mappedHeath;
    }
}

using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public GameObject healthbar;

	public void UpdateHealthBar (int health) 
    {
        healthbar.GetComponent("RectTransform").transform.localScale = new Vector3(1, Normalize(health), 1);
	}

    private float Normalize(int health)
    {
        float mappedHeath = health;
        mappedHeath = (((mappedHeath / 100) - 1) * -1);
        return mappedHeath;
    }
}

﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* CoolDownBar Class:
 * a coolDown element, with animation */

public class CoolDownBar : MonoBehaviour
{

    public GameObject bar;  // just the color
    public GameObject barContainer;
    public Text label;

    private float width = 1F;
    private float normalizedPercentage;

    private int coolDownID; // position ID

    public void Init(int id, string tag, int strength)
    {
        coolDownID = id;
        label.text = tag;
        normalizedPercentage = NormalizedPercentage(strength);
        
        InvokeRepeating("UpdateWidth", 0, 0.0125F); // 80X per sec
    }

    // to do replace with quaternion animation
    private void UpdateWidth()
    {
        if (width > 0F)
        {
            bar.GetComponent("RectTransform").transform.localScale = new Vector3(width, 1, 1);
            width = width - normalizedPercentage;
        }
        else
        {   // remove the cooldown
            Destroy(gameObject); 
        }
    }

    private float NormalizedPercentage(int val)
    {
        float normPercentage = (1.0F / (val * 82F));
        return normPercentage;
    }

    // Getters & Setters
    public int GetID() { return coolDownID; }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoolDownBar : MonoBehaviour {

    //private float Normalize(int strength)
    //{
    //    return strength / 100;
    //}

    public GameObject bar;  // just the color
    public GameObject barContainer;
    public Text label;

    private float width = 1F;
    private bool done = false;
    private float normalizedPercentage;

    public void Init(string tag, int strength)
    {
        normalizedPercentage = NormalizedPercentage(strength);
        Debug.Log("From the cooldownbar: " + strength + " " + normalizedPercentage);
        label.text = tag;
        InvokeRepeating("UpdateWidth", 0, 1);
    }

	private void UpdateWidth () {
        if (width > 0F)
        {
            bar.GetComponent("RectTransform").transform.localScale = new Vector3(width, 1, 1);
            width = width - normalizedPercentage;/* NormalizedPercentage(strength) 0.01F; */
        }
        else
        {
            barContainer.SetActive(false);
        }
	}

    private float NormalizedPercentage(int val)
    {
        return (1/val);
    }
}

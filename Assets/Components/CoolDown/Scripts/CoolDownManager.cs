using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoolDownManager : MonoBehaviour
{
    public GameObject coolDownBarPrefab;

    public void AddCoolDownBar(string tag, int strength)
    {
        if (tag != "")
        {
            GameObject coolDownBar = Instantiate(coolDownBarPrefab) as GameObject;
            CoolDownBar coolDownBarScript = coolDownBar.GetComponent<CoolDownBar>();

            coolDownBar.transform.SetParent(transform, false);

            // set the prefab position
            coolDownBar.GetComponent<RectTransform>().offsetMax = new Vector2(0, 150 * (transform.childCount - 1) - 400);

            // init the prefab
            coolDownBarScript.Init(transform.childCount, tag, strength);
        }
    }

    void Update()
    {
        if (transform.childCount > 0)
        {
            int i = 0;
            foreach (Transform child in transform)
            {   // place all children correctly
                child.GetComponent<RectTransform>().offsetMax = new Vector2(0, 150 * i - 400);
                i++;
            }
        }
    }
}

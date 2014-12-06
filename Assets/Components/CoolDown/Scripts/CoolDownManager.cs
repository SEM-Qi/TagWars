using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoolDownManager : MonoBehaviour
{

    public GameObject coolDownBarPrefab;

    private int numOfCoolDowns = 0;
    private int removedID = 100;

    public void AddCoolDownBar(string tag, int strength)
    {
        GameObject coolDownBar = Instantiate(coolDownBarPrefab) as GameObject;
        CoolDownBar coolDownBarScript = coolDownBar.GetComponent<CoolDownBar>();

        coolDownBar.transform.SetParent(transform, false);

        // set the prefab position
        coolDownBar.GetComponent<RectTransform>().offsetMax = new Vector2(0, 150 * numOfCoolDowns - 400);

        // init the prefab
        coolDownBarScript.Init(numOfCoolDowns, tag, strength);
        numOfCoolDowns++;
    }

    void Update()
    {
        if (transform.childCount > 0)
        {   // get rid of expired Cooldowns (probably expensive)
            List<GameObject> children = new List<GameObject>();
            foreach (Transform child in transform)
            {
                CoolDownBar tempCoolDownBar = child.GetComponent<CoolDownBar>();
                if (tempCoolDownBar.IsDone())
                {
                    removedID = tempCoolDownBar.GetID();
                    children.Add(child.gameObject);
                }

                if (tempCoolDownBar.GetID() > removedID)
                {
                    // move DOWN all cooldowns that are above the one removed 
                    child.GetComponent<RectTransform>().offsetMax = new Vector2(0, child.GetComponent<RectTransform>().offsetMax.y - 150);
                }
            }

            removedID = 100; // reset ID

            children.ForEach(child =>
            {
                Destroy(child);
                numOfCoolDowns--;
            });
        }
    }
}

using UnityEngine;
using System.Collections;

public class CoolDownManager : MonoBehaviour {

    public GameObject coolDownBarPrefab;
    public GameObject coolDownPanel;

	// Use this for initialization
    public void AddCoolDownBar(string tag, int strength)
    {
        GameObject coolDownBar = Instantiate(coolDownBarPrefab) as GameObject;
        CoolDownBar coolDownBarScript = coolDownBar.GetComponent<CoolDownBar>();

        coolDownBar.transform.SetParent(coolDownPanel.transform, false);
        // set the prefab position

        // display the start animation

        // init the prefab
        coolDownBarScript.Init(tag, strength);
        //Debug.Log("Cooldown added: " + tag + "," + strength);
    }

    public void RemoveCoolDownBar()
    {

    }
}

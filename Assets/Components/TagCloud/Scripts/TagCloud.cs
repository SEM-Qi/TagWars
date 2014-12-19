using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/* TagCloud Class:
 * the tagcloud manages the tagcloud effect visible 
 * while the player is not charging the attack */

public class TagCloud : MonoBehaviour {

    private List<string> list;
    public GameObject tagPrefab;

    public void Init()
    {   // not efficient, updates the valid tags every time it is initialized
        list = QueryManager.validTags;
        if (list.Count > 1)
        {
            InvokeRepeating("RandomWord", 0, 0.5f);
        }
    }

	private void RandomWord () 
    {
        GameObject tag = Instantiate(tagPrefab) as GameObject;
        tag.transform.SetParent(transform, false);
        tag.transform.position = new Vector2(Random.Range(-300, 300), -250);
        tag.GetComponent<TagParticle>().Init("#"+ list[Random.Range(0, list.Count - 1)]);
	}

    public void Cancel()
    {
        CancelInvoke();
    }
}

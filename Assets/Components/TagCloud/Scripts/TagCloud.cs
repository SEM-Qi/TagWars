using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TagCloud : MonoBehaviour {

    private List<string> list;
    public GameObject tagPrefab;

    //private string[] animations = { "up", "upright", "upleft", "left", "right", "down", "downright", "downleft" };

    public GameObject queryManagerObject;
    private QueryManager queryManager;

	// Use this for initialization
	void Start () {
        queryManager = queryManagerObject.GetComponent<QueryManager>();
	}

    public void Init()
    {
        list = queryManager.GetValidTags(); // not efficient
        InvokeRepeating("RandomWord", 0, 0.5f);
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

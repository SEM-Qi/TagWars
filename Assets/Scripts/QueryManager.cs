using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using System;

/* The QueryManager makes HTTP requests to query 
   the valid tags as well as the damage distribution,
   it also gets the player ID and info */

public class QueryManager : MonoBehaviour
{
    private JSONParser jp = new JSONParser();

    private int[] currentDistribution;
    private List<string> validTags = new List<string>();

    // URL for Http requests
    private string validTagUrl = "http://picard.skip.chalmers.se/updatelist";
    private string damageDistributionUrl = "http://picard.skip.chalmers.se/tagattack?tag=";

    // URL for Auth
    private string authUrl = "http://picard.skip.chalmers.se/authorize";

    void Start()
    {   // on start the valid tags are queried
        StartCoroutine(QueryValidTag());
    }

    // Coroutines ====================================
    public IEnumerator QueryValidTag()
    {
        WWW www = new WWW(validTagUrl);
        yield return www;
        validTags = jp.GetAvailableTags(www.text);
        Debug.Log(www.text);
    }

    public IEnumerator QueryDamageDistribution(string value, Action OnResponce)
    {
        WWW www = new WWW(damageDistributionUrl + value);
        yield return www;
        currentDistribution = jp.GetDistribution(www.text);
        Debug.Log(www.text);
        OnResponce();
    }

    // Player OAuth ==================================
    public void OAuthPlayer(string[] OAuth)
    {
        Debug.LogError("OAuth Method Called");
        WWWForm form = new WWWForm();
        form.AddField("user_id", OAuth[0]);
        form.AddField("auth_key", OAuth[1]);

        WWW www = new WWW(authUrl, form);
    }

    // Getters & Setters =============================
    public List<string> GetValidTags() { return validTags; }

    public int[] GetDistribution() { return currentDistribution; }
}

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
    private static JSONParser jsonParser = new JSONParser();

    private static int[] currentDistribution;
    private static List<string> validTags = new List<string>();

    private static Texture2D profileImage;
    private static Texture2D enemyImage;

    //private string userID;

    // URL for Http requests
    private string validTagUrl = "http://picard.skip.chalmers.se/updatelist";
    private static string damageDistributionUrl = "http://picard.skip.chalmers.se/tagattack?tag=";

    // URL for Auth
    //private string authUrl = "http://picard.skip.chalmers.se/authorize";

    // URL for UserInfo
    //private string userInfoUrl = "http://picard.skip.chalmers.se/getuserinfo";

    void Start()
    {   // on start the valid tags are queried
        StartCoroutine(QueryValidTag());
    }

    // Coroutines ====================================
    public IEnumerator QueryValidTag()
    {
        WWW www = new WWW(validTagUrl);
        yield return www;
        validTags = jsonParser.GetAvailableTags(www.text);
        Debug.Log(www.text);
    }

    public static IEnumerator QueryDamageDistribution(string value, Action OnResponce)
    {
        WWW www = new WWW(damageDistributionUrl + value);
        yield return www;
        currentDistribution = jsonParser.GetDistribution(www.text);
        Debug.Log(www.text);
        OnResponce();
    }

    public static IEnumerator QueryImage(bool player, string url, Action SetImages)
    {
        WWW www = new WWW(url);
        yield return www;

        if (player)
            profileImage = www.texture;
        else
            enemyImage = www.texture;
        
        SetImages();
    }

    // Getters & Setters =============================
    public static List<string> GetValidTags() { return validTags; }

    public static bool IsValid(string text)
    {
        if (validTags.Contains(text))
            return true;
        else
            return false;
    }

    public static int[] GetDistribution() { return currentDistribution; }

    public static Texture2D GetProfilePic() { return profileImage; }

    public static Texture2D GetEnemyPic() { return enemyImage; }
}

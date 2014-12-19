using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using System;
using System.Security.Cryptography;

/* QueryManager Class:
 * makes HTTP requests to query 
   the valid tags as well as the damage distribution,
   it also gets the player ID and info */

public class QueryManager : MonoBehaviour
{
    private static JSONParser jsonParser = new JSONParser();

    private static int[] currentDistribution;
    public static List<string> validTags { get; private set; }

    private static Texture2D profileImage;
    private static Texture2D enemyImage;

    private static string userID;

    // URL for Http requests
    private static string validTagUrl = "http://picard.skip.chalmers.se/updatelist?";
    private static string damageDistributionUrl = "http://picard.skip.chalmers.se/tagattack?";

    // URL for Auth
    private string updateKeyUrl = "http://picard.skip.chalmers.se/updatekey";
    private string authUrl = "http://picard.skip.chalmers.se/authorize";

    void Start()
    {
        validTags = new List<string>();
    }

    // Coroutines ====================================
    public static IEnumerator QueryValidTag()
    {
        WWW www = new WWW(validTagUrl + "player=" + userID);
        yield return www;
        validTags = jsonParser.GetAvailableTags(www.text);
        Debug.Log(www.text);
    }

    public static IEnumerator QueryDamageDistribution(string newTag, string lastTag, int lastTagDamage, Action OnResponce)
    {
        WWW www = new WWW(damageDistributionUrl + "player=" + userID + "&tag=" + newTag + "&lastTag=" + lastTag + "&damage=" + lastTagDamage);
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

    public IEnumerator RequestAuth(string OAuth)
    {
        // checking if User & Key match on Riak
        string[] authInfo = OAuth.Split(',');

        userID = authInfo[0];

        WWWForm form = new WWWForm();
        form.AddField("user_id", userID);
        form.AddField("auth_key", authInfo[1]);

        WWW www = new WWW(authUrl, form);
        yield return www;

        if (www.text == "true")
            TagWars.validUser = true;
        else
            TagWars.validUser = false;

        // create new Hash
        CreateHash();
    }

    public IEnumerator CreateHash()
    {
        // Creating a new hash
        RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
        byte[] randomBytes = new byte[24];
        random.GetBytes(randomBytes);
        string bitesintoString = "";
        foreach (var b in randomBytes)
        {
            bitesintoString += b + "";
        }
        string hash = "";
        SHA512 alg = SHA512.Create();
        byte[] result = alg.ComputeHash(Encoding.UTF8.GetBytes(bitesintoString));
        hash = Encoding.UTF8.GetString(result);

        // Sending an http request to cowboy
        WWWForm newform = new WWWForm();
        newform.AddField("user_id", userID);
        newform.AddField("auth_key", hash);

        WWW postKey = new WWW(updateKeyUrl, newform);
        yield return postKey;

        if (!String.IsNullOrEmpty(postKey.error))
            Debug.Log(postKey.error);
        else
            Debug.Log("posted Key");
    }

    // Getters & Setters =============================

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

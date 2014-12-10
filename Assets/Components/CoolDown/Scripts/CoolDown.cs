using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoolDown : MonoBehaviour
{

    private static Dictionary<string, int> usedTags = new Dictionary<string, int>();

    private static CoolDownManager coolDownManager;

    void Start()
    {
        coolDownManager = GetComponent<CoolDownManager>();
        InvokeRepeating("Timer", 0, 1);
    }

    public static void AddCoolDown(string tag, int strength)
    {
        usedTags.Add(tag, strength);
        coolDownManager.AddCoolDownBar(tag, strength);
    }

    public static bool ContainsTag(string tag)
    {
        return new List<string>(usedTags.Keys).Contains(tag);
    }

    private void Timer()
    {
        if (usedTags != null)
        {
            List<string> keys = new List<string>(usedTags.Keys);
            foreach (string key in keys)
            {
                usedTags[key] = usedTags[key] - 1;
            }
            RemoveWhenZero(usedTags);
        }
    }

    private void RemoveWhenZero(Dictionary<string, int> dictionary)
    {
        List<string> tagsToRemove = new List<string>();

        foreach (var pair in dictionary)
        {
            if (pair.Value.Equals(0))
                tagsToRemove.Add(pair.Key);
        }

        foreach (string tag in tagsToRemove)
        {
            dictionary.Remove(tag);
        }
    }
}

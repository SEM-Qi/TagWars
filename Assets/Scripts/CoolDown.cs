using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoolDown : MonoBehaviour
{

    private Dictionary<string, int> usedTags = new Dictionary<string, int>();

    void Start()
    {
        InvokeRepeating("Timer", 0, 1);
    }

    public void AddCoolDown(string tag, int strength)
    {
        usedTags.Add(tag, strength);
    }

    public List<string> GetUsedTags()
    {
        return new List<string>(usedTags.Keys);
    }

    private void Timer()
    {
        if (usedTags != null)
        {
            List<string> keys = new List<string>(usedTags.Keys);
            foreach (string key in keys)
            {
                usedTags[key] = usedTags[key] - 1;
                Debug.Log(key + " " + usedTags[key]);
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

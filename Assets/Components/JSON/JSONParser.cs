using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using SimpleJSON;
using System;

/* INFO */

public class JSONParser
{
    public string GetName(string query)
    {
        JSONNode node = JSON.Parse(query);
        return node["name"];
    }

    public List<string> GetAvailableTags(string query)
    {
        JSONNode node = JSON.Parse(query);
        return NodeToStringList(node["tags"]);
    }

    public List<string> GetDamageObject(string query){
        JSONNode node = JSON.Parse(query);
        return NodeToStringList(node["distribution"]);
    }

    public int[] GetDistribution(string query)
    {   // this is a UNEFFECTIVE MESS
        JSONNode node = JSON.Parse(query);
        int length = NodeToStringList(node["distribution"]).Count;
        int[] distribution = new int[length];
        for(int i = 0; i < length; i++){
            distribution[i] = Convert.ToInt32(node["distribution"][i]["numtags"].Value);
        }
        return distribution;
    }

    // HELPER FUNCTIONS 
    public List<string> NodeToStringList(JSONNode node)
    {
        List<string> arr = new List<string>();
        for (int i = 0; i < node.Count; i++)
        {
            arr.Add(node[i]);
        }
        return arr;
    }

    public List<int> NodeToIntList(JSONNode node)
    {
        List<int> arr = new List<int>();
        for (int i = 0; i < node.Count; i++)
        {
            arr.Add(Convert.ToInt32(node[i]));
        }
        return arr;
    }
}

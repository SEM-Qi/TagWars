using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using SimpleJSON;

/* INFO */

public class JSONParser : MonoBehaviour
{
    public string GetName(string query)
    {
        JSONNode node = JSON.Parse(query);
        return node["name"];
    }

    public List<string> GetAvailableTags(JSONNode node)
    {
        return NodeToList(node["available"]);
    }

    public int GetDamage(JSONNode node, int sec)
    {
        return int.Parse(node["distribution"][sec]["ammount"].Value);
    }

    // HELPER FUNCTIONS 
    public List<string> NodeToList(JSONNode node)
    {
        List<string> arr = new List<string>();
        for (int i = 0; i < node.Count; i++)
        {
            arr.Add(node[i]);
        }
        return arr;
    }
}

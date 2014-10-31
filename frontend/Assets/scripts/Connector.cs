using UnityEngine;
using System.Collections;
using System.IO;

/* INFO */

public class Connector : MonoBehaviour
{
    // Replace with HTTP connections
    public string QueryPlayerName(int id)
    {
        if (id == 12343)
        {
            return Read("/fake_data/player02_data.json");
        }
        else
        {
            return Read("/fake_data/player01_data.json");
        }
    }

    public string QueryDistribution()
    {
        return Read("/fake_data/test_message.json");
    }

    public string QueryAvailableTags()
    {
        return Read("/fake_data/available_tags.json");
    }

    public string Read(string path)
    {
        StreamReader sr = new StreamReader(Application.dataPath + path);
        string content = sr.ReadToEnd();
        sr.Close();
        return content;
    }
}

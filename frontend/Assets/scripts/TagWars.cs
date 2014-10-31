using UnityEngine;
using System.Collections;

/* INFO */

public class TagWars : MonoBehaviour
{
    void Start()
    {
        //Connector conn = new Connector();
        //JSONParser jp = new JSONParser();
        //Player player1 = new Player(jp.GetName(conn.QueryPlayerName(12343)));
        //Player player2 = new Player(jp.GetName(conn.QueryPlayerName(12344)));
        //new Game(player1, player2);
        NetworkManager nm = GetComponent<NetworkManager>();
        nm.LaunchServer();
    }

    void OnGUI()
    {

    }
    
}

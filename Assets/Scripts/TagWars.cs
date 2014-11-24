using UnityEngine;
using System.Collections;

/* TagWars: MAIN CLASS */

public class TagWars : MonoBehaviour
{
    private Controller controller;
    private NetworkManager networkManager;

    void Start()
    {
        // Initializing UI
        controller = GetComponent<Controller>();
        networkManager = GetComponent<NetworkManager>();
        networkManager.Disconnect();

        //TODO: load player info
    }

    void Update()
    {   // if start game button is pressed
        if (controller.MultiplayerStarted())
        {
            // TODO ADD CONNECTION CODE HERE
            networkManager.Connect();
            Application.LoadLevel("Battle");
        }
    }
}

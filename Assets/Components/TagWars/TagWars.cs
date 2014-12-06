using UnityEngine;
using System.Collections;

/* TagWars: MAIN CLASS */

public class TagWars : MonoBehaviour
{
    public GameObject mainMenuObject;
    private MainMenu mainMenu;
    private NetworkManager networkManager;

    void Start()
    {
        // Initializing UI
        mainMenu = mainMenuObject.GetComponent<MainMenu>();
        networkManager = GetComponent<NetworkManager>();
        if (networkManager.MultiplayerStarted())
        {
            networkManager.Disconnect();
            
        }
    }

    void Update()
    {   // if start game button is pressed
        if (mainMenu.StartGame()) 
        { 
            networkManager.Connect();
            mainMenu.SetStartGame(false);
        }

        if (networkManager.MultiplayerStarted()) { Application.LoadLevel("Battle"); }

        if (mainMenu.QuitGame()) { Application.Quit(); }
    }
}

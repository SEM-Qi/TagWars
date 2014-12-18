using UnityEngine;
using System.Collections;

/* TagWars: MAIN CLASS */

public class TagWars : MonoBehaviour
{
    public GameObject mainMenuObject;
    private MainMenu mainMenu;
    private NetworkManager networkManager;

    public static bool validUser { get; set; }

    void Start()
    {
        mainMenu = mainMenuObject.GetComponent<MainMenu>();
        networkManager = GetComponent<NetworkManager>();

        Application.ExternalCall("OnUnityAuth");
        Application.ExternalCall("OnUnityReady");
    }

    void Update()
    {   // if start game button is pressed
        if (mainMenu.StartGame()) 
        { 
            networkManager.Connect();
            mainMenu.SetStartGame(false);
        }

        if (networkManager.MultiplayerStarted() && validUser) { Application.LoadLevel("Battle"); }

        if (mainMenu.QuitGame()) { Application.Quit(); }
    }
}

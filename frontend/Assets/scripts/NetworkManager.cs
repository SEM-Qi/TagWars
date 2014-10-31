using UnityEngine;
using System.Collections;

/* The ANIM class is a wrapper for the Unity.Animator object
it stores all Animators in our project */

public class NetworkManager : MonoBehaviour {

    //private string ip = "127.0.0.1";
    //private int port = 4242;
    //private bool NAT = false;
    

    public NetworkManager()
    {
        Debug.Log("I'm ok");
    }

    public void LaunchServer()
    {
        MasterServer.ipAddress = "129.16.155.39";
        MasterServer.port = 23466;
        Network.InitializeServer(2, 25000, false);
        MasterServer.RegisterHost("123456","room123456");
    }

    void OnServerInitialized()
    {
        Debug.Log("Server Initializied");
    }

    public void ConnectToServer()
    {

    }

    public void ShutdownServer()
    {

    }
}

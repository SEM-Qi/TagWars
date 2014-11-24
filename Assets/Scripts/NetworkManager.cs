using UnityEngine;
using System.Collections;

/* The NetworkManager class deals with the multiplayer functionality of TagWars */

public class NetworkManager : MonoBehaviour
{
    Controller controller;

    void Start()
    {
        controller = GetComponent<Controller>();
    }

    void Update()
    {
        if (controller.MultiplayerStarted())
        {
            // Code for Start Server
        }
    }

    public void Connect()
    {
        PhotonNetwork.offlineMode = false;
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.isWriting)
    //    {
    //        stream.SendNext(Health);
    //    }
    //    else
    //    {
    //        Health = (float)stream.ReceiveNext();
    //    }
    //}

    void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonJoinFailed()
    {

    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("No room available");
        NewRoom(null);
    }

    void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
    }

    private void NewRoom(string name)
    {
        PhotonNetwork.CreateRoom(name);
        Debug.Log("Create Room");
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
        Debug.Log("Disconnected");
    }

    // USE JoinOrCreate for challenging a friend
}

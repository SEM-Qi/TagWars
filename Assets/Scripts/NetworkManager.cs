using UnityEngine;
using System.Collections;

/* The NetworkManager class deals with the multiplayer functionality of TagWars */

public class NetworkManager : MonoBehaviour
{
    private Controller controller;

    private RoomOptions roomOptions;
    private Room myRoom;
    private int myRoomPlayers = 0;
    private int myRoomMaxPlayers = 2;

    void Start()
    {
        controller = GetComponent<Controller>();
        roomOptions = new RoomOptions() { maxPlayers = myRoomMaxPlayers };
    }

    void Update()
    {
        if (controller.MultiplayerStarted())
        {
            // Code for Start Server
        }
        if (myRoomMaxPlayers == myRoomPlayers)
        {
            controller.Connected();
        }
    }

    public void Connect()
    {
        PhotonNetwork.offlineMode = false;
        PhotonNetwork.ConnectUsingSettings("0.1");
        controller.Connect(false);
    }

    void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("No room available");
        NewRoom(null);
    }

    void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        myRoom = PhotonNetwork.room;
        myRoomPlayers = myRoom.playerCount;
    }

    void OnPhotonPlayerConnected()
    {
        myRoomPlayers = myRoom.playerCount;
    }

    private void NewRoom(string name)
    {
        Debug.Log("Create Room");
        PhotonNetwork.CreateRoom(name, roomOptions, null);
    }

    public void Disconnect()
    {
        Debug.Log("Disconnected");
        PhotonNetwork.Disconnect();
    }
}

using UnityEngine;
using System.Collections;

/* The NetworkManager class deals with the multiplayer functionality of TagWars */

public class NetworkManager : MonoBehaviour
{
    Controller controller;
//======================= added code
	private RoomOptions roomOptions;
	private Room myRoom;
	private int myRoomPlayers = 0;
	private int myRoomMaxPlayers = 2;
//===============================/

    void Start()
    {
        controller = GetComponent<Controller>();
//======================= added code
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
//================================ /

    public void Connect()
    {
        PhotonNetwork.offlineMode = false;
        PhotonNetwork.ConnectUsingSettings("0.1");
		controller.Connect(false);
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
//======================= added code
		myRoom = PhotonNetwork.room;
		myRoomPlayers = myRoom.playerCount;
//=================================/
    }
	void OnPhotonPlayerConnected(){
		myRoomPlayers = myRoom.playerCount;
	}


    private void NewRoom(string name)
    {
//======================= added code
        PhotonNetwork.CreateRoom(name, roomOptions, null);

//==========================/
        Debug.Log("Create Room");
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
        Debug.Log("Disconnected");
    }

    // USE JoinOrCreate for challenging a friend
}

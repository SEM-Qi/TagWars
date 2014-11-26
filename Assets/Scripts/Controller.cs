using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
    private bool timerOver = false;
    private bool startNewGame = false;
    private bool startMultiplayer = false;

//========================= added code
	private bool connecting = false;
	private bool connected = false;


	// NetworkStatus ------------------------


	public void Connect(bool connect)
	{
		connecting = connect;
	}
	public bool IsConnecting()
	{
		return connecting;
	}
	public void Connected()
	{
		connected = true;
	}
	public bool IsConnected()
	{
		return connected;
	}

//==========================================/
    // Timer --------------------------------
    public bool TimerOver()
    {
        return timerOver;
    }

    public void SetTimerOver(bool timerState)
    {
        timerOver = timerState;
    }

    // NewGame -------------------------------
    public bool StartNewGame()
    {
        return startNewGame;
    }

    public void StartMultiplayer()
    {
        startMultiplayer = true;
    }

    public bool MultiplayerStarted()
    {
        return startMultiplayer;
    }

    public void SetStartNewGame(bool newGame)
    {
        startNewGame = newGame;
    }
}

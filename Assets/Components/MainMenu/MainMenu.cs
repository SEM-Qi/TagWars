using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* MainMenu Class:
 * the View of the MainMenu Component */

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public Text startButtonText;
    public Text playerName;

    private bool startGame = false;
    private bool quitGame = false;

    void Start()
    {

        startButton.onClick.AddListener(() =>
        {
            Debug.Log("START");
            startGame = true;
            startButton.interactable = false;
            startButtonText.text = "CONNECTING";
        });

        exitButton.onClick.AddListener(() => 
        { 
            Debug.Log("EXIT");
            quitGame = true;
        });
    }

    public void SetName(string name)
    {
        PlayerPrefs.SetString("playerName", name);
        playerName.text = name;
    }

    public bool QuitGame() { return quitGame; }

    public bool StartGame() { return startGame; }

    public void SetStartGame(bool b) { startGame = b; }
}

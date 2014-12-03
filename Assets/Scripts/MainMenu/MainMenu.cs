using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* View of the MainMenu component */

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public Text startButtonText;

    private bool startGame = false;
    private bool quitGame = false;

    void Start()
    {
        startButton.onClick.AddListener(() =>
        {
            Debug.Log("START");
            startGame = true;
            startButton.interactable = false;
            startButtonText.text = "Connecting";
        });

        exitButton.onClick.AddListener(() => 
        { 
            Debug.Log("EXIT");
            quitGame = true;
        });
    }

    public bool QuitGame() { return quitGame; }

    public bool StartGame() { return startGame; }

    public void SetStartGame(bool b) { startGame = b; }
}

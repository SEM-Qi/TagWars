using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* INFO */

public class MainMenu : MonoBehaviour {
    public Button startButton;
    public Button exitButton;

    public Controller controller;

	void Start () {
        controller = GetComponent<Controller>();
        startButton.onClick.AddListener(() => { Debug.Log("START"); Application.LoadLevel("Battle"); controller.StartMultiplayer(); });
        exitButton.onClick.AddListener(() => { Debug.Log("EXIT"); Application.Quit(); });
	}
}

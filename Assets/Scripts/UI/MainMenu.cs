using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* INFO */

public class MainMenu : MonoBehaviour {
    public Button startButton;
    public Button exitButton;

    public GameObject scripts;
    private Controller controller;

	void Start () {
        controller = scripts.GetComponent<Controller>();
        startButton.onClick.AddListener(() => { Debug.Log("START"); controller.StartMultiplayer(); });
        exitButton.onClick.AddListener(() => { Debug.Log("EXIT"); Application.Quit(); });
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* INFO */

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public GameObject scripts;
    public Text startButtonText;

    private Controller controller;

    void Start()
    {
        controller = scripts.GetComponent<Controller>();

        startButton.onClick.AddListener(() =>
        {
            Debug.Log("START"); 
            controller.Connect(true);
            startButton.interactable = false;
            startButtonText.text = "Connecting";
        });

        exitButton.onClick.AddListener(() => { Debug.Log("EXIT"); Application.Quit(); });
    }

    void Update()
    {
        if (controller.IsConnected()) { controller.StartMultiplayer(); }
    }
}

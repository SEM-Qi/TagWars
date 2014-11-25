using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* INFO */

public class MainMenu : MonoBehaviour {

    public Button startButton;
    public Button exitButton;
    public GameObject scripts;
    private Controller controller;
	//James
	public Text startButtonText;
	//====

	void Start () {
        controller = scripts.GetComponent<Controller>();
		startButtonText = startButton.GetComponentInChildren<Text> ();
		startButton.onClick.AddListener(() => { Debug.Log("Start"); controller.Connect(true); 
			startButton.interactable = false; startButtonText.text = "Connecting"; });
		//James

		//=====

		exitButton.onClick.AddListener(() => { Debug.Log("EXIT"); Application.Quit(); });
	}
	//James
	void Update (){
		if(controller.IsConnected()){
			controller.StartMultiplayer();
		}
	
	}
	//====

}

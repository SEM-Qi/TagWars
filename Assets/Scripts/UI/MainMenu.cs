using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* INFO */

public class MainMenu : MonoBehaviour {

    public Button startButton;
    public Button exitButton;
    public GameObject scripts;
    private Controller controller;
//======================= added code
	public Text startButtonText;
//======================= /

	void Start () {
        controller = scripts.GetComponent<Controller>();
//======================= added code
		startButtonText = startButton.GetComponentInChildren<Text> ();
		startButton.onClick.AddListener(() => { Debug.Log("Start"); controller.Connect(true); 
			startButton.interactable = false; startButtonText.text = "Connecting"; });
//======================= /

		exitButton.onClick.AddListener(() => { Debug.Log("EXIT"); Application.Quit(); });
	}
//======================= added code
	void Update (){
		if(controller.IsConnected()){
			controller.StartMultiplayer();
		}
	
	}
//===========================/

}

#pragma strict

// the DebugPanel Object serves as a provisory main menu and hub for test elements

var debug_panel:GameObject;
var start_button:GameObject;
var exit_button:GameObject;
private var toggled:boolean = false;

function Start(){
	var Game = GetComponent(Game);
	debug_panel.SetActive(true);
	start_button.GetComponent(UI.Button).onClick.AddListener(function(){Game.Begin();debug_panel.SetActive(false);});
	exit_button.GetComponent(UI.Button).onClick.AddListener(Game.Exit);
}

function Update () {
	Toggle(debug_panel);
}

function Toggle(element:GameObject){
	if(element.activeSelf){
		if (Input.GetKeyDown("escape")){
			element.SetActive(false);
		}
	}else{
		if (Input.GetKeyDown("escape")){
			element.SetActive(true);
		}
	}
}
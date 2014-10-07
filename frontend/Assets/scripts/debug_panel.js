#pragma strict

var is_active:boolean;
var debug_panel:GameObject;
var exit_button:GameObject;

function Start(){
	is_active = false;
	debug_panel.SetActive(false);
	exit_button.GetComponent(UI.Button).onClick.AddListener(Exit);
}

function Update () {
	if(is_active){
		if (Input.GetKeyDown("escape")){
			debug_panel.SetActive(false);
			is_active = false;
		}
	}else{
		if (Input.GetKeyDown("escape")){
			debug_panel.SetActive(true);
			is_active = true;
		}
	}
}

function Exit(){
	Application.Quit();
	print("quit");
}
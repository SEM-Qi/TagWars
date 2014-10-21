#pragma strict

var play_button:GameObject;
var option_button:GameObject;
var title_bar:GameObject;

function Start () {
	play_button.GetComponent(UI.Button).onClick.AddListener(function(){Game.Connect();});
	option_button.GetComponent(UI.Button).onClick.AddListener(function(){print("option button pressed");});
}

function Init(){
	Game.SetState("menu");
	Anim.SetTrigger("ui_anim","menu");
}


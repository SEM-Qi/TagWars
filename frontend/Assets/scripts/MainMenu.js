#pragma strict

private var G:Game;
var play_button:GameObject;
var option_button:GameObject;
var title_bar:GameObject;

function Start () {
	var Game = GetComponent(Game);
	play_button.GetComponent(UI.Button).onClick.AddListener(function(){Game.Connect();});
	option_button.GetComponent(UI.Button).onClick.AddListener(function(){print("option button pressed");});
}
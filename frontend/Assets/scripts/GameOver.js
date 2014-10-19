#pragma strict

var main_menu_button:GameObject;
var game_over:GameObject;
var timer:float;

private var main_menu:MainMenu;

function Start () {
	main_menu = GetComponent(MainMenu); 
	main_menu_button.GetComponent(UI.Button).onClick.AddListener(function(){main_menu.Init();game_over.SetActive(false);});
}

function Init(){
	game_over.SetActive(true);
}


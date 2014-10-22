#pragma strict

var main_menu_button:GameObject;
var game_over:GameObject;

function Start () {
	main_menu_button.GetComponent(UI.Button).onClick.AddListener(function(){
		Anim.SetBool("ui_anim","game_over",false); 
		Game.SetState("menu");});
}

function Update() {
	if(Game.state == "game_over"){
		Init();
	}
}

function Init(){
	Anim.SetBool("ui_anim","game_over",true);
}



#pragma strict

var play_button:GameObject;
var option_button:GameObject;
var title_bar:GameObject;

private var menu_on:boolean;

function Start () {
	menu_on = false;
	play_button.GetComponent(UI.Button).onClick.AddListener(function(){Game.Connect();});
	option_button.GetComponent(UI.Button).onClick.AddListener(function(){print("option button pressed");});
}

function Update(){
	if(Game.state == "menu"){
		if(!menu_on){
			Init();
			menu_on = true;
		}
	}else{
		menu_on = false;
	}
}

function Init(){
	Anim.SetTrigger("ui_anim","menu");
}


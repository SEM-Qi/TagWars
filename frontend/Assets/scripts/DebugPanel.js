#pragma strict

// the DebugPanel Object serves as a provisory main menu launcher and hub for test elements
var debug_panel:GameObject;
var start_button:GameObject;
var exit_button:GameObject;
var launch_enemy_attack:GameObject;

private var main_menu:MainMenu;
private var enemy_attack:EnemyAttack; 
private var toggled:boolean = false;

function Start(){
	main_menu = GetComponent(MainMenu); 
	enemy_attack = GetComponent(EnemyAttack);
	
	debug_panel.SetActive(true);
	
	// ACTION LISTENERS
	start_button.GetComponent(UI.Button).onClick.AddListener(function(){main_menu.Init();debug_panel.SetActive(false);});
	exit_button.GetComponent(UI.Button).onClick.AddListener(Game.Exit);
	launch_enemy_attack.GetComponent(UI.Button).onClick.AddListener(enemy_attack.Init); 
}

function Update () {
	Helper.Toggle(debug_panel);
}


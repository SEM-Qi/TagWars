#pragma strict

var enemy_input_field:UI.Text;
private var enemy_input:String;

function Start(){
	// TODO add access to enemy input data
	enemy_input = "#cat";
}

// Getters & Setters --------------------------
function GetEnemyInput():String{
	return enemy_input;
}
//---------------------------------------------

function Init(){
	Anim.SetBool("enemy_anim","enemy_cancel", false);
	Anim.SetTrigger("enemy_anim","enemy_attack");
	enemy_input_field.text = enemy_input;
}

function Cancel(){
	Anim.SetBool("enemy_anim","enemy_cancel", true);
}	

function ChangePlayerHealth(damage:int){
	Health.SetPlayerHealth(Health.GetPlayerHealth() - damage);
	print(Health.GetPlayerHealth());
}
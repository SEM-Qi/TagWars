#pragma strict

var enemy_input_field:UI.Text;
private var enemy_input:String;

function Start(){
	// TODO add access to enemy input data
	enemy_input = "#cat";
}

function Init(){
	Anim.SetBool("enemy_anim","enemy_cancel", false);
	Anim.SetTrigger("enemy_anim","enemy_attack");
	enemy_input_field.text = enemy_input;
}

function GetEnemyInput():String{
	return enemy_input;
}
function Cancel(){
	Anim.SetBool("enemy_anim","enemy_cancel", true);
}	

//function ChangePlayerHealth(damage:int){
//	var currentHealth = Health.GetPlayerHealth() - damage;
//	Health.SetPlayerHealth(currentHealth);
//	print(Health.GetPlayerHealth());
//}
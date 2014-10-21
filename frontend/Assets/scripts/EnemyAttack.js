#pragma strict

var enemy_input_field:UI.Text;

private var anim:Anim;
private var enemy_input:String;
private var canceled_attack:boolean;
function Start(){
	anim = GetComponent(Anim);
	enemy_input = "#cat";
	canceled_attack = false;
}

function Init(){
	canceled_attack = false;
	anim.Boolean("enemy_cancel", false);
	anim.trigger("enemy_attack");
	enemy_input_field.text = enemy_input;
	
}

function GetEnemyInput():String{
	return enemy_input;
}
function Cancel(){
	if(!canceled_attack){
		anim.Boolean("enemy_cancel", true);
		canceled_attack = true;
	}
	
}	
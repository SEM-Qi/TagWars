#pragma strict

var enemy_input_field:UI.Text;

private var anim:Anim;
private var enemy_input:String;

function Start(){
	anim = GetComponent(Anim);
	enemy_input = "#cat";
}

function Init(){
	anim.Boolean("enemy_cancel", false);
	anim.trigger("enemy_attack");
	enemy_input_field.text = enemy_input;
}

function GetEnemyInput():String{
	return enemy_input;
}
function Cancel(){
	anim.Boolean("enemy_cancel", true);
}	
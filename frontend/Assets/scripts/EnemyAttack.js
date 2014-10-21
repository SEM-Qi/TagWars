#pragma strict

var enemy_input_field:UI.Text;

private var anim:Anim;
private var enemy_input:String;

function Start(){
	anim = GetComponent(Anim);
	enemy_input = "#cat";
}

function Init(){
	anim.trigger("enemy_attack");
	enemy_input_field.text = enemy_input;
}

function getEnemyInput():String{
	return enemy_input;
}
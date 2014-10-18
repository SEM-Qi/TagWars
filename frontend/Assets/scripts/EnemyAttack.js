#pragma strict

private var anim:Anim;

function Start(){
	anim = GetComponent(Anim);
}


function Init(){
	anim.trigger("enemy_attack");
}
#pragma strict

private var anim:Anim; 
private var damage:int;

function Start(){
	anim = GetComponent(Anim);
}

function Charge(){
	// TODO code for damage calculation
	Game.SetState("charging");
	Anim.trigger("charging");
}

function Release(){
	// TODO code for damage generation
	Game.SetState("release");
	Anim.trigger("release");
	yield WaitForSeconds(anim.AnimationLength()); // TODO USE ANIMATION EVENT INSTEAD
	Health.opponent_health += 0.1;
}


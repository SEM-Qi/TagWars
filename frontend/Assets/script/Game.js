#pragma strict

// The GAME object is responsible for the game states and the animation triggers
// all the other objects read the state and act acordingly

var game_ui:GameObject;
private var anim:Animator;

static var state:String; // flags the current game state

function Start () {
	anim = game_ui.GetComponent(Animator);
}

// STATES =========================================================

//FUTURE FUNCTIONALITY
// --------------------
//function MainMenu(){
//	state = "main_menu";
//	print(state);
//	anim.SetTrigger("intro");
//	if(true){
//		Connecting();
//	}
//}
//
//function Connecting(){
//	state = "connecting";
//	anim.SetTrigger("connecting");
//	if(true){
//		Begin();
//	}
//}
//------------------------

function Begin(){
	state = "start";
	anim.SetTrigger("start");
	Health.Start();
	// waits until the start animation is over
	yield WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);	
	yield WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
	Ready();
}

function Ready(){
	state = "ready";
	anim.SetTrigger("ready");
	yield WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
	state = "can_attack";
}

function Charging(){
	state = "charging";
	anim.SetTrigger("charging");
}

function Attack(){
	state = "can_not_attack";
	anim.SetTrigger("release");
	yield WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
	Health.playerA_health += 0.1;	// code smell
	Ready();
}

//function Concede(){
//	state = "game_over";
//	anim.SetTrigger("A_wins");
//}
//
//function GameOver(){
//	if(Health.playerA_health == 1){
//		state = "game_over";
//		anim.SetTrigger("B_wins");
//	}
//	if(Health.playerB_health == 1){
//		state = "game_over";
//		anim.SetTrigger("A_wins");
//	}
//}

function Exit(){
	Application.Quit();
}
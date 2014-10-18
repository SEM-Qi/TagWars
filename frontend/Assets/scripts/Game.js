#pragma strict

/* The GAME object is responsible for the game states
all the other objects read the state and act acordingly */

static var state:String; 
static var states:String[] = ["menu","connecting","begin","ready","attack","charging","release","game_over"];

static function SetState(state:String){
	if(Helper.InArray(states,state)){ 
		Game.state = state;
	}else{
		print("ERROR: state not recognized");
	}
} 

//=========================================
/*TODO move Connect() to a Connector Object
the following classes will not stay static*/

static function Connect(){
	SetState("connecting");
	Anim.trigger("connecting");
	
	//TODO logic for the Connection
	Init(); // if(connected)
}
//=========================================

// inits a battle
static function Init(){
	SetState("begin");
	Anim.trigger("begin");
	Health.Start(); 		//resets the health
}

static function Exit(){
	Application.Quit();
}

//function Connect(){
//	state = "connecting";
//	anim.SetTrigger("connecting");
//	// CODE FOR FINDING SERVER HERE
//	
//	// if server is found ->
//	Begin();
//}

//function Begin(){
//	state = "play";
//	anim.SetTrigger("play");
//	Health.Start();
//	// waits until the start animation is over
//	yield WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);	
//	yield WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
//	yield WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
//	Ready();
//}

//function Ready(){
//	state = "ready";
//	anim.SetTrigger("ready");
//	yield WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
//	state = "can_attack";
//}

//function Charging(){
//	state = "charging";
//	anim.SetTrigger("charging");
//}

//function Attack(){
//	state = "can_not_attack";
//	anim.SetTrigger("release");
//	yield WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
//	Health.playerA_health += 0.1;	// code smell
//	Ready();
//}

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

//function EnemyAttack(){
//	anim_enemy.SetTrigger("enemy_attack");
//}


#pragma strict

/* The GAME object is responsible for the game states
all the other objects read the state and act acordingly */

static var state:String; 
static var states:String[] = ["menu","connecting","begin","ready","attack","charging","cancel","release","game_over"];

// Getters & Setters --------------------------
static function SetState(state:String){
	if(Helper.InArray(states,state)){ 
		Game.state = state;
	}else{
		print("ERROR: state not recognized");
	}
} 
//---------------------------------------------

// inits a battle
static function Init(){
	SetState("begin");
	Anim.SetTrigger("ui_anim","begin");
	Health.Init(); //resets the health
}

//=========================================
//TODO move Connect() to a Connector Object
static function Connect(){
	SetState("connecting");
	Anim.SetTrigger("ui_anim","connecting");
	
	//TODO logic for the Connection
	Init(); // if(connected)
}
//=========================================

static function Exit(){
	Application.Quit();
}

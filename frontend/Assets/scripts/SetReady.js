#pragma strict
/* SetReady gets executed on Animation Event, 
it is not located on the script empty-object */

function SetReady(){
	Game.SetState("ready");
	print(Game.state);
}

// TODO should reset the input field
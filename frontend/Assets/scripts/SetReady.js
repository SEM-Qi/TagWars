#pragma strict
/* SetReady gets executed on Animation Event, 
it is not located on the script empty-object */

function SetReady(){
	Game.SetState("ready");
}

// TODO should reset the input field
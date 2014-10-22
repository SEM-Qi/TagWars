#pragma strict

var tDisplay:GameObject;
var scripts:GameObject;

private var game_over:GameOver;
private var countdown:int;
private var match_timer:float;
private var tString:String;
private var match_start:boolean;

function Start(){
	game_over = scripts.GetComponent(GameOver);
	match_start = false;
}

function Update(){
	if (match_start == true){
		match_timer -= Time.deltaTime;
		if (match_timer <= 0){
			print("TIME IS OUT");
			Game.SetState("game_over");
			match_start = false;
		}
	}
}

function StartCountDown(){
	countdown = 4;
	tString = "";
	InvokeRepeating("UpdateCountDown", 0, 1);
}

function UpdateCountDown(){
	if(countdown == 0){
		tString = '#FIGHT';
		tDisplay.GetComponentsInChildren.<UI.Text>()[0].text = tString;
		countdown -= 1;
	}else if(countdown == -2){
		tDisplay.GetComponentsInChildren.<UI.Text>()[0].text = "";
		CancelInvoke();
		match_timer = 180;
		match_start = true;
	}else{
		tString = countdown.ToString();
		tDisplay.GetComponentsInChildren.<UI.Text>()[0].text = tString;
		countdown -= 1;
	}
}
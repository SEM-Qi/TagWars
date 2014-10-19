#pragma strict

var tDisplay:GameObject;
var scripts:GameObject;
private var game_over:GameOver;
private var timer:int;
private var gameTimer:float;
private var tString:String;
private var gameStart:boolean;

function StartTimer(){
	timer = 4;
	tString = "";
	InvokeRepeating("UpdateTimer", 0, 1);
}

function Start(){
	game_over = scripts.GetComponent(GameOver);
	gameStart = false;
}

function UpdateTimer(){
		if(timer == 0){
			tString = '#FIGHT';
			tDisplay.GetComponentsInChildren.<UI.Text>()[0].text = tString;
			timer -= 1;
		}else if(timer == -2){
			tDisplay.GetComponentsInChildren.<UI.Text>()[0].text = "";
			CancelInvoke();
			gameTimer = 60;
			gameStart = true;
		}else{
			tString = timer.ToString();
			tDisplay.GetComponentsInChildren.<UI.Text>()[0].text = tString;
			timer -= 1;
		}
}

function Update(){
	if (gameStart == true){
		gameTimer -= Time.deltaTime;
		if (gameTimer <= 0){
			game_over.Init();
			gameStart = false;
		}
	}
}
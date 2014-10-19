#pragma strict

// Needs to be updated with the new State system (start on BEGIN state)

//var timer:float = 7.0;
var tDisplay:GameObject;
private var timer:int;
private var tString:String;
//var tString:String;


//function Update () {
//
//
//
//
////	if (Game.state == "begin"){
////  		timer -= Time.deltaTime;
////  		tString = timer.ToString("0");
////	  	tDisplay.GetComponentsInChildren.<UI.Text>()[0].text = tString;
////	 	}
////	 	if (timer < 0.6){
////	  		timer = 0;
////	  		tString = '#FIGHT';
////	  		tDisplay.GetComponentsInChildren.<UI.Text>()[0].text = tString;
////	 	}
//}
function StartTimer(){
	timer = 4;
	tString = "";
	InvokeRepeating("UpdateTimer", 0, 1);
}

function UpdateTimer(){
		if(timer == 0){
			tString = '#FIGHT';
			tDisplay.GetComponentsInChildren.<UI.Text>()[0].text = tString;
			timer -= 1;
		}else if(timer == -1){
			tDisplay.GetComponentsInChildren.<UI.Text>()[0].text = "";
			CancelInvoke();
		}else{
			tString = timer.ToString();
			//print(timer);
			tDisplay.GetComponentsInChildren.<UI.Text>()[0].text = tString;
			timer -= 1;
		}
}




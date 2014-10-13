#pragma strict

// the InputField object handles the player input

var input_field:GameObject;
private var G:Game;
private var input = new Array("");
private var forbiden_chars:char[] = [' '[0],'#'[0],'!'[0],'$'[0],'%'[0],'^'[0],'&'[0],'*'[0],'+'[0],'.'[0]];

function Start(){
	G = GetComponent(Game);										// imports the GAME object
}

function Update () {

// STATE : can_attack =================================================================
	if(Game.state == "can_attack"){
		if(input.length <= 0) input.Push("#");
		for(var c:char in Input.inputString){
			if(ArrayUtility.IndexOf(forbiden_chars,c) == -1){ 	// if the char is not forbidden
				if(c == "\b"[0]){								// backspace
					input.Pop();								
				}else if(input.length < 10){
					input.Push(c);
				}
				input_field.GetComponent(UI.InputField).value = input.Join("");
			}
		}
		
		// charges attack
		if(Input.GetKeyDown("return")){
			G.Charging();	
		}
		
// STATE : charging =====================================================================		
	}else if(Game.state == "charging"){ 						
		// launches attack
		if (Input.GetKeyUp("return")){
			G.Attack();
		}
		
// STATE : ready ========================================================================
	}else if(Game.state == "ready"){
		input = [];
		input_field.GetComponent(UI.InputField).value = input.Join("");
		
// STATE : other ========================================================================		
	}else{
		if(Input.GetKeyDown("return")){
			GetComponent(AudioSource).Play();
		}	
	}	
}
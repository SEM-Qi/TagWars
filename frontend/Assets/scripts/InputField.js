#pragma strict

// the InputField object handles the player input

var input_field:UI.Text;
var input_field_back:UI.Text;

private var G:Game;
private var input = new Array("");
private var forbiden_chars:char[] = [' '[0],'#'[0],'!'[0],'?'[0],'$'[0],'%'[0],'^'[0],'&'[0],'*'[0],'+'[0],'.'[0]];
private var correct_input:boolean = false;


function Start(){
	G = GetComponent(Game);										// imports the GAME object
}

function Update () {

// STATE : can_attack =================================================================
	if(Game.state == "can_attack"){
	
		if(input.length <= 0) input.Push("#");
		if(input.length == 1) input_field.color = Color.black;
		
		for(var c:char in Input.inputString){
			if(!InArray(forbiden_chars,c)){ 					// if the char is not forbidden
				if(c == "\b"[0] && input.length > 1){			// backspace
					input.Pop();								
				}else if(c == "\n"[0] || c=="\r"[0] || c== "\b"[0]){			// if player inputs enter (do nothing)
				}else if(input.length < 15){					// limit to 15 char
					input.Push(c);
				}else{
				}
				// check if the input is valid
				var word:String = input.Join("");
				input_field.text = word;
				if(word == "#word"){
					input_field.color = Color(0.09,0.62,0.51);
					correct_input = true;
				}else{
					input_field.color = Color(0.75,0.22,0.17);
					correct_input = false;
				}
			}
		}
		
		// charges attack
		if(Input.GetKeyDown("return") && correct_input){
			input_field_back.text = input.Join("");
			correct_input = false;
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
		input_field.text = "#";
		
// STATE : other ========================================================================		
	}else{
		if(Input.GetKeyDown("return")){
			GetComponent(AudioSource).Play();
		}	
	}	
}

// HELPER FUNCTION ArrayUtility.indexof WOULD BE BETTER BUT IT ISN'T AVAILABLE 
function InArray(arr:char[],element:char){
	var inArray:boolean = false;
	for(var c:char in arr){
		if (c == element){
			inArray = true;
		}
	}
	return inArray;
}
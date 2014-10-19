#pragma strict

// the InputField object handles the player input

var input_field:UI.Text;
var input_field_back:UI.Text;

private var attack:Attack;

private var input = new Array("");
private var forbiden_chars:char[] = [' '[0],'#'[0],'!'[0],'?'[0],'$'[0],'%'[0],'^'[0],'&'[0],'*'[0],'+'[0],'.'[0]];
private var correct_input:boolean = false;

function Start(){
	attack = GetComponent(Attack);
	// TODO move this to SetReady class
	input_field.text = "#";
	input = [];
}

function Update () {

// STATE : ready =================================================================
	if(Game.state == "ready"){
		if(input.length == 0) input.Push("#");
		
		for(var c:char in Input.inputString){
			if(!Helper.InArray(forbiden_chars,c)){ 								// if the char is not forbidden
				if(c == "\b"[0] && input.length > 1){							// backspace
					input.Pop();								
				// if the players input is shorter then 15 and he doesn't inputs 'enter' or 'space'
				}else if(input.length < 15 && c != "\n"[0] && c != "\r"[0] && c != "\b"[0]){									
					input.Push(c);
				}
				
				// check if the input is valid
				var word:String = input.Join("");
				input_field.text = word;
				if(word == "#word"){											// TODO JSON parser connection
					input_field.color = Color(0.09,0.62,0.51);					// TODO save Color presets in the Helper class
					correct_input = true;
				}else if(word == "#"){
					input_field.color = Color.black;
					correct_input = false;
				}else{
					input_field.color = Color(0.75,0.22,0.17);
					correct_input = false;
				}
			}
		}

		if(Input.GetKeyDown("return") && correct_input){
			input_field_back.text = input.Join("");		
			correct_input = false;
			attack.Charge();													// charges attack
		}
		
// STATE : charging =====================================================================		
	}else if(Game.state == "charging"){ 						
		if (Input.GetKeyUp("return")){
			attack.Release(); 													// launches attack
			
			// TODO move this to SetReady class (reset values)
			input_field.color = Color.black;
			input_field.text = "#";	//TODO BUG: should happen only once animation is done								
			input = [];				
		}

// STATE : other ========================================================================		
	}else{
		if(Input.GetKeyDown("return")){
			GetComponent(AudioSource).Play();									// plays denying sound
		}	
	}	
}
#pragma strict

var game_ui:GameObject;
var input_field:GameObject;
var anim:Animator;
var charged:boolean;

static var state:String; // flags the current game state

function Start () {
	anim = game_ui.GetComponent(Animator);
}

function Update () {
	if(state == "can_attack"){
		// charges attack
		if(Input.GetKeyDown("return")){
			anim.SetTrigger("charging");
			charged = true;	
		}
		
		// launches attack
		if (Input.GetKeyUp("return") && charged){
			charged = false;
			anim.SetTrigger("release");
			input_field.GetComponent(UI.InputField).interactable = false;
			state = "can_not_attack";
			Attack();
			Ready();
		}
	}else{
		if(Input.GetKeyDown("return")){
			GetComponent(AudioSource).Play();
		}	
	}	
}

//FUTURE FUNCTIONALITY
// --------------------
//function MainMenu(){
//	state = "main_menu";
//	print(state);
//	anim.SetTrigger("intro");
//	if(true){
//		Connecting();
//	}
//}
//
//function Connecting(){
//	state = "connecting";
//	anim.SetTrigger("connecting");
//	if(true){
//		Begin();
//	}
//}
//------------------------

function Begin(){
	state = "start";
	anim.SetTrigger("start");
	Health.Start();
	
		yield WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);	// waits until the start animation is over
		yield WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
		Ready();
}

function Attack(){
				yield WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
			Health.playerA_health += 0.1;
}

function Ready(){
	state = "ready";
	anim.SetTrigger("ready");
		yield WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
		state = "can_attack";
		input_field.GetComponent(UI.InputField).value = "";
		input_field.GetComponent(UI.InputField).interactable = false;
		
		//TRYING TO FOCUS ON THE INPUTFIELD
		//EventSystem.current.SetSelectedGameObject(input_field, null);
		//input_field.OnPointerClick(new PointerEventData(EventSystems.current));
}


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

function Exit(){
	Application.Quit();
}
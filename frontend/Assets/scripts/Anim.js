#pragma strict

// Objects with Animator components
var game_ui:GameObject;
var enemy_field:GameObject;

static var ui_anim:Animator;
static var enemy_anim:Animator;

function Start () {
	ui_anim = game_ui.GetComponent(Animator);
	enemy_anim = enemy_field.GetComponent(Animator);
}

// Animation Triggers Wrapper
static function trigger(trigger:String){
//	switch(trigger) {
//       	case "enemy_attack":
//       		enemy_anim.SetTrigger(trigger);
//       		break;
//    	default:
//    		ui_anim.SetTrigger(trigger);	
//	}
	if(trigger == "enemy_attack" || trigger=="enemy_cancel" || trigger=="enemy_release"){

		enemy_anim.SetTrigger(trigger);

	}else{

		ui_anim.SetTrigger(trigger);

	}


}

static function Boolean(bool:String, bool2:boolean){

	enemy_anim.SetBool(bool,bool2);

}

// Animation Length Wrapper
function AnimationLength():int{
	return ui_anim.GetCurrentAnimatorStateInfo(0).length;
}


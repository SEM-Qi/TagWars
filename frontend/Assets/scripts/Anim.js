#pragma strict

/* The ANIM class is a wrapper for the Unity.Animator object
it stores all Animators in our project */

// game objects with animators
var game_ui:GameObject;
var enemy_field:GameObject;

private static var animators = {};

function Awake () {
	// TODO fix downcast warning
	animators["ui_anim"] = game_ui.GetComponent(Animator);
	animators["enemy_anim"] = enemy_field.GetComponent(Animator);
}

// Getters & Setters --------------------------
static function SetTrigger(animator:String, trigger:String){
	var anim:Animator = animators[animator];
	if(anim != null){
		anim.SetTrigger(trigger);
	}else{
		throw new System.Exception("Unknown Animator");
	}
}

static function SetBool(animator:String, bool:String, val:boolean){
	var anim:Animator = animators[animator];
	if(anim != null){
		anim.SetBool(bool,val);
	}else{
		throw new System.Exception("Unknown Animator");
	}
}

static function GetAnimationLength(animator:String):int{
	var anim:Animator = animators[animator];
	if(anim != null){
		return anim.GetCurrentAnimatorStateInfo(0).length;
	}else{
		throw new System.Exception("Unknown Animator");
	}
}
// ----------------------------------------------------

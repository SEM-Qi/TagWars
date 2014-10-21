#pragma strict

/* The Anim class is a wrapper for the Unity.Animator object 
it stores all Animators in our project */

// Objects with Animator components
var game_ui:GameObject;
var enemy_field:GameObject;

static var animators = {};

function Start () {
	// TODO fix downcast
	animators["ui_anim"] = game_ui.GetComponent(Animator);
	animators["enemy_anim"] = enemy_field.GetComponent(Animator);
}

// Animation Triggers/Bools Wrapper
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

// Animation Length Wrapper
static function AnimationLength(animator:String):int{
	var anim:Animator = animators[animator];
	if(anim != null){
		return anim.GetCurrentAnimatorStateInfo(0).length;
	}else{
		throw new System.Exception("Unknown Animator");
	}
}


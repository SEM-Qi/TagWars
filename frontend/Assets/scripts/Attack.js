#pragma strict

var anim:Animator;
var ui:GameObject;

function Start () {
	anim = ui.GetComponent("Animator");
}

function Update () {
	if(Input.GetKeyDown("return")){
		anim.SetBool("enter_pressed",true);
	}
	if (Input.GetKeyUp("return")){
		anim.SetBool("enter_pressed",false);
	}
}
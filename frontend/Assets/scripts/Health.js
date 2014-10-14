#pragma strict

static var playerA_health:float;
static var playerB_health:float;
var playerA_healthbar:GameObject;
var playerB_healthbar:GameObject;

static function Start () {
	playerA_health = 0;
	playerB_health = 0;
}

function Update () {
	UpdateImage();
}

function UpdateImage(){
	playerA_healthbar.GetComponent("RectTransform").transform.localScale = Vector3(1,playerA_health,1);
	playerB_healthbar.GetComponent("RectTransform").transform.localScale = Vector3(1,playerB_health,1);
}


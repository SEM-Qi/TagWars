#pragma strict

var player_healthbar:GameObject;
var opponent_healthbar:GameObject;

static var player_health:float;
static var opponent_health:float;

static function Start () {
	player_health = 0;
	opponent_health = 0;
}

function Update () {
	player_healthbar.GetComponent("RectTransform").transform.localScale = Vector3(1,player_health,1);
	opponent_healthbar.GetComponent("RectTransform").transform.localScale = Vector3(1,opponent_health,1);
}


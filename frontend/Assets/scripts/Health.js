#pragma strict

var player_healthbar:GameObject;
var opponent_healthbar:GameObject;

private static var player_health:int;
private static var opponent_health:int;

static function Start () {
	player_health = 100;
	opponent_health = 100;
}

function Update () {
	if (Game.state == "release" || Game.state == "begin"){
		opponent_healthbar.GetComponent("RectTransform").transform.localScale = Vector3(1,Map(opponent_health),1);
	}
	player_healthbar.GetComponent("RectTransform").transform.localScale = Vector3(1,Map(player_health),1); //REVISIT WITH MULTIPLAYER FUNCTIONALITY
	
}

function Map(map_health:int):float{
	var mapped_health:float;
	mapped_health = map_health;
	mapped_health = (((mapped_health/100)-1)*-1);
	return mapped_health;
}

static function GetPlayerHealth():int{
	return player_health;
}

static function GetOpponentHealth():int{
	return opponent_health;
}

static function SetPlayerHealth(health:int){
	player_health = health;
}

static function SetOpponentHealth(health:int){
	opponent_health = health;
}
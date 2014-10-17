#pragma strict

import SimpleJSON;
import System.IO;

private var player_name:String;
private var opponent_name:String;
private var available_tags = new Array();

function Start() {	
	available_tags = nodeToArray(JSON.Parse(Read("/fake_data/available_tags.json"))["available"]);
	
	var test_message = JSON.Parse(Read("/fake_data/test_message.json"));
	
	var player = JSON.Parse(Read("/fake_data/player02_data.json"));
	player_name = player["name"].Value;
	print(available_tags);
	
	var opponent = JSON.Parse(Read("/fake_data/player01_data.json"));
	opponent_name = opponent["name"].Value;
	
//	print(json["distribution"][2]["ammount"].Value);
//	print(json["distribution"][2]["content"][0].Value);
}

function nodeToArray(node:JSONNode){
	var arr = new Array();
	for(var i:int = 0; i < node.Count; i++){
		arr.Push(node[i]);
	}
	return arr;
}

function Parse(path:String){
	return JSON.Parse(Read(path));
}

function Read(path:String){
	var sr:StreamReader = new StreamReader(Application.dataPath + path);
	var content:String = sr.ReadToEnd();
	sr.Close();
	return content;	
}

function getPlayerName():String{
	return player_name;
}

function getOpponentName():String{
	return opponent_name;
}

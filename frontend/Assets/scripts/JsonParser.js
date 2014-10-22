#pragma strict

import SimpleJSON;
import System.IO;

private var player_name:String;
private var opponent_name:String;
private var available_tags:String[];
private var test_message:JSONNode;

function Start() {	
	// TODO replace with backend connection
	available_tags = nodeToStringArray(JSON.Parse(Read("/fake_data/available_tags.json"))["available"]);
	
	 test_message = JSON.Parse(Read("/fake_data/test_message.json"));
	
	var player = JSON.Parse(Read("/fake_data/player02_data.json"));
	player_name = player["name"].Value;
	
	var opponent = JSON.Parse(Read("/fake_data/player01_data.json"));
	opponent_name = opponent["name"].Value;
}

// Getters & Setters --------------------------
function getPlayerName():String{
	return player_name;
}

function getOpponentName():String{
	return opponent_name;
}

function getAvailableTags():String[]{
	return available_tags;
}

function getAmount(sec:int):int{
	return int.Parse(test_message["distribution"][sec]["ammount"].Value);
}

function getDistributionLength(){
	return test_message["distribution"].Count;
}
// ----------------------------------------------

function nodeToArray(node:JSONNode){
	var arr = new Array();
	for(var i:int = 0; i < node.Count; i++){
		arr.Push(node[i]);
	}
	return arr;
}

function nodeToStringArray(node:JSONNode):String[]{
	var arr:String[] = new String[node.Count];
	for(var i:int = 0; i < node.Count; i++){
		arr[i] = node[i].Value;
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



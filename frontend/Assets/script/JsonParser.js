#pragma strict

import SimpleJSON;
import System.IO;

var fileName:String;

function Start() {
	var json = JSON.Parse(Read());
	print(json["id"].Value);
	print(json["distribution"][2]["ammount"].Value);
	print(json["distribution"][2]["content"][0].Value);
}

function Read(){
	var sr:StreamReader = new StreamReader(Application.dataPath + "/script/" + fileName);
	var content:String = sr.ReadToEnd();
	sr.Close();
	return content;	
}

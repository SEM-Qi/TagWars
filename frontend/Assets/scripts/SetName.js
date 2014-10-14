#pragma strict

var pName:GameObject;
var oName:GameObject;

var playerName:String;
var opponentName:String;

function Start () {
	pName.GetComponentsInChildren.<UI.Text>()[0].text = playerName;
	oName.GetComponentsInChildren.<UI.Text>()[0].text = opponentName;
}
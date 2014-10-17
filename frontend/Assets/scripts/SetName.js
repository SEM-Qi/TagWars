#pragma strict

var pName:GameObject;
var oName:GameObject;

function Start () {
	var jp = GetComponent(JsonParser);
	pName.GetComponentsInChildren.<UI.Text>()[0].text = jp.getPlayerName();
	oName.GetComponentsInChildren.<UI.Text>()[0].text = jp.getOpponentName();
}
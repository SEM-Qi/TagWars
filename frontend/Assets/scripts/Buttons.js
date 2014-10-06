#pragma strict

var tag01:GameObject;
var tag02:GameObject;
var tag03:GameObject;
var tag04:GameObject;
var tag05:GameObject;
var tag06:GameObject;

var val01:String;
var val02:String;
var val03:String;
var val04:String;
var val05:String;
var val06:String;

function Start () {
	tag01.GetComponent(UI.Button).onClick.AddListener(function(){LaunchTag(val01);});
	tag01.GetComponentsInChildren.<UI.Text>()[0].text = "#" + val01;
	tag02.GetComponent(UI.Button).onClick.AddListener(function(){LaunchTag(val02);});
	tag02.GetComponentsInChildren.<UI.Text>()[0].text = "#" + val02;
	tag03.GetComponent(UI.Button).onClick.AddListener(function(){LaunchTag(val03);});
	tag03.GetComponentsInChildren.<UI.Text>()[0].text = "#" + val03;
	tag04.GetComponent(UI.Button).onClick.AddListener(function(){LaunchTag(val04);});
	tag04.GetComponentsInChildren.<UI.Text>()[0].text = "#" + val04;
	tag05.GetComponent(UI.Button).onClick.AddListener(function(){LaunchTag(val05);});
	tag05.GetComponentsInChildren.<UI.Text>()[0].text = "#" + val05;
	tag06.GetComponent(UI.Button).onClick.AddListener(function(){LaunchTag(val06);});
	tag06.GetComponentsInChildren.<UI.Text>()[0].text = "#" + val06;
}

function LaunchTag(val){
	print(val);
}



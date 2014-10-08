#pragma strict

var timer:float = 5.0;
var tDisplay:GameObject;
var tString:String;

function Update () {
 if(timer > 0.5){
  timer -= Time.deltaTime;
  tString = timer.ToString("0");
  tDisplay.GetComponentsInChildren.<UI.Text>()[0].text = tString;
 }
 if(timer <= 0.5){
  timer = 0;
  tString = '#FIGHT';
  tDisplay.GetComponentsInChildren.<UI.Text>()[0].text = tString;
 }
}
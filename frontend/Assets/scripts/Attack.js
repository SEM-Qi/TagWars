#pragma strict
var strenght = 0;

function Update () {
	if(Input.GetKey("return")){
		strenght++;
	}
	if (Input.GetKeyUp("return")){ 
		print("attack!! " + strenght);
		strenght = 0;
	}
}
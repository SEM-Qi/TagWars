#pragma strict

var input_field:GameObject;

private var anim:Anim; 
private var damage:int;
private var js:JsonParser;

private var charge_time:int;

function Start(){
	js = GetComponent(JsonParser);
	anim = GetComponent(Anim);
}

function Charge(){
	charge_time = 0;
	Game.SetState("charging");
	Anim.trigger("charging");
	InvokeRepeating("CalculateDamage",1,1);
}

function Release(){
	// TODO code for dealing damage
	CancelInvoke();  								// stop the damage increase
	Game.SetState("release");
	Anim.trigger("release");
	yield WaitForSeconds(anim.AnimationLength()); 	// TODO USE ANIMATION EVENT INSTEAD
	Health.opponent_health += 0.1;
	damage = 0; 									// resets the damage
}

function Cancel(){
	Game.SetState("cancel");
	Anim.trigger("charging");
	yield WaitForSeconds(1);
	Anim.trigger("cancel");
}

function CalculateDamage(){
	if(charge_time < js.getDistributionLength()){
		damage += js.getAmount(charge_time);		// gets the damage from the Json file
		print("damage: " + damage);
		charge_time++;
		ResizeAttack(damage);
	}else{
		CancelInvoke();
	}
}

function ResizeAttack(val:float){
	val = val*2/100;
	//input_field.GetComponent(RectTransform).sizeDelta = new Vector2(100,100);
	input_field.GetComponent(RectTransform).sizeDelta = new Vector2(280+280*val,150+150*val);
	print("sizedelta: " + input_field.GetComponent(RectTransform).rect.height); //= new Vector2(280*val,150*val);
	print("val: " + val);
}


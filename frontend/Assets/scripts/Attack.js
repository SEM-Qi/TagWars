#pragma strict

var input_field:GameObject;
private var enemy_attack:EnemyAttack;

private var anim:Anim; 
private var damage:int;
private var js:JsonParser;

private var charge_time:int;

function Start(){
	js = GetComponent(JsonParser);
	anim = GetComponent(Anim);
	enemy_attack = GetComponent(EnemyAttack);

}

function Charge(){
	charge_time = 0;
	Game.SetState("charging");
	Anim.SetTrigger("ui_anim","charging");
	InvokeRepeating("CalculateDamage",1,1);
}

function Release(){
	// TODO code for dealing damage
	CancelInvoke();  								// stop the damage increase
	Game.SetState("release");
	Anim.SetTrigger("ui_anim","release");
	yield WaitForSeconds(Anim.AnimationLength("ui_anim")); 	// TODO USE ANIMATION EVENT INSTEAD
	Health.opponent_health += 0.1;
	damage = 0; 									// resets the damage
}

function Cancel(){
	Game.SetState("cancel");
	Anim.SetTrigger("ui_anim","charging");
	yield WaitForSeconds(1);
	Anim.SetTrigger("ui_anim","cancel");
	enemy_attack.Cancel();
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


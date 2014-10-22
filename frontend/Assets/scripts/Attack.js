#pragma strict

var input_field:GameObject;

private var enemy_attack:EnemyAttack;
private var jp:JsonParser;

private var charge_time:int;
private var damage:int;

function Start(){
	jp = GetComponent(JsonParser);
	enemy_attack = GetComponent(EnemyAttack);
}

function Charge(){
	charge_time = 0;
	Game.SetState("charging");
	Anim.SetTrigger("ui_anim","charging");
	InvokeRepeating("CalculateDamage",0.35,1);
}

function CalculateDamage(){
	if(charge_time < jp.getDistributionLength()){
		damage += jp.getAmount(charge_time);					// gets the damage from the Json file
		charge_time++;
		ResizeAttack(damage);
	}else{
		CancelInvoke();
	}
}

function Release(){
	CancelInvoke();  											// stop the damage increase
	Game.SetState("release");
	Anim.SetTrigger("ui_anim","release");
	yield WaitForSeconds(Anim.GetAnimationLength("ui_anim")); 	// TODO USE ANIMATION EVENT INSTEAD		
	ChangeOpponentHealth(damage);								// changes opponents health according to damage value
	damage = 0;
}

function ChangeOpponentHealth(damage:int){
	Health.SetOpponentHealth(Health.GetOpponentHealth() - damage);
}

function Cancel(){
	Game.SetState("cancel");
	Anim.SetTrigger("ui_anim","charging");
	yield WaitForSeconds(1);
	Anim.SetTrigger("ui_anim","cancel");
	enemy_attack.Cancel();
}

function ResizeAttack(val:float){
	val = val*2/100;
	//input_field.GetComponent(RectTransform).sizeDelta = new Vector2(100,100);
	input_field.GetComponent(RectTransform).sizeDelta = new Vector2(280+280*val,150+150*val);
//	print("sizedelta: " + input_field.GetComponent(RectTransform).rect.height); //= new Vector2(280*val,150*val);
//	print("val: " + val);
}



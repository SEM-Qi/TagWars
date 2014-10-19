#pragma strict

private var anim:Anim; 
private var damage:int;
private var js:JsonParser;

private var second:int;

function Start(){
	js = GetComponent(JsonParser);
	anim = GetComponent(Anim);
}

function Charge(){
	// TODO code for damage calculation
	second = 0;
	Game.SetState("charging");
	Anim.trigger("charging");
	InvokeRepeating("CalculateDamage",1,1);
}

function Release(){
	CancelInvoke();  // stop the damage increase
	
	// TODO code for damage generation
	Game.SetState("release");
	Anim.trigger("release");
	yield WaitForSeconds(anim.AnimationLength()); // TODO USE ANIMATION EVENT INSTEAD
	Health.opponent_health += 0.1;
	damage = 0; 	// resets the damage
}

function CalculateDamage(){
	if(second < js.getDistributionLength()){
		damage += js.getAmount(second);
		print(damage);
		second++;
	}else{
		CancelInvoke();
	}
}


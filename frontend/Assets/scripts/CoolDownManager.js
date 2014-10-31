#pragma strict

//var cooldown_bar:GameObject;
//var parent_object:GameObject;
//var cooldown_ui:GameObject;
//var cooldown_text:UI.Text;

private var cooldowns = new Array();

class CoolDown {
	var cooldown_name:String;
	var cooldown_length:float;
	
	function CoolDown(name:String,length:int){
		cooldown_name = name;
		cooldown_length = parseFloat(length);
	}
}

function GetUsedTags(){
	var used_tags = new Array();
	for(var i:int; i < cooldowns.length; i++){
		var c:CoolDown = cooldowns[i];
		used_tags.Push(c.cooldown_name);
	}
	return used_tags;
}

function AddCooldown(name:String,length:int){
	cooldowns.Push(new CoolDown(name,length));
	AddBar(name);
}

function Update(){
	for(var i:int; i < cooldowns.length; i++){
		var c:CoolDown = cooldowns[i];
		if(c.cooldown_length <= 0){
			cooldowns.RemoveAt(i);
			print("removed: " + c.cooldown_name);
		}else{
			c.cooldown_length -= Time.deltaTime;
			print(c.cooldown_length);
		}
	} 
}

function AddBar(name){
//	var parent_transform:Transform = parent_object.GetComponent(Transform);
//	var test:GameObject = Instantiate(cooldown_bar);
//	test.transform.SetParent(parent_transform,false);
}
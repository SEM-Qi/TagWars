#pragma strict
// Helper functions

//ArrayUtility.indexof WOULD BE BETTER BUT IT ISN'T AVAILABLE 
static function InArray(arr:char[],element:char){
	var inArray:boolean = false;
	for(var c:char in arr){
		if (c == element){
			inArray = true;
		}
	}
	return inArray;
}

static function InArray(arr:String[],element:String){
	var inArray:boolean = false;
	for(var c:String in arr){
		if (c == element){
			inArray = true;
		}
	}
	return inArray;
}

static function Toggle(element:GameObject){
	if(element.activeSelf){
		if (Input.GetKeyDown("escape")){
			element.SetActive(false);
		}
	}else{
		if (Input.GetKeyDown("escape")){
			element.SetActive(true);
		}
	}
}



function selectionSort(array) {

	//convert this first for-loop into while loop to play animations
	var i = 0;
	var doneAnimating = true;

	for (var i = 0; i < array.length; i++) {
		var currValue = array[i];

		for (var j = i+1; j < array.length; j++) {
			var newValue = array[j];
			console.log("current value: "+currValue);
			console.log("new value: "+newValue);
			
			if (currValue > newValue) {
				array[i] = newValue;
				array[j] = currValue;
				currValue = newValue;
				
				// setTimeout(function() {
				// 	console.log('animation at play...');
				// }, 1000);
				//todo: play animation here...

				console.log(array);
				// break;
			}
		}
	}

	return array;
}


var arr = [5,1,3,2,4];

console.log(selectionSort(arr));
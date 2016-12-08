function wrapValue(n) {
	var localVariable = n;
	return function() { return localVariable; };
}

console.log(wrapValue(5)());
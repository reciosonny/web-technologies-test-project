var safeMode = true;
var launchMissiles = function(value) {
	// missileSystem.launch("now");
	console.log('function 1');
};
if (safeMode)
	launchMissiles = function(value) {/* do nothing */
		console.log('function 2');
	};

launchMissiles(123);
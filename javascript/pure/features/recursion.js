function test(num) {
	if (num == 0)
		return 0;

	return num + test(num-1);
}

console.log(test(5));
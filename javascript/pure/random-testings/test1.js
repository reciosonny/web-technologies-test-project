var arr = [1,2,3,5];
var emp = [
	{fname: "Sonny", lname: "Recio", salary: 120000, increase:55000, deductions: 25000, currency:"php"},
	{fname: "Marijn", lname: "Haverbeke", salary: 5500, increase:500, deductions: 2500, currency:"EUR"}
];

function sum(a, b) {
	return a + b;
}
function difference(a,b) {
	return a - b;
}

function map(x) {
	return x.salary + x.increase - x.deductions;
}

console.log(arr.reduce(sum));
console.log(emp.map(map));
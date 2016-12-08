var anObject = {left: 1, right: 2};
console.log(anObject.left);
// . 1
delete anObject.left;
// anObject.left = undefined;
console.log(anObject.left);
// . undefined
console.log("left" in anObject);
// . false
console.log("right" in anObject);
// . true
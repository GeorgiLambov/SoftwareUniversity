var globalVariable = 'Global string';

function outerFunction() {
    var privateVar = globalVariable;

    function innerFunction() {
        var innerVar = privateVar;
		return innerVar;
    }

    return innerFunction();
}

var result = outerFunction();
console.log(result); // Global string
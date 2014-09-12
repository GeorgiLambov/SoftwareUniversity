function Solve(input) {
    var digits = input.map(Number);
    var n = digits[0];
    var maxSum = Number.NEGATIVE_INFINITY;

    for (var i = 1; i < digits.length; i++) {
        var sum = 0;
        for (var j = i; j < digits.length; j++) {
            sum = sum + digits[j];
            if (sum > maxSum) {
                maxSum = sum;
            }
        }
    }
    return (maxSum);
}


//Solve([9, -9, -8, -8, -7, -6, -5, -1, -7, -6]);
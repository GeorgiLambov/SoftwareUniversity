function Solve(input) {
    var digits = input[0].split(' ');
    var assrArray = [];
    var inputOrder = [];
    for (var i = 0; i < digits.length - 1; i++) {
        var coupNum = '' + digits[i] + ' ' + digits[i + 1];
        
        if (!(coupNum in assrArray)) {
            assrArray[coupNum] = 1;
            inputOrder.push(coupNum);
        } else {
            assrArray[coupNum] += 1;
        }
    }
    //print
    for (var i = 0; i < inputOrder.length; i++) {
        var tempKey = inputOrder[i];
        var frequencyOfappearance = ((assrArray[tempKey]) / (digits.length - 1)) * 100;
        console.log("%s -> %s%", tempKey, frequencyOfappearance.toFixed(2));
    }
}

Solve(['3 4 2 3 4 2 1 12 2 3 4']);
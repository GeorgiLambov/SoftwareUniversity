function biggestTableRow(input) {
    var storeObj = [];
    var isAnswer = true;
    for (var i = 2; i < input.length - 1; i++) {
        var rowStr = input[i];
        var re = />[^><]+</g,
            matchs = rowStr.match(re);
        var resultTemp = [];
        for (var k in matchs) {
            resultTemp.push(matchs[k].replace(/[<>\s]/g, ''));
        }
        
        storeObj.push(resultTemp);
    }
    
    var outputSTR = '';
    var maxSum = -9007199254740992;
    for (var j = 0; j < storeObj.length; j++) {
        var sumOfRowEl = 0;
        
        for (var f = 1; f < storeObj[j].length; f++) {
            if (storeObj[j][f] !== '-') {
                var sum = Number(storeObj[j][f]);
                sumOfRowEl += sum;
                isAnswer = false;
            }
        }
        if (sumOfRowEl > maxSum) {
            maxSum = sumOfRowEl;
            outputSTR = sumOfRowEl + " = ";
            for (var e = 1; e < storeObj[j].length; e++) {
                if (storeObj[j][e] !== '-') {
                    outputSTR += storeObj[j][e] + ' + ';
                }
            }
            outputSTR = outputSTR.slice(0, -3);

        }

    }
    if (isAnswer) {
        outputSTR = "no data"
    }
    console.log(outputSTR);
}
biggestTableRow(['<table>',
'<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
'<tr><td>Sofia</td><td>12850</td><td>-560</td><td>20833</td></tr>',
'<tr><td>Rousse</td><td>-</td><td>50000.0</td><td>-</td></tr>',
'<tr><td>Bourgas</td><td>25000</td><td>25000</td><td>-</td></tr>',
'</table>']);
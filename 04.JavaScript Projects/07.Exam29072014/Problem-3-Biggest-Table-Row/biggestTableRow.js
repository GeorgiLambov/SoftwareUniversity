function biggestTableRow(table) {
    var maxSum = Number.NEGATIVE_INFINITY;
    for (var lineIndex = 2; lineIndex < table.length - 1; lineIndex++) {
        var row = table[lineIndex];
        var cells = row.match(/<td>(.*?)<\/td>/g);
        var sum = 0, values = [];
        for (var c = 1; c < cells.length; c++) {
            var cellValue = cells[c];
            cellValue = cellValue.substring('<td>'.length);
            cellValue = cellValue.substring(0, cellValue.length - '</td>'.length);
            var num = Number(cellValue.trim());
            if (! isNaN(num)) {
                values.push(cellValue);
                sum += num;
            }
        }
        if (sum > maxSum && values.length > 0) {
            maxSum = sum;
            var maxSumDetails = values.join(' + ');
        }
    }
    if (maxSum != Number.NEGATIVE_INFINITY) {
        console.log(maxSum + ' = ' + maxSumDetails);
    } else {
        console.log("no data");
    }
}


// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

var arr = [];
require('readline').createInterface({
    input: process.stdin,
    output: process.stdout
}).on('line', function (line) {
    arr.push(line);
}).on('close', function () {
    biggestTableRow(arr);
});

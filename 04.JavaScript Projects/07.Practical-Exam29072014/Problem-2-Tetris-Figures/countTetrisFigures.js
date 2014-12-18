function countTetrisFigures(gameField) {
    var figureI = [
        "o",
        "o",
        "o",
        "o",
    ];
    var figureL = [
        "o-",
        "o-",
        "oo",
    ];
    var figureJ = [
        "-o",
        "-o",
        "oo",
    ];
    var figureO = [
        "oo",
        "oo",
    ];
    var figureZ = [
        "oo-",
        "-oo",
    ];
    var figureS = [
        "-oo",
        "oo-",
    ];
    var figureT = [
        "ooo",
        "-o-",
    ];    
    
    var result = {
        "I": countFits(gameField, figureI),
        "L": countFits(gameField, figureL),
        "J": countFits(gameField, figureJ),
        "O": countFits(gameField, figureO),
        "Z": countFits(gameField, figureZ),
        "S": countFits(gameField, figureS),
        "T": countFits(gameField, figureT),
    };

    console.log(JSON.stringify(result));

    function countFits(field, figure) {
        var figureWidth = figure[0].length;
        var figureHeight = figure.length;
        var fieldWidth = field[0].length;
        var fieldHeight = field.length;
        fitsCount = 0;
        for (var startRow = 0; startRow <= fieldHeight - figureHeight; startRow++) {
            for (var startCol = 0; startCol <= fieldWidth - figureWidth; startCol++) {
                if (isFit(field, figure, startRow, startCol)) {
                    fitsCount++;
                }                
            }
        }
        return fitsCount;
    }

    function isFit(field, figure, startRow, startCol) {
        var figureWidth = figure[0].length;
        var figureHeight = figure.length;
        for (var row = 0; row < figureHeight; row++) {
            for (var col = 0; col < figureWidth; col++) {
                if (figure[row][col] == 'o' && field[row + startRow][col + startCol] != 'o') {
                    return false;
                }
            }
        }
        return true;
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
    countTetrisFigures(arr);
});

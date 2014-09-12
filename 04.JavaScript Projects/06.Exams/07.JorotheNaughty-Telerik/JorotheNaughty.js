function Solve(input) {
    var rowsColsJumps = parseNumbers(input[0]);
    var startPosition = parseNumbers(input[1]);


    var rows = rowsColsJumps[0];
    var cols = rowsColsJumps[1];
    var jumps = rowsColsJumps[2];

    var currentRow = startPosition[0];
    var currentCol = startPosition[1];

    return getAnswer();

    function getAnswer() {
        var field = initField();
        var jumps = readJumps();

        var jumpsIndex = 0;
        var escape = false;
        var sumOfNumbers = 0;
        var totalJumps = 0;
        while (true) {
            if (currentRow < 0 || currentRow >= rows || currentCol < 0 || currentCol >= cols) {
                escape = true;
                break;
            }
            if (field[currentRow][currentCol] === 'x') {
                escape = false;
                break;
            }
            sumOfNumbers += field[currentRow][currentCol];
            totalJumps++;
            var curentJump = jumps[jumpsIndex++];
            if (jumpsIndex >= jumps.length) {
                jumpsIndex = 0;
            }

            field[currentRow][currentCol] = 'x';

            currentRow += curentJump.row;
            currentCol += curentJump.col;
        }
        return escape
            ? 'escaped ' + sumOfNumbers
            : 'cought ' + totalJumps;
    }

    function parseNumbers(input) {
        return input.split(' ').map(Number);
    }

    function readJumps() {
        var jumps = [];
        for (var i = 2; i < input.length; i++) {
            var parseJump = parseNumbers(input[i]);
            var currentJump = {
                row: parseJump[0],
                col: parseJump[1]
            };
            jumps.push(currentJump);
        }

        return jumps;
    }

    function initField() {
        var field = [];
        var counter = 1;
        for (var i = 0; i < rows; i++) {
            field[i] = [];
            for (var j = 0; j < cols; j++) {
                field[i][j] = counter++;
            }
        }
        return field;
    }
}

Solve(['6 7 3',
'0 0',
'2 2',
'-2 2',
'3 -1'
]);
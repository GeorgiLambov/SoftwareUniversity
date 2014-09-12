var paintedFields;
var contentFields;
var winningCombos;
var turn = 0;
var theField;
var c;
var cxt;
var squaresFilled = 0;
var plAgain;

window.onload = function () {
    paintedFields = new Array();
    contentFields = new Array();
    winningCombos = [[0, 1, 2], [3, 4, 5], [6, 7, 8], [0, 3, 6], [1, 4, 7], [2, 5, 8], [0, 4, 8], [2, 4, 6]]; //creating all winning combos

    for (var l = 0; l <= 8; l++) {
        paintedFields[l] = false;
        contentFields[l] = '';
    }
}

function fieldClicked(fieldNumber) {
    theField = "field-" + fieldNumber;
    c = document.getElementById(theField);
    cxt = c.getContext("2d");

    if (paintedFields[fieldNumber - 1] == false) {
        if (turn % 2 == 0) { // Player One Moves
            cxt.beginPath();
            cxt.moveTo(10, 10);
            cxt.lineTo(40, 40);
            cxt.moveTo(40, 10);
            cxt.lineTo(10, 40);
            cxt.lineWidth = 8;
            cxt.strokeStyle = 'green';
            cxt.stroke();
            cxt.closePath();
            contentFields[fieldNumber - 1] = 'X';
        } else { // Player Two Moves
            cxt.beginPath();
            cxt.arc(25, 25, 20, 0, Math.PI * 2, true);
            cxt.lineWidth = 8;
            cxt.strokeStyle = 'red';
            cxt.stroke();
            cxt.closePath();
            contentFields[fieldNumber - 1] = 'O';

        }

        turn++; // for changing players' moves
        paintedFields[fieldNumber - 1] = true;
        squaresFilled++;
        checkForWinners(contentFields[fieldNumber - 1]);

        if (squaresFilled == 9) {
            alert("Game Over!");
            location.reload(true);
        }
    }
    else {
        alert("This field is already taken!");
    }
}

function checkForWinners(symbol) {
    for (var a = 0; a < winningCombos.length; a++) {
        if (contentFields[winningCombos[a][0]] ==
			symbol && contentFields[winningCombos[a][1]] ==
			symbol && contentFields[winningCombos[a][2]] == symbol) {
            if (symbol == 'X') {
                alert("Player One (X) Won!");
            } else {
                alert("Player Two (O) Won!");
            }

            playAgain();
        }
    }
}

function playAgain() {
    plAgain = confirm("Play again?");
    if (plAgain == true) {
        location.reload(true);
    } else {
        alert("OK! I will do it better next time!");
    }
}
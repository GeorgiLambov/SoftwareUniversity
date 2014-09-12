function solve(input) {
    //we get the input and split to array of words
    var words = input[0].split(' ');

    //we find the longest word
    var longestWord = 0;
    for (var i = 0; i < words.length; i++) {
        if (words[i].length > longestWord) {
            longestWord = words[i].length;
        }
    }

    //we put all the letters in a string
    var letters = [];
    for (var i = 0; i < longestWord; i++) {
        for (var j = 0; j < words.length; j++) {
            var currentLetterIndex = words[j].length - 1 - i;
            if (currentLetterIndex >= 0) {
                letters.push(words[j].charAt(currentLetterIndex));
            }
        }
    }

    //func for moving the chars
    function moveCharToNewPos(letters, i, numberMoves){
        var currLetter = letters[i];
        letters.splice(i, 1); //now the array letters in one char shorter
        var newPosition = (i + numberMoves) % (letters.length + 1);
        letters.splice(newPosition, 0, currLetter); //at position newPosition remove 0 items and add currLetter
    }


    //reorder letters
    for (var i = 0; i < letters.length; i++) {
        var currLetter = letters[i];
        var asciiNumber = currLetter.toLowerCase().charCodeAt(0);
        var numberMoves = asciiNumber - 97 + 1;
        moveCharToNewPos(letters, i, numberMoves);
    }

    console.log(letters.join(''));
}

//when you submit the code into the Judge system, do not copy the code below!
solve(['fun exam length']);


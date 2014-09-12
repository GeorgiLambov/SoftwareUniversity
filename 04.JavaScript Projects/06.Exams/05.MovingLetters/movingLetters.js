function Solve(input) {
    var text = input[0];
    var words = text.split(' ');
    var word = '';
    var lettersSequence = '';
    var position = 1;
    var wordMaxLen = 0;

    for (var i in words) {
        word = words[i];
        if (word.length > wordMaxLen) {
            wordMaxLen = word.length;
        }
    }
    while (wordMaxLen > 0) {
        for (var i in words) {
            word = words[i];
            if (word.length - position >= 0) {
                var letter = word[word.length - position];
                lettersSequence += letter;
            }
        }
        position++;
        wordMaxLen--;
    }
    // console.log(lettersSequence);
    lettersSequence = lettersSequence.split('');
    for (var i = 0; i < lettersSequence.length; i++) {
        var letter = lettersSequence[i];
        var asciiNumber = letter.toLowerCase().charCodeAt(0);   // vzimame nomera v Asci tablicata na malka bukva
        var numberMoves = asciiNumber - 97 + 1;
        lettersSequence.splice(i, 1);
        var newPosition = (i + numberMoves) % (lettersSequence.length + 1);   // taka prevurtame posiciite
        lettersSequence.splice(newPosition, 0, letter);
    }

    console.log(lettersSequence.join(''));

}

//Solve(['Fun exam right']);
Solve(['Hi exam']);
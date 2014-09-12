function checkBrackets(str) {
    var count = 0;
    for (var i = 0; i < str.length; i++) {
        if (str[i] == '(') {
            count++;
        }
        if (str[i] == ')') {
            count--;
        }
    }
    if (count === 0) {
        console.log("correct");
    } else {
        console.log("incorrect");
    }
}

checkBrackets('( ( a + b ) / 5 – d )');
checkBrackets(') ( a + b ) )');
checkBrackets('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )');
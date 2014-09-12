function printNumbers(n) {
    var isNum = true;
    var str = '';
    for (var i = 1; i <= n ; i++) {
        
        if (!((i % 4 == 0) || (i % 5 == 0) || (i == 1))) {
            str = str + i + ', ';
            isNum = false;
        }
    }
    str = str.slice(0, -2);
    if (isNum) {
        console.log('No');
    } else {
        console.log(str);
    }
}

printNumbers(20);
printNumbers(1);
printNumbers(13);
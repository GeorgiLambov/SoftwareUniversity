function lastDigitAsText(str) {
    str += '';
    var lastPosition = str.length - 1;
    var number = str[lastPosition];
    var lastDigit;
    switch (number) {
        case '1': lastDigit = 'One'; break;
        case '2': lastDigit = 'Two'; break;
        case '3': lastDigit = 'Three'; break;
        case '4': lastDigit = 'Four'; break;
        case '5': lastDigit = 'Five'; break;
        case '6': lastDigit = 'Six'; break;
        case '7': lastDigit = 'Seven'; break;
        case '8': lastDigit = 'Eight'; break;
        case '9': lastDigit = 'Nine'; break;
            
        default: lastDigit = 'Zero';
    }
    return lastDigit;
}

console.log(lastDigitAsText(6));
console.log(lastDigitAsText(-55));
console.log(lastDigitAsText(133));
console.log(lastDigitAsText(14567));
console.log(lastDigitAsText(9));
function bitChecker(value) {
    var isBitOne = (value >> 3) & 1;
    if (isBitOne == 1) {
        return true;
    } else {
        return false;
    }
    
}
console.log(bitChecker(333));
console.log(bitChecker(425));
console.log(bitChecker(2567564754));
console.log(bitChecker(8));
function checkDigit(value) {
    value = Math.floor(value / 100) % 10;
    if (value === 3) {
        return true;
    } else {
        return false;
    }
}

console.log(checkDigit(1235));
console.log(checkDigit(25368));
console.log(checkDigit(123456));
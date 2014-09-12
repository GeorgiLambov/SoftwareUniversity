function divisionBy3(num) {
    var sum = 0;
    while (num > 0) {
        sum += num % 10;
        num = Math.floor(num / 10);
    }
    
    if (sum % 3 == 0) {
        console.log("the number is divided by 3 without remainder");
    } else {
        console.log("the number is not divided by 3 without remainder");
    }
}
divisionBy3(12);
divisionBy3(189);
divisionBy3(591);
divisionBy3(13);
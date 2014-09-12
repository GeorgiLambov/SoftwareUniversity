function findNthDigit(arr) {
    var n = arr[0];
    var num = arr[1] + '';
    var reg = /[.-]/g;
    var strArrNum = num.replace(reg, '');
    if (strArrNum.length < n) {
        console.log("The number doesn't have %d digits", n);
    } else {
        var result = strArrNum[strArrNum.length - n];
        console.log(result);
    }
}

findNthDigit([1, 6]);
findNthDigit([2, -5.5]);
findNthDigit([6, 923456]);
findNthDigit([3, 1451.78]);
findNthDigit([6, 888.88]);
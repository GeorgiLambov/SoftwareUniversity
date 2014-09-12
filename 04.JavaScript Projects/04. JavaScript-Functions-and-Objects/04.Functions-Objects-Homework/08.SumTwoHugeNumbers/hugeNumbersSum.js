var bigInt = require('./big-integer.js');

function sumTwoHugeNumbers(value) {
    var num1 = bigInt(value[0]);
    var num2 = bigInt(value[1]);
    var result = num1.plus(num2).toString(10);
    console.log(result);
}
sumTwoHugeNumbers(['155', '65']);
sumTwoHugeNumbers(['123456789', '123456789']);
sumTwoHugeNumbers(['887987345974539', '4582796427862587']);
sumTwoHugeNumbers(['347135713985789531798031509832579382573195807',
 '817651358763158761358796358971685973163314321']);
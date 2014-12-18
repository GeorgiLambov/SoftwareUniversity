function Solve(input) {
    var text = input[0];
    var digits = text.split(/[^0-9]+/);
    // digits = digits.slice(1, -1);  // remove first and last in Arr
    // digits.shift(); digits.pop();
    digits = digits.filter(Boolean).map(Number);   // parsvame vsichki chisla kam cifri
    var result = 1;
    var counter = 1;
    for (var i = 0; i < digits.length - 1 ; i++) {

        if (i > 0 && digits[i] == 0) {
            digits[i] = digits[i - 1] + 1;
        }
        var n = digits[i] % 2 == 1;
        var m = digits[i + 1] % 2 == 1;

        if (!n && digits[i + 1] === 0) {
            m = !n;
        }
        if (n !== m || digits[i] === 0) {
            counter++;

            if (counter > result) {
                result = counter;
            }
        } else {
            counter = 1;
        }
    }
    console.log(result)
}
//Solve(["(3) (22) (-18) (55) (44) (3) (21)"]);
//Solve(["(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)"]);
//Solve(['  ( 2 )  ( 33 ) (1) (4)   (  -1  ) ']);
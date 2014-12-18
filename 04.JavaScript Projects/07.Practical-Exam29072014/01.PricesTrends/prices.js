function prices(input) {
    var numbers = [];
    for (var i = 0; i < input.length; i++) {
        var num = Number(input[i]);
        numbers.push(num);
    }
    console.log('<table>')
    console.log('<tr><th>Price</th><th>Trend</th></tr>')
    console.log('<tr><td>' + numbers[0].toFixed(2) + '</td><td><img src="fixed.png"/></td></td>')
    for (var i = 1; i < numbers.length; i++) {
        var currunt = Math.round(numbers[i] * 100) / 100;
        var prev = Math.round(numbers[i - 1] * 100) / 100;
        var str = '<tr><td>' + currunt.toFixed(2) + '</td><td><img src=';
        if (prev < currunt) {
            str += '"up.png"';
        } else if (prev > currunt) {
            str += '"down.png"';
        } else if (prev === currunt) {
            str += '"fixed.png"';
        }
        str += '/></td></td>';
        console.log(str);
    }
    console.log('</table>');

}
prices(['0.000000001', '-0.11', '0.00002', '-0.000001', '35', '35.001', '36.225']);
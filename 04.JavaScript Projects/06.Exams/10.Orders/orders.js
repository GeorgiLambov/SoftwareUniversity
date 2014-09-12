function Solve(arg) {
    var map = {};
    var orderProdukt = [];
    for (var i = 1; i < arg.length; i++) {
        var str = arg[i].split(' ');

        var product = str[2];
        var customer = str[0];
        var amount = parseInt(str[1]);

        if (!(product in map)) {
            map[product] = {};
            map[product][customer] = amount;
            orderProdukt.push(product);                               // puham kluchovete po reda na poiaviavane
        } else if ((product in map) && !(customer in map[product])) {
            map[product][customer] = amount;
        } else {
            map[product][customer] += amount;
        }
    }
    for (var i = 0; i < orderProdukt.length; i++) {                     //razpechatvam po reda na poiaviavane
        var result = '' + orderProdukt[i] + ": ";
        var custumurArr = [];
        for (var key in map[orderProdukt[i]]) {                            // sortiram po azbuchen red
            if (map[orderProdukt[i]].hasOwnProperty(key)) {
                custumurArr.push(key);
            }
        }
        custumurArr.sort();
        var custumerStr = "";
        for (var j = 0; j < custumurArr.length; j++) {
            if (j == custumurArr.length - 1) {
                custumerStr += custumurArr[j] + " " + map[orderProdukt[i]][custumurArr[j]];
            } else {
                custumerStr += custumurArr[j] + " " + map[orderProdukt[i]][custumurArr[j]] + ", ";
            }
        }
        result += custumerStr;
        console.log(result);
    }
}



Solve(['8',
'steve 8 apples',
'maria 3 bananas',
'kiro 3 bananas',
'kiro 9 apples',
'maria 2 apples',
'steve 4 apples',
'kiro 1 bananas',
'kiro 1 apples']);
function printPricesTrendsTable(input) {
    var prices = input.map(Number);
    console.log("<table>");
    console.log("<tr><th>Price</th><th>Trend</th></tr>");
    var prevPrice = undefined;
    for (var i = 0; i < prices.length; i++) {
        var price = prices[i];
        var priceStr = price.toFixed(2);
        if (prevPrice == undefined || priceStr == prevPrice) {
            var trend = "fixed.png";
        } else if (price < prevPrice) {
            var trend = "down.png";
        } else {
            var trend = "up.png";
        }
        console.log("<tr><td>" + priceStr + "</td><td><img src=\"" + trend + "\"/></td></td>");
        prevPrice = priceStr;
    }
    console.log("</table>");
}



// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

var arr = [];
require('readline').createInterface({
    input: process.stdin,
    output: process.stdout
}).on('line', function (line) {
    arr.push(line);
}).on('close', function () {
    printPricesTrendsTable(arr);
});

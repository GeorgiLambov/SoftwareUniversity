function calcCircleArea(r) {
    return Math.PI * Math.pow(r, 2)
}
var r = 7;
document.getElementById("7").innerHTML += calcCircleArea(r);
var r = 1.5;
document.getElementById("1.5").innerHTML += calcCircleArea(r);
var r = 20;
document.getElementById("20").innerHTML += calcCircleArea(r);
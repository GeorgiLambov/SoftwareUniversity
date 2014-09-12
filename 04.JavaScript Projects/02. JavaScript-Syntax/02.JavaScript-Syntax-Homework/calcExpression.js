document.getElementById("calc").onclick = function () {
    var expr = document.getElementById("expression").value;
    expr = expr.replace(/[^\d\+\-\*\/\.\(\)%]/g, '');
    var result = eval(expr);
    document.getElementById("result").innerHTML = result;
};

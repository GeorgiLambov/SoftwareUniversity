var Calculator = function (name) {
  this.name = name;
  this.result = 0;
};

Calculator.prototype = (function () {
  var add, subtract, showResult, formatResult; // hidden members

  add = function (x) {
    this.result += x;
  };

  subtract = function (x) {
    this.result -= x;
  };
  showResult = function () {
    console.log(formatResult(this.name, this.result));
  };

  formatResult = function (name, value) {
    return name + ' says the result is ' + value;
  };

  // exposed members
  return {
    add: add,
    subtract: subtract,
    showResult: showResult
  };
}());

var calc = new Calculator('SoftUniCalc');

calc.add(7);
calc.showResult();
calc.subtract(2);
calc.showResult();
function calcSupply(age, maxAge, foodPerDay) {
    var amountFood = (maxAge - age) * 365 * foodPerDay;
    console.log(amountFood + "kg of chocolate would be enough until I am " + maxAge + " years old.");
}

calcSupply(38, 118, 0.5);
calcSupply(20, 87, 2);
calcSupply(16, 102, 1.1);
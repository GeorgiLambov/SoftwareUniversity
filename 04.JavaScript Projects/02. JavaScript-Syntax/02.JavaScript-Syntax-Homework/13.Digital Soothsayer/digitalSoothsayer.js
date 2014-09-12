function soothsayer(years, programLang, city, car) {
    var result = new Array();
    result.push(years[Math.floor(Math.random() * years.length)]);
    result.push(programLang[Math.floor(Math.random() * programLang.length)]);
    result.push(city[Math.floor(Math.random() * city.length)]);
    result.push(car[Math.floor(Math.random() * car.length)]);    

    console.log("You will work " + result[0] + " years on " + result[1] +
        ". You will live in " + result[2] + " and drive " + result[3]+".");
}

soothsayer([3, 5, 2, 7, 9], ["Java", "Python", "C#", "JavaScript", "Ruby"], 
    ["Silicon Valley", "London", "Las Vegas", "Paris", "Sofia"],
    ["BMW", "Audi", "Lada", "Skoda", "Opel"]);


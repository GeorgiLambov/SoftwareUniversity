(function () {
    //check if running on Node.js
    if (typeof require !== 'undefined') {
        //load underscore if on Node.js
        _ = require('./underscore.js');
    }
    
    String.prototype.repeat = function (num) {
        return new Array(num + 1).join(this);
    };
    
    var students = [
        { "gender": "Male", "firstName": "Joe", "lastName": "Riley", "age": 22, "country": "Russia" },
        { "gender": "Female", "firstName": "Lois", "lastName": "Morgan", "age": 41, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Roy", "lastName": "Wood", "age": 33, "country": "Russia" },
        { "gender": "Female", "firstName": "Diana", "lastName": "Freeman", "age": 40, "country": "Argentina" },
        { "gender": "Female", "firstName": "Bonnie", "lastName": "Hunter", "age": 23, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Joe", "lastName": "Young", "age": 16, "country": "Bulgaria" },
        { "gender": "Female", "firstName": "Kathryn", "lastName": "Murray", "age": 22, "country": "Indonesia" },
        { "gender": "Male", "firstName": "Dennis", "lastName": "Woods", "age": 37, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Billy", "lastName": "Patterson", "age": 24, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Willie", "lastName": "Gray", "age": 42, "country": "China" },
        { "gender": "Male", "firstName": "Justin", "lastName": "Lawson", "age": 38, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Ryan", "lastName": "Foster", "age": 24, "country": "Indonesia" },
        { "gender": "Male", "firstName": "Eugene", "lastName": "Morris", "age": 37, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Eugene", "lastName": "Rivera", "age": 45, "country": "Philippines" },
        { "gender": "Female", "firstName": "Kathleen", "lastName": "Hunter", "age": 28, "country": "Bulgaria" }
    ];
    
    console.log('*'.repeat(50));
    console.log("All students with age between 18 and 24");
    console.log('*'.repeat(50));
    
    var selectedByAge = _.filter(students, function (student) {
        return student.age >= 18 && student.age <= 24;
    });

    function printStudent(student) {
        console.log(student.firstName + ' ' + student.lastName + ', gender:' 
            + student.gender + ', age: ' + student.age + ' from: ' + student.country);
    }

    selectedByAge.forEach(function (student) {
        printStudent(student);
    });
    
    console.log('*'.repeat(50));
    console.log("All students whose first name is alphabetically before their last name");
    console.log('*'.repeat(50));
    
    var sortedByName = _.filter(students, function (student) {
        return student.firstName.localeCompare(student.lastName) < 0;
    });
    sortedByName.forEach(function (student) {
        printStudent(student);
    });
    
    console.log('*'.repeat(50));
    console.log("Only the names of all students from Bulgaria");
    console.log('*'.repeat(50));
    
    var sortedByCountry = _.where(students, { country: "Bulgaria" });
    sortedByCountry.forEach(function (student) {
        console.log(student.firstName + ' ' + student.lastName + ' from: ' + student.country);
    });
    
    console.log('*'.repeat(50));
    console.log("Last five students");
    console.log('*'.repeat(50));
    
    var lastStudents = _.last(students, 5);
    lastStudents.forEach(function (student) {
        printStudent(student);
    });
    
    console.log('*'.repeat(50));
    console.log("First three students who are not from Bulgaria and are male");
    console.log('*'.repeat(50));
    
    var firstTreeNotFromBulgaria = _.filter(students, function (student) {        //_.chain
        return student.country !== 'Bulgaria' && student.gender === 'Male';
    });
    firstTreeNotFromBulgaria = _.first(firstTreeNotFromBulgaria, 3);
    
    firstTreeNotFromBulgaria.forEach(function (student) {
        printStudent(student);
    });
}());
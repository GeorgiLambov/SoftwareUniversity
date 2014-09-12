function aggregateStudentResults(input) {
    var results = { };
    for (var i = 0; i < input.length; i++) {
        var tokens = input[i].split('|');
        var student = tokens[0].trim();
        var course = tokens[1].trim();
        var grade = Number(tokens[2].trim());
        var visits = Number(tokens[3].trim());
        if (!results[course]) {
            results[course] = { grades: [], visits: [], students: [] };
        }
        results[course].grades.push(grade);
        results[course].visits.push(visits);
        if (results[course].students.indexOf(student) == -1) {
            results[course].students.push(student);
        }
    }
    
    var output = { };    
    var courses = Object.keys(results).sort();
    for (var c in courses) {
        var courseName = courses[c];
        var courseInfo = {
            avgGrade: average(results[courseName].grades),
            avgVisits: average(results[courseName].visits),
            students: results[courseName].students.sort()
        };
        output[courseName] = courseInfo;
    }
    
    console.log(JSON.stringify(output));

    function average(arr) {
        var sum = 0;
        for (var i in arr) {
            sum += arr[i];
        }
        var avg = sum / arr.length;
        avg = Number(avg.toFixed(2));
        return avg;
    }
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
    aggregateStudentResults(arr);
});

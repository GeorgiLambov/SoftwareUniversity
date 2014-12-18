function Solve(input) {
    var map = {};
    var orderCourse = [];
    
    for (var i = 0; i < input.length; i++) {
        var inputHolder = input[i].split('|');
        inputHolder = inputHolder.filter(function (n) { return n != '' });
        
        var course = inputHolder[1].trim();
        var name = inputHolder[0].trim();
        var grade = Number(inputHolder[2].trim());
        var visits = Number(inputHolder[3].trim());
        grade = Math.round(grade * 100) / 100;
        if (!(course in map)) {
            map[course] = [grade, visits, []];
            map[course][2].push(name);     //map[score][2] e array s imenata
            orderCourse.push(course);

        } else {
            map[course][0] += Math.round(grade * 100) / 100;
            map[course][1] += Math.round(visits * 100) / 100;
            
            map[course][2].push(name); //dobavqme imeto

        }

    }
    orderCourse.sort();
    var resultMap = {};
    var students = [];
    for (var j = 0; j < orderCourse.length; j++) {
        var tempCourse = orderCourse[j];
        var avgGrade = map[tempCourse][0] / map[tempCourse][2].length;
        avgGrade = Number(avgGrade.toFixed(2));
        var avgVisit = map[tempCourse][1] / map[tempCourse][2].length;
        avgVisit = Number(avgVisit.toFixed(2));
        
        students = map[tempCourse][2];
        students = getUniqueElements(students);
        students.sort();
        if (!(tempCourse in resultMap)) {
            resultMap[tempCourse] = {
                avgGrade: avgGrade,
                avgVisits: avgVisit,
                students: students
            }

        }
    }
    console.log(JSON.stringify(resultMap));
    
    
    function getUniqueElements(arr) {
        var uniqueElements = [];
        
        for (var i in arr) {
            if (uniqueElements.indexOf(arr[i]) === -1) {
                // if elements doesn't exist, add it to the array
                uniqueElements.push(arr[i]);
            }
        }
        
        return uniqueElements;
    }
}




Solve(['Peter  pet| PHP  | 5.00 | 0',
'Peter | Java | 5.64 | 0',
'Peter | PHP  | 4.00 | 0',
'Peter | C#   | 5.83 | 0',
'Peter | C#   | 4.14 | 0',
'Peter | PHP  | 4.04 | 0',
'Peter | SQL  | 5.12 | 0',
'Peter | C#   | 3.26 | 0',
'Peter | C#   | 5.50 | 0',
'Peter | Java | 6.00 | 0']);
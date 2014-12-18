function Solve(input) {
    var n = parseInt(input[0]);
    var assArr = {};
    for (var i = 1; i <= n; i++) {
        var sequenceOfAccess = input[i].split(' ');
        var ip = sequenceOfAccess[0];
        var user = sequenceOfAccess[1];
        var duration = parseInt(sequenceOfAccess[2]);

        if (!(user in assArr)) {
            assArr[user] = {};              // create new object key user
            assArr[user][ip] = duration;
        } else if ((user in assArr) && !(ip in assArr[user])) {
            assArr[user][ip] = duration;
        } else {
            assArr[user][ip] += duration;
        }
    }
    var keyUsers = [];                             // sort na key ot {} v []. alphabetical
    for (var key in assArr) {
        if (assArr.hasOwnProperty(key)) {
            keyUsers.push(key);
        }
    }
    keyUsers.sort();
    var output = '';                // print
    for (var i = 0; i < keyUsers.length; i++) {
        var sumDuration = 0;
        var alphabetUser = keyUsers[i];
        var ipArr = [];
        for (var ip in assArr[alphabetUser]) {
            sumDuration += assArr[alphabetUser][ip];
            ipArr.push(ip);
        }
        output += alphabetUser + ": " + sumDuration + " [" + ipArr.sort().join(', ') + "]\n";
    }
    console.log(output);
}

Solve(['7', '192.168.0.11 peter 33', '10.10.17.33 alex 12', '10.10.17.35 peter 30', '10.10.17.34 peter 120', '10.10.17.34 peter 120', '212.50.118.81 alex 46', '212.50.118.81 alex 4']);
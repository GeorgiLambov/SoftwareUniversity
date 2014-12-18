function solve (input){
    var n = input[0];
    var assarr = {};
    var count;
    for (var i = 1; i <= n; i++) {
        var tempRow = input[i].split(' ');
        var ip = tempRow[0];
        var user = tempRow[1];
        var minute = parseInt(tempRow[2]);

        if (!(user in assarr)) {
            assarr[user] = {};
            assarr[user][ip] = minute;
        } else if ((user in assarr)&& !(ip in assarr[user])) {
            assarr[user][ip] = minute;
        } else {
            minute = minute + assarr[user][ip];
            assarr[user][ip] = minute;
        }
    }

    var keysUsers = [];
    for(var key in assarr) {
        if (assarr.hasOwnProperty(key)) {
            keysUsers.push(key);
        }
    }
    keysUsers.sort();
    var output = '';
    for (var i = 0; i < keysUsers.length; i++) {
        var sumMinutes = 0;
        var keysUsersIp = [];
        for(var key in assarr[keysUsers[i]]) {
            if (assarr[keysUsers[i]].hasOwnProperty(key)) {
                keysUsersIp.push(key);
                sumMinutes += assarr[keysUsers[i]][key];
            }
        }
        output += keysUsers[i] + ': ' + sumMinutes + ' [' + keysUsersIp.sort().join(', ') + ']\n';
    }
    console.log(output);
}

//when you submit the code into the Judge system, do not copy the code below!
solve (["14",
    "8.8.8.8 google 100",
    "8.8.8.8 google 50",
    "10.10.10.10 test 98",
    "10.10.10.10 google 730",
    "8.8.8.8 google 150",
    "10.10.10.10 test 100",
    "8.8.8.8 google 50",
    "10.10.10.10 root 46",
    "10.10.10.10 root 58",
    "8.8.8.8 root 167",
    "1.2.3.4 root 120",
    "5.6.7.8 root 970",
    "192.168.0.11 root 55",
    "10.10.10.10 test 302"])

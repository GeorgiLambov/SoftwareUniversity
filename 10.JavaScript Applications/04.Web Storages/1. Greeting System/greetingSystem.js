/**
 * Created by Zhivko on 30.11.2014 г..
 */

(function () {
    var result = document.getElementById('result');
    var button = document.getElementById('put-btn');


    function loginUser(){

        var name = document.getElementById('name').value;
        localStorage.setItem('name', name);
    };


    if(localStorage['name']) {
        document.getElementById('login').style.display = 'none';
        result.innerHTML += 'Hello ' + localStorage['name'] + '!';
    }else {
        button.addEventListener('click', loginUser);
    }

    function sessionStorageLoads() {
        if (!sessionStorage.counter) {
            sessionStorage.setItem("counter", 0);
        }

        var currentCount = parseInt(sessionStorage.getItem("counter"));
        currentCount++;
        sessionStorage.setItem("counter", currentCount);

        document.getElementById("countSession").innerHTML = 'Your Session visits ' + currentCount + ' time(s)';
    }

    sessionStorageLoads();

    function localStorageLoads() {
        if (!localStorage.counter) {
            localStorage.setItem("counter", 0);
        }

        var currentCount = parseInt(localStorage.getItem("counter"));
        currentCount++;
        localStorage.setItem("counter", currentCount);

        document.getElementById("countLocal").innerHTML = 'You Local visits ' + currentCount + ' time(s)';
    }

    localStorageLoads();

}())
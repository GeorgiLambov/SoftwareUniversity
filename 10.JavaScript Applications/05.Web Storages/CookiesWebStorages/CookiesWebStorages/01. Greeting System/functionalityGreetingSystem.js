(function () {

    if (!localStorage['visitsCount']) {
        localStorage.setItem('visitsCount', 0);
    }

    if (!sessionStorage['visitsCount']) {
        sessionStorage.setItem('visitsCount', 0);
    }

    sessionStorage['visitsCount']++;
    localStorage['visitsCount']++;

    function setCookie(cname, cvalue, exdays) {
        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toUTCString();
        document.cookie = cname + "=" + cvalue + "; " + expires;
    }

    function getCookie(cname) {
        var name = cname + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1);
            if (c.indexOf(name) != -1) return c.substring(name.length, c.length);
        }
        return "";
    }

    (function checkCookie() {
        var user = getCookie("username");
        if (user != "") {

            alert("Welcome again " + user +
                 "\nSession visits: " + sessionStorage['visitsCount'] +
                 "\nTotal visits: " + localStorage['visitsCount']);
        } else {
            user = prompt("Please enter your name:", "");
            if (user != "" && user != null) {
                setCookie("username", user, 1);
            }
        }
    }());

    $('#sessionVisits').text('Session visits: ' + sessionStorage['visitsCount']);
    $('#tottalVisits').text('Total visits: ' + localStorage['visitsCount']);

}());


'use strict';

var ajaxRequester = (function() {
    var baseUrl = "https://api.parse.com/1/";

    var headers =
    {
        "X-Parse-Application-Id": "w2tDxtXrzSQjuYVEirdULU1Ehl97he4sUPc0rojx",
        "X-Parse-REST-API-Key": "z0mkyIsbtO7KEmJRiFPAVQ2xiM9Kx5n6MujBlPVx"
    };

    function register(username, password, fullname, success, error) {
        $.ajax({
            method: "POST",
            headers: headers,
            url: baseUrl + "users",
            data: JSON.stringify({username: username, password: password, FullName: fullname}),
            success: success,
            error: error
        });
    }

        function login(username, password, success, error) {
        $.ajax({
            method: "GET",
            headers: headers,
            url: baseUrl + "login",
            data: {username: username, password: password},
            success: success,
            error: error
        });
    }

    function getHeadersWithSessionToken(sessionToken) {
        var headersWithToken = headers;
        headersWithToken['X-Parse-Session-Token'] = sessionToken;
        return headersWithToken;
    }

    function getPhones(sessionToken, success, error) {
        var headersWithSessionToken = getHeadersWithSessionToken(sessionToken);
        $.ajax({
            method: "GET",
            headers: headersWithSessionToken,
            url: baseUrl + "classes/Phone",
            success: success,
            error: error
        });
    }

    function addPhone(person, number, userId, success, error) {
        var acl = {};
        acl[userId] = {write: true, read: true};
        $.ajax({
            method: "POST",
            headers: headers,
            url: baseUrl + "classes/Phone",
            data: JSON.stringify({person: person, number: number, ACL: acl}),
            success: success,
            error: error
        });
    }

    function deletePhone(sessionToken, bookmarkId, success, error) {
        var headersWithToken = getHeadersWithSessionToken(sessionToken);
        jQuery.ajax({
            method: "DELETE",
            headers: headersWithToken,
            url: baseUrl + "classes/Phone" + bookmarkId,
            success: success,
            error: error
        });
    }

    return {
        register: register,
        login: login,
        getPhones: getPhones,
        addPhone: addPhone,
        deletePhone: deletePhone
    };
})();

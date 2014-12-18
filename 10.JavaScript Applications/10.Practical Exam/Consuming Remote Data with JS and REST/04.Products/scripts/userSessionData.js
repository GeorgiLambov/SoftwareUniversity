var userSessionData = (function () {
    'use strict'
    var headers = {
        "X-Parse-Application-Id": "ZUgR1zWRliR2cilhJQDdsis2h68sFMzu3PIoBqAQ",
        "X-Parse-REST-API-Key": "9XHvQZkhSNig892xNWhviYKh3P4sGytvKzCOm0At"
    }

    function getHeaders() {
        var sessionToken = getSessionToken();
        headers['X-Parse-Session-Token'] = sessionToken;
        return JSON.parse(JSON.stringify(headers));
    }

    function getSessionToken() {
        return localStorage.getItem('sessionToken');
    };

    function setSessionToken(sessionToken) {
        localStorage.setItem('sessionToken', sessionToken);
    }

    function getUserName() {
        return localStorage.getItem('userName');
    }

    function setUserName(userName) {
        localStorage.setItem('userName', userName);
    }

    function getUserObjectId() {
        return localStorage.getItem('userObjectId');
    }

    function setUserObjectId(objectId) {
        localStorage.setItem('userObjectId', objectId);
    }

    return {
        getSessionToken: getSessionToken,
        setSessionToken: setSessionToken,
        getUserName: getUserName,
        setUserName: setUserName,
        setUserObjectId: setUserObjectId,
        getUserObjectId: getUserObjectId,
        getHeaders: getHeaders
    }
}());
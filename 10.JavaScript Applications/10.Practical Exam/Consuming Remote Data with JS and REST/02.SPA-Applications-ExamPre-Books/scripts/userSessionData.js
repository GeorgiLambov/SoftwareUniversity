var userSessionData = (function () {
    'use strict'
    var headers = {
        "X-Parse-Application-Id": "ngkvE9L5ymm6RHfu0p6Y6SbbPZ1ZnWM7IQnbBhw9",
        "X-Parse-REST-API-Key": "TKikYmxohTuzTE4hyvHIJzbLUt91reMVrNfs3zfo"
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
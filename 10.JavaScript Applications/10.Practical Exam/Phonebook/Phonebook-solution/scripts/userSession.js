'use strict';

var app = app || {};

app.userSession = {
    login : function(userObject) {
        sessionStorage['currentUser'] = JSON.stringify(userObject);
    },
    getCurrentUser : function() {
        var userObject = sessionStorage['currentUser'];
        if (userObject) {
            return JSON.parse(sessionStorage['currentUser']);
        }
    },
    logout : function() {
        delete sessionStorage['currentUser'];
    }
};

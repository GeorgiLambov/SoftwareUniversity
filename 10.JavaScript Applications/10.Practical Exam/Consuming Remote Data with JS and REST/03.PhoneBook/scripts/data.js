var app = app || {};

app.data = (function () {
    'use strict'
    function Data(rootUrl, ajaxRequester) {
        this.users = new Users(rootUrl, ajaxRequester);
        this.phones = new Phones(rootUrl, ajaxRequester);
    }

    var Users = (function () {
        function Users(rootUrl, ajaxRequester) {
            this._serviceUrl = rootUrl;
            this._ajaxRequester = ajaxRequester;
        }

        Users.prototype.register = function (username, password, fullName) {
            var user = {
                username: username,
                password: password,
                fullName: fullName
            };
            var url = this._serviceUrl + 'users';
            return this._ajaxRequester.post(url, user, userSessionData.getHeaders())
                    .then(function (data) {
                        userSessionData.setSessionToken(data.sessionToken);
                        userSessionData.setUserObjectId(data.objectId);
                        return data;
                    });
        }

        Users.prototype.login = function (username, password) {
            var url = this._serviceUrl + 'login?username=' + username + '&password=' + password;
            return this._ajaxRequester.get(url, userSessionData.getHeaders())
                       .then(function (data) {
                           userSessionData.setSessionToken(data.sessionToken);
                           userSessionData.setUserName(data.username);
                           userSessionData.setUserObjectId(data.objectId);
                           return data;
                       });
        }

        Users.prototype.logOUT = function () {
            localStorage.clear();
        };

        Users.prototype.validateToken = function (accessToken) {
            var url = this._serviceUrl + 'users/me';
            return this._ajaxRequester.get(url, userSessionData.getHeaders())
        }

        Users.prototype.edit = function (user, objectId) {
            var url = this._serviceUrl + 'users' + '/' + objectId;
            return this._ajaxRequester.put(url, user, userSessionData.getHeaders());
        }

        return Users;
    }());

    var Phones = (function () {
        function Phones(rootUrl, ajaxRequester) {
            this._serviceUrl = rootUrl + 'classes/Phone';
            this._ajaxRequester = ajaxRequester;
        }

        Phones.prototype.getAll = function () {
            return this._ajaxRequester.get(this._serviceUrl, userSessionData.getHeaders());
        }

        Phones.prototype.getById = function (objectId) {
            var url = this._serviceUrl + '/' + objectId;
            return this._ajaxRequester.get(url, userSessionData.getHeaders());
        }

        Phones.prototype.add = function (phone) {
            return this._ajaxRequester.post(this._serviceUrl, phone, userSessionData.getHeaders());
        }

        Phones.prototype.delete = function (objectId) {
            var url = this._serviceUrl + '/' + objectId;
            return this._ajaxRequester.delete(url, userSessionData.getHeaders());
        }

        Phones.prototype.edit = function (phone, objectId) {
            var url = this._serviceUrl + '/' + objectId;
            return this._ajaxRequester.put(url, phone, userSessionData.getHeaders());
        }

        return Phones;
    }());

    return {
        get: function (rootUrl, ajaxRequester) {
            return new Data(rootUrl, ajaxRequester);
        }
    }
}());
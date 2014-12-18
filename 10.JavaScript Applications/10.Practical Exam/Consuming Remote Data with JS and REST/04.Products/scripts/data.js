var app = app || {};

app.data = (function () {
    'use strict'
    function Data(rootUrl, ajaxRequester) {
        this.users = new Users(rootUrl, ajaxRequester);
        this.products = new Products(rootUrl, ajaxRequester);
    }

    var Users = (function () {
        function Users(rootUrl, ajaxRequester) {
            this._serviceUrl = rootUrl;
            this._ajaxRequester = ajaxRequester;
        }

        Users.prototype.register = function (username, password) {
            var user = {
                username: username,
                password: password
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

        Users.prototype.getUserData = function () {
            return {
                userId: userSessionData.getUserObjectId(),
                username: userSessionData.getUserName(),
                sessionToken: userSessionData.getSessionToken()
            }
        }

        return Users;
    }());

    var Products = (function () {
        function Products(rootUrl, ajaxRequester) {
            this._serviceUrl = rootUrl + 'classes/Product';
            this._ajaxRequester = ajaxRequester;
        }

        Products.prototype.getAll = function () {
            return this._ajaxRequester.get(this._serviceUrl, userSessionData.getHeaders());
        }

        Products.prototype.getById = function (objectId) {
            var url = this._serviceUrl + '/' + objectId;
            return this._ajaxRequester.get(url, userSessionData.getHeaders());
        }

        Products.prototype.add = function (product) {
            return this._ajaxRequester.post(this._serviceUrl, product, userSessionData.getHeaders());
        }

        Products.prototype.delete = function (objectId) {
            var url = this._serviceUrl + '/' + objectId;
            return this._ajaxRequester.delete(url, userSessionData.getHeaders());
        }

        Products.prototype.edit = function (product, objectId) {
            var url = this._serviceUrl + '/' + objectId;
            return this._ajaxRequester.put(url, product, userSessionData.getHeaders());
        }

        return Products;
    }());

    return {
        get: function (rootUrl, ajaxRequester) {
            return new Data(rootUrl, ajaxRequester);
        }
    }
}());
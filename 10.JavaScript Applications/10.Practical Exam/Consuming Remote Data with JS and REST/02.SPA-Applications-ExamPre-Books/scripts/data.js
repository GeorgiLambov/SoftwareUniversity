var bookApp = bookApp || {};
'use strict'
bookApp.data = (function () {
    function Data(rootUrl, ajaxRequester) {
        this.users = new Users(rootUrl, ajaxRequester);
        this.books = new Books(rootUrl, ajaxRequester);
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
                    userSessionData.setUserName(user.username);
                    userSessionData.setUserObjectId(data.objectId);
                });
        }

        Users.prototype.login = function (username, password) {
            var url = this._serviceUrl + 'login?username=' + username + '&password=' + password;
            return this._ajaxRequester.get(url, userSessionData.getHeaders())
                .then(function (data) {
                    userSessionData.setSessionToken(data.sessionToken);
                    userSessionData.setUserName(data.username);
                    userSessionData.setUserObjectId(data.objectId);
                });
        }

        Users.prototype.logOUT = function () {
            localStorage.clear();
        };

        Users.prototype.validateToken = function (accessToken) {
            if (userSessionData.getSessionToken()) {
                var SessionToken = userSessionData.getSessionToken();
                var url = this._serviceUrl + 'users/me';

                this._ajaxRequester.get(url, userSessionData.getHeaders())
                     .then(function (data) {
                         if (SessionToken === data.sessionToken) {
                             return true;
                         }

                         return false;

                     }, function (error) {
                         console.log('Error validateToken');
                     });
            }

        }

        return Users;
    }());

    var Books = (function () {
        function Books(rootUrl, ajaxRequester) {
            this._serviceUrl = rootUrl + 'classes/Book';
            this._ajaxRequester = ajaxRequester;
        }

        Books.prototype.getAll = function () {
            return this._ajaxRequester.get(this._serviceUrl, userSessionData.getHeaders());
        }

        Books.prototype.getById = function (objectId) {
            return this._ajaxRequester.get(this._serviceUrl + '/' + objectId, userSessionData.getHeaders());
        }

        Books.prototype.add = function (book) {
            return this._ajaxRequester.post(this._serviceUrl, book, userSessionData.getHeaders());
        }

        Books.prototype.delete = function (objectId) {
            var url = this._serviceUrl + '/' + objectId;
            return this._ajaxRequester.delete(url, userSessionData.getHeaders());
        }

        Books.prototype.edit = function (book, objectId) {
            var url = this._serviceUrl + '/' + objectId;
            return this._ajaxRequester.put(url, book, userSessionData.getHeaders());
        }

        return Books;
    }());

    return {
        get: function (rootUrl, ajaxRequester) {
            return new Data(rootUrl, ajaxRequester);
        }
    }
}());
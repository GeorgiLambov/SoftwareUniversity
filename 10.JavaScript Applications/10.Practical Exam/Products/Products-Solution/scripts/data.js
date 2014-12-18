var app = app || {};

app.data = (function () {

    function Data (baseUrl, ajaxRequester) {
        this.users = new Users(baseUrl, ajaxRequester);
        this.products = new Products(baseUrl, ajaxRequester);
    }

    var credentials = (function () {

        function getHeaders() {
            var headers = {
                    'X-Parse-Application-Id': 'b7WqYGjz7IC1W0hIlx0gGLQAHWKElg2snFDfZaX7',
                    'X-Parse-REST-API-Key': 'VlDY0eNwNHvDFPEk36cM207iUpcnb0MyrENDhT4h'
                },
                currentUser = getSessionToken();

            if (currentUser) {
                headers['X-Parse-Session-Token'] = currentUser;
            }
            return headers;
        }

        function getSessionToken() {
            return localStorage.getItem('sessionToken');
        }

        function setSessionToken(sessionToken) {
            localStorage.setItem('sessionToken', sessionToken);
        }

        function getUserId() {
            return localStorage.getItem('userId');
        }

        function setUserId(userId) {
            return localStorage.setItem('userId', userId);
        }

        function getUsername() {
            return localStorage.getItem('username');
        }

        function setUsername(sessionToken) {
            localStorage.setItem('username', sessionToken);
        }
        
        function clearLocalStorage() {
            delete localStorage['username'];
            delete localStorage['sessionToken'];
            delete localStorage['userId'];
        }

        return {
            getSessionToken: getSessionToken,
            setSessionToken: setSessionToken,
            getUsername: getUsername,
            setUsername: setUsername,
            getUserId: getUserId,
            setUserId: setUserId,
            getHeaders: getHeaders,
            clearLocalStorage: clearLocalStorage
        }
    }())

    var Users = (function (argument) {
        function Users(baseUrl, ajaxRequester) {
            this._serviceUrl = baseUrl;
            this._ajaxRequester = ajaxRequester;
        }

        Users.prototype.login = function (username, password) {
            var url = this._serviceUrl + 'login?username=' + username + '&password=' + password;
            return this._ajaxRequester.get(url, credentials.getHeaders())
                .then(function (data) {
                    credentials.setSessionToken(data.sessionToken);
                    credentials.setUsername(data.username);
                    credentials.setUserId(data.objectId);
                    return data;
                });
        }

        Users.prototype.register = function (username, password) {
            var user = {
                username: username,
                password: password
            };
            var url = this._serviceUrl + 'users';
            return this._ajaxRequester.post(url, user, credentials.getHeaders())
                .then(function (data) {
                    return data;
                });
        }

        Users.prototype.isLogged = function() {
            return credentials.getSessionToken();
        }

        Users.prototype.validateToken = function (sessionToken) {
            var url = this._serviceUrl + 'users/me';
            return this._ajaxRequester.get(url, credentials.getHeaders());
        }

        Users.prototype.getUserData = function () {
            return {
                userId: credentials.getUserId(),
                username: credentials.getUsername(),
                sessionToken: credentials.getSessionToken()
            }
        }

        Users.prototype.logout = function() {
            credentials.clearLocalStorage();
        }

        return Users;
    }());

    var Products = (function () {
        var PRODUCTS_URL = 'classes/Product';

        function Products(baseUrl, ajaxRequester) {
            this._serviceUrl = baseUrl + PRODUCTS_URL;
            this._ajaxRequester = ajaxRequester;
        }

        Products.prototype.getAll = function () {
            return this._ajaxRequester.get(this._serviceUrl, credentials.getHeaders());
        }

        Products.prototype.getById = function (objectId) {
            return this._ajaxRequester.get(this._serviceUrl + '/' + objectId, credentials.getHeaders());
        }

        Products.prototype.add = function (product, ownerObjectId) {
            product.ACL = { };
            product.ACL[ownerObjectId] = {"write": true, "read": true};
            product.ACL['*'] = {"read": true};
            return this._ajaxRequester.post(this._serviceUrl, product, credentials.getHeaders());
        }

        Products.prototype.edit = function (product, productId) {
            var url = this._serviceUrl + '/' + productId;
            return this._ajaxRequester.put(url, product, credentials.getHeaders());
        }

        Products.prototype.delete = function (objectId) {
            var url = this._serviceUrl + '/' + objectId;
            return this._ajaxRequester.delete(url, credentials.getHeaders());
        }

        return Products;
    }());

    return {
        get: function (baseUrl, ajaxRequester) {
            return new Data(baseUrl, ajaxRequester);
        }
    }
}());
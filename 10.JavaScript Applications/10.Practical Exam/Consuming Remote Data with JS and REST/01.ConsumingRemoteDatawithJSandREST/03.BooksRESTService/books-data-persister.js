var booksApp = booksApp || {};

booksApp.dataPersister = (function () {
    'use strict';
    function Persister(rootUrl) {
        this.rootUrl = rootUrl;
        this.booksRepository = new Books(rootUrl);
    }

    var Books = (function () {
        function Books(rootUrl) {
            this.serviceUrl = rootUrl + 'Book';
        }
        Books.prototype.getAll = function (succses, error) {
            return ajaxRequester.get(this.serviceUrl, succses, error);
        };
        Books.prototype.add = function (book, succses, error) {
            return ajaxRequester.post(this.serviceUrl, book, succses, error);
        };
        Books.prototype.delete = function (id, succses, error) {
            return ajaxRequester.delete(this.serviceUrl + "/" + id, succses, error);
        };
        Books.prototype.edit = function (id, student, succses, error) {
            return ajaxRequester.put(this.serviceUrl + "/" + id, student, succses, error);
        };

        return Books;
    }());

    return {
        get: function (rootUrl) {
            return new Persister(rootUrl);
        }
    };
}());
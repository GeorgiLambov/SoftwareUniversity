var studentsApp = studentsApp || {};

studentsApp.dataPersister = (function () {
    'use strict';
    function Persister(rootUrl) {
        this.rootUrl = rootUrl;
        this.students = new Students(rootUrl);
        this.schools = new Schools(rootUrl);
    }

    var Students = (function () {
        function Students(rootUrl) {
            this.serviceUrl = rootUrl + 'Student';
        }
        Students.prototype.getAll = function (succses, error) {
            return ajaxRequester.get(this.serviceUrl, succses, error);
        };
        Students.prototype.add = function (student, succses, error) {
            return ajaxRequester.post(this.serviceUrl, student, succses, error);
        };
        Students.prototype.delete = function (id, succses, error) {
            return ajaxRequester.delete(this.serviceUrl + "/" + id, succses, error);
        };
        Students.prototype.edit = function (id, student, succses, error) {
            return ajaxRequester.put(this.serviceUrl + "/" + id, student, succses, error);
        };

        return Students;
    }());

    var Schools = (function () {
        function Schools(rootUrl) {
            this.serviceUrl = rootUrl + 'Schools';
        }

        return Schools;
    }());

    return {
        get: function (rootUrl) {
            return new Persister(rootUrl);
        }
    };
}());
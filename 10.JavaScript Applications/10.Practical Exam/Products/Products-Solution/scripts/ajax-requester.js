var app = app || {};

app.ajaxRequester = (function() {

    function AjaxRequester() {
        this.get = makeGetRequest;
        this.post = makePostRequest;
        this.put = makePutRequest;
        this.delete = makeDeleteRequest;
    }

    function makeRequest(url, method, data, headers) {
        var queue = Q.defer();

        $.ajax({
            url: url,
            method: method,
            contentType: "application/json",
            data: JSON.stringify(data) || undefined,
            headers: headers,
            success: function(data) {
                queue.resolve(data);
            },
            error: function(error) {
                queue.reject(error);
            }
        });

        return queue.promise;
    }

    function makeGetRequest(url, headers) {
        return makeRequest(url, "GET", null, headers);
    }

    function makePostRequest(url, data, headers) {
        return makeRequest(url, "POST", data, headers);
    }

    function makePutRequest(url, data, headers) {
        return makeRequest(url, "PUT", data, headers);
    }

    function makeDeleteRequest(url, headers) {
        return makeRequest(url, "DELETE", null, headers);
    }

    return {
        get: function() {
            return new AjaxRequester();
        }
    }
}());
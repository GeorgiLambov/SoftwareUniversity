var ajaxRequester = (function () {
    'use strict';
    var PARSE_APP_ID = "XILnllEx2rF7LJKhBTN5myvIUbNri3TlrKdCBrVD";
    var PARSE_REST_API_KEY = "zkDIVZtIv2RbrZVkZoyrsHHc1Xf47vgqCS7hNZRy";

    var makeRequest = function makeRequest(method, url, data, success, error) {

        return $.ajax({
            type: method,
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: url,
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: success,
            error: error
        });
    };

    function makeGetRequest(url, success, error) {
        return makeRequest('GET', url, {}, success, error);
    }
    function makePostRequest(url, data, success, error) {
        return makeRequest('POST', url, data, success, error);
    }
    function makePutRequest(url, data, success, error) {
        return makeRequest('PUT', url, data, success, error);
    }
    function makeDeleteRequest(url, success, error) {
        return makeRequest('DELETE', url, {}, success, error);
    }

    return {
        get: makeGetRequest,
        post: makePostRequest,
        put: makePutRequest,
        delete: makeDeleteRequest
    };
}());
'use strict';

var app = app || {};

app.ajaxRequester = (function () {

	function makeRequest(url, method, data, headers, success, error) {
		$.ajax({
			url: url,
			method: method,
			contentType: 'application/json',
			data: data,
			headers: headers,
			success: success,
			error: error
		});
	}

	function makeGetRequest(url, data, headers, success, error) {
		return makeRequest(url, 'GET', data, headers, success, error);
	}

	function makePostRequest(url, data, headers, success, error) {
		return makeRequest(url, 'POST', JSON.stringify(data), headers, success, error);
	}

	function makePutRequest(url, data, headers, success, error) {
		return makeRequest(url, 'PUT', JSON.stringify(data), headers, success, error);
	}

	function makeDeleteRequest(url, headers, success, error) {
		return makeRequest(url, 'DELETE', null, headers, success, error);
	}

	return {
		get: makeGetRequest,
		post: makePostRequest,
		put: makePutRequest,
		delete: makeDeleteRequest
	}
}());

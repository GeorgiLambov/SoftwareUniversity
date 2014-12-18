'use strict';

var app = app || {};

app.Services = function(baseServiceUrl, parseAppId, parseRestApiKey) {
	function getHeaders() {
		var headers = {
			'X-Parse-Application-Id': parseAppId,
			'X-Parse-REST-API-Key': parseRestApiKey
		};
		var currentUser = app.userSession.getCurrentUser();
		if (currentUser) {
			headers['X-Parse-Session-Token'] = currentUser.sessionToken;
		}
		return headers;
	}

	var users = {
		login: function(username, password, success, error) {
			var url = baseServiceUrl + 'login';
			var userData = {
				username: username,
				password: password
			};
			return app.ajaxRequester.get(url, userData, getHeaders(),
				function (data) {
					app.userSession.login(data);
					success(data);
				}, error);
		},

		logout: function() {
			app.userSession.logout();
		},

		register: function (username, password, fullName, success, error) {
			var url = baseServiceUrl + 'users';
			var userData = {
				username: username,
				password: password,
				fullName: fullName
			};
			return app.ajaxRequester.post(url, userData, getHeaders(),
				function (data) {
					data.username = username;
					app.userSession.login(data);
					success(data);
				}, error);
		},

		getById: function (objectId, success, error) {
			var url = baseServiceUrl + 'users/' + objectId;
			return app.ajaxRequester.get(url, undefined, getHeaders(), success, error);
		},

		editProfile: function (user, success, error) {
			var url = baseServiceUrl + 'users/' + user.objectId;
			return app.ajaxRequester.put(url, user, getHeaders(), success, error);
		}
	};

	var phones = {
		getAll: function (success, error) {
			var url = baseServiceUrl + 'classes/Phone';
			return app.ajaxRequester.get(url, undefined, getHeaders(), success, error);
		},

		getById: function (objectId, success, error) {
			var url = baseServiceUrl + 'classes/Phone/' + objectId;
			return app.ajaxRequester.get(url, undefined, getHeaders(), success, error);
		},

		add: function (phone, ownerObjectId, success, error) {
			phone.ACL = { };
			phone.ACL[ownerObjectId] = {"write": true, "read": true};
			var url = baseServiceUrl + 'classes/Phone';
			return app.ajaxRequester.post(url, phone, getHeaders(), success, error);
		},

		update: function (phone, success, error) {
			var url = baseServiceUrl + 'classes/Phone/' + phone.objectId;
			return app.ajaxRequester.put(url, phone, getHeaders(), success, error);
		},

		delete: function (objectId, success, error) {
			var url = baseServiceUrl + 'classes/Phone/' + objectId;
			return app.ajaxRequester.delete(url, getHeaders(), success, error);
		}
	};

	return {
		users: users,
		phones: phones
	}
};

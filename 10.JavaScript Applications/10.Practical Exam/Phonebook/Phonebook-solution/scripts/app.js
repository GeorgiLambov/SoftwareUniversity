'use strict';

var app = app || {};

(function () {
	var baseServiceUrl = 'https://api.parse.com/1/';
	var parseAppId = 'cJRXilnxnAN95teZuV4UYKnMviQp8zBAGnO4E4X6';
	var parseRestApiKey = 'sbDczwSYavT274W8d0fKR8Ft8r3iIaeSLu4KGhKa';
	var services = new app.Services(baseServiceUrl, parseAppId, parseRestApiKey);

	var selector = '#wrapper';

	app.router = Sammy(function () {
		this.before(function() {
			var currentUser = app.userSession.getCurrentUser();
			if (currentUser) {
				$('#menu').show();
			} else {
				$('#menu').hide();
			}
		});

		this.before(/#\/user\//, function() {
			var currentUser = app.userSession.getCurrentUser();
			if (! currentUser) {
				showErrorMessage("Please login first");
				app.router.setLocation("#/login");
				return false;
			}
		});

		this.get('#/', function (){
			if (app.userSession.getCurrentUser()) {
				app.router.setLocation("#/user/home");
			} else {
				setTitle("Welcome");
				$(selector).load('./templates/welcome.html');
			}
		});

		this.get('#/login', function () {
			setTitle("Login");
			$(selector).load('./templates/login.html');
		});

		this.get('#/logout', function () {
			services.users.logout();
			showInfoMessage("Successfully logged out");
			app.router.setLocation("#/");
		});

		this.get('#/register', function () {
			setTitle("Registration");
			$(selector).load('./templates/register.html');
		});

		this.get('#/user/home', function () {
			setTitle("Home");
			var currentUser = app.userSession.getCurrentUser();
			var user = { name: currentUser.username };
			if (currentUser.fullName) {
				user = { name: currentUser.fullName + ' (' + currentUser.username + ')' };
			}
			$.get('templates/user-home.html', function(template) {
				var output = Mustache.render(template, user);
				$(selector).html(output);
			});
		});

		this.get('#/user/phones', function () {
			setTitle("List");
			services.phones.getAll(
				function (phones) {
					$.get('templates/phones.html', function (template) {
						var output = Mustache.render(template, phones);
						$(selector).html(output);
					});
				}, function (error) {
					showAjaxError("Cannot load phones", error);
					app.router.setLocation("#/");
				});
		});

		this.get('#/user/add-phone', function () {
			setTitle("Add Phone");
			$(selector).load('./templates/add-phone.html');
		});

		this.get('#/user/edit-phone/:objectId', function () {
			setTitle("Edit Phone");
			var objectId = this.params['objectId'];
			services.phones.getById(objectId,
				function (phone) {
					$.get('templates/edit-phone.html', function(template) {
						var output = Mustache.render(template, phone);
						$(selector).html(output);
					});
				}, function (error) {
					showAjaxError("Cannot load phone", error);
					app.router.setLocation("#/user/phones");
				}
			);
		});

		this.get('#/user/delete-phone/:objectId', function () {
			setTitle("Delete Phone");
			var objectId = this.params['objectId'];
			services.phones.getById(objectId,
				function (phone) {
					$.get('templates/delete-phone.html', function(template) {
						var output = Mustache.render(template, phone);
						$(selector).html(output);
					});
				}, function (error) {
					showAjaxError("Cannot load phone", error);
					app.router.setLocation("#/phones");
				}
			);
		});

		this.get('#/user/edit-profile', function () {
			setTitle("Edit Profile");
			var currentUser = app.userSession.getCurrentUser();
			services.users.getById(currentUser.objectId,
				function (user) {
					$.get('templates/edit-profile.html', function(template) {
						var output = Mustache.render(template, user);
						$(selector).html(output);
					});
				}, function (error) {
					showAjaxError("Cannot load user profile", error);
					app.router.setLocation("#/");
				}
			);
		});

		this.get('#/do-login', function () {
			var username = $("#username").val();
			var password = $("#password").val();
			services.users.login(username, password,
				function (data) {
					showInfoMessage("Login successful");
					app.router.setLocation("#/user/home");
				},
				function (error) {
					showAjaxError("Login failed", error);
					app.router.setLocation("#/login");
				});
		});

		this.get('#/do-register', function () {
			var username = $("#username").val();
			var password = $("#password").val();
			var fullName = $("#fullName").val();
			services.users.register(username, password, fullName,
				function (data) {
					showInfoMessage("Registration successful");
					app.router.setLocation("#/user/home");
				},
				function (error) {
					showAjaxError("Registration failed", error);
					app.router.setLocation("#/register");
				});
		});

		this.get('#/user/do-add-phone', function () {
			var phone = {
				person: $("#personName").val(),
				number: $("#phoneNumber").val()
			};
			var currentUser = app.userSession.getCurrentUser();
			services.phones.add(phone, currentUser.objectId,
				function (data) {
					showInfoMessage("Phone added");
					app.router.setLocation("#/user/phones");
				},
				function (error) {
					showAjaxError("Phone add failed", error);
					app.router.setLocation("#/user/add-phone");
				});
		});

		this.get('#/user/do-edit-phone', function () {
			var phone = {
				objectId: $("#edit-phone-form").data('object-id'),
				person: $("#personName").val(),
				number: $("#phoneNumber").val()
			};
			services.phones.update(phone,
				function (data) {
					showInfoMessage("Phone edited");
					app.router.setLocation("#/user/phones");
				},
				function (error) {
					showAjaxError("Phone edit failed", error);
					app.router.setLocation("#/user/phones");
				});
		});

		this.get('#/user/do-delete-phone', function () {
			var objectId = $("#delete-phone-form").data('object-id');
			services.phones.delete(objectId,
				function (data) {
					showInfoMessage("Phone deleted");
					app.router.setLocation("#/user/phones");
				},
				function (error) {
					showAjaxError("Phone delete failed", error);
					app.router.setLocation("#/user/phones");
				});
		});

		this.get('#/user/do-edit-profile', function () {
			var phone = {
				objectId: $("#edit-profile-form").data('object-id'),
				username: $("#username").val(),
				password: $("#password").val(),
				fullName: $("#fullName").val()
			};
			services.users.editProfile(phone,
				function (data) {
					showInfoMessage("Profile edited");
					var currentUser = app.userSession.getCurrentUser();
					currentUser.username = phone.username;
					currentUser.fullName = phone.fullName;
					app.userSession.login(currentUser);
					app.router.setLocation("#/");
				},
				function (error) {
					showAjaxError("Profile edit failed", error);
					app.router.setLocation("#/user/edit-profile");
				});
		});
	});

	app.router.run('#/');

	function setTitle(title) {
		var $titleSpan = $("#header span");
		if (title) {
			$titleSpan.html(' - ' + title);
		} else {
			$titleSpan.html('');
		}
	}

	function showAjaxError(msg, error) {
		var errMsg = error.responseJSON;
		if (errMsg && errMsg.error) {
			showErrorMessage(msg + ": " + errMsg.error);
		} else {
			showErrorMessage(msg + ".");
		}
	}

	function showInfoMessage(msg) {
		noty({
				text: msg,
				type: 'info',
				layout: 'topCenter',
				timeout: 1000}
		);
	}

	function showErrorMessage(msg) {
		noty({
				text: msg,
				type: 'error',
				layout: 'topCenter',
				timeout: 5000}
		);
	}
}());

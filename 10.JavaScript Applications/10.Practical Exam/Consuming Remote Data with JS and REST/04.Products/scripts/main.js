var app = app || {};
(function () {
    var rootUrl = 'https://api.parse.com/1/';
    var ajaxRequester = app.ajaxRequester.get();
    var data = app.data.get(rootUrl, ajaxRequester);
    var controller = app.controller.get(data);
    controller.attachEventHandlers();

    $('#header').load('./templates/main-menu.html', function () {
        app.router = Sammy(function () {
            var selectorMain = '#main';
            this.get('#/', function () {
                $(selectorMain).load('./templates/welcome-guest.html');
            });
            this.get('#/login', function () {
                $(selectorMain).load('./templates/login-form.html');
            });
            this.get('#/register', function () {
                $(selectorMain).load('./templates/registration-form.html');
            });
        });

        app.router.run('#/');
    });

}());
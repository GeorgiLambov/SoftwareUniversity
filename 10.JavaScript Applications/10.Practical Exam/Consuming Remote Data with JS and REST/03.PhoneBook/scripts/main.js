var app = app || {};
(function () {
    var rootUrl = 'https://api.parse.com/1/';
    var ajaxRequester = app.ajaxRequester.get();
    var data = app.data.get(rootUrl, ajaxRequester);
    var controller = app.controller.get(data);
    controller.attachEventHandlers();

    app.router = Sammy(function () {
        var selector = '#wrapper';

        //  if (!userSessionData.getSessionToken()) {
        this.get('#/', function () {
            $('#text-header').text(' - Welcome');
            $(selector).load('./templates/welcome-screen.html');
        });
        this.get('#/login', function () {
            controller.loadLogin(selector);
        });
        this.get('#/register', function () {
            controller.loadRegister(selector);
        });
        //} else {
        //    controller.loadHome(selector);
        //}
    });

    app.router.run('#/');
}());
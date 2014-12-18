var bookApp = bookApp || {};
(function () {
    var rootUrl = 'https://api.parse.com/1/';
    var ajaxRequester = bookApp.ajaxRequester.get();
    var data = bookApp.data.get(rootUrl, ajaxRequester);
    var controller = bookApp.controller.get(data);
    controller.attachEventHandlers();

    bookApp.router = Sammy(function () {
        var selector = '#wrapper';

        if (!userSessionData.getSessionToken()) {

            this.get('#/login', function () {
                controller.loadLogin(selector);
            });

            this.get('#/register', function () {
                controller.loadRegister(selector);
            });
        } else {
            controller.loadBooks(selector);
        }
        this.get('#/', function () {
            controller.loadHome(selector);
        });
    });

    bookApp.router.run('#/');
}());
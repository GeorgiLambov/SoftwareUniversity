var app = app || {};

(function() {
    var baseUrl = "https://api.parse.com/1/";
    var ajaxRequester = app.ajaxRequester.get();
    var data = app.data.get(baseUrl, ajaxRequester);
    var controller = app.controller.get(data);
    controller.attachEventHandlers();

    app.router = Sammy(function () {
        var mainSelector = '#main',
            menuSelector = '#menu';

        this.get('#/', function (){
            controller.loadMenu(menuSelector);
            controller.loadHome(mainSelector);
        });

        this.get('#/home', function (){
            controller.loadMenu(menuSelector);
            controller.loadHome(mainSelector);
        });

        this.get('#/login', function () {
            controller.loadMenu(menuSelector);
            controller.loadLogin(mainSelector);
        });

        this.get('#/register', function () {
            controller.loadMenu(menuSelector);
            controller.loadRegister(mainSelector);
        });

        this.get('#/products', function () {
            controller.loadMenu(menuSelector);
            controller.loadProducts(mainSelector);
        });

        this.get('#/add', function () {
            controller.loadMenu(menuSelector);
            controller.loadAddProduct(mainSelector);
        });

        this.get('#/delete/:id', function () {
            controller.loadDeleteProduct(mainSelector, this.params['id']);
            controller.loadMenu(menuSelector);
        });

        this.get('#/edit/:id', function () {
            controller.loadEditProduct(mainSelector, this.params['id']);
            controller.loadMenu(menuSelector);
        });

        this.get('#/logout', function () {
            controller.logout();
            this.redirect('#/');
        });
    });

    app.router.run('#/');

}());


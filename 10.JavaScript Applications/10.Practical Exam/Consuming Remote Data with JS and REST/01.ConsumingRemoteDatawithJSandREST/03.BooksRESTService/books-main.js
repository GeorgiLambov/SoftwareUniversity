(function () {
    var rootUrl = 'https://api.parse.com/1/classes/';
    var dataPersister = booksApp.dataPersister.get(rootUrl);
    var views = booksApp.view.getPrinter();
    var controller = booksApp.controller.get(dataPersister, views);
    controller.load('#wrapper');
}());
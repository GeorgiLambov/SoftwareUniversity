(function () {
    var rootUrl = 'https://api.parse.com/1/classes/';
    var dataPersister = studentsApp.dataPersister.get(rootUrl);
    var controller = studentsApp.controller.get(dataPersister);
    controller.load('#wrapper');
}());
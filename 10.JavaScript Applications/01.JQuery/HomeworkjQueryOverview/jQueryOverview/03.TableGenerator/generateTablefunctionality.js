(function () {

    $(document).ready(function () {
        $('#submitButton').on('click', generateTable);

    });

    function generateTable() {

        var inputStringJSON = '[{"manufacturer":"BMW","model":"E92 320i","year":2011,"price":50000,"class":"Family"},' +
                       '{"manufacturer":"Porsche","model":"Panamera","year":2012,"price":100000,"class":"Sport"},' +
                       '{"manufacturer":"Peugeot","model":"305","year":1978,"price":1000,"class":"Family"}]';

        var input = JSON.parse(inputStringJSON),
             keys = Object.keys(input[0]);

        var table = $("<table>");
        var thead = $("<thead>");
        var thRow = $("<tr>");

        for (var thCol = 0; thCol < keys.length; thCol++) {
            thRow.append($('<th>').text(keys[thCol]));
        }
        thead.append(thRow);

        table.append(thead);

        var tbody = $("<tbody>");

        for (var row = 0; row < input.length; row++) {
            var tbodyRow = $("<tr>");

            for (var key in input[row]) {
                tbodyRow.append($('<td>').text(input[row][key]));
            }

            tbody.append(tbodyRow);
        }

        table.append(tbody);
        table.appendTo($("#table-container"));
    }
}());
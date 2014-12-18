var booksApp = booksApp || {};

booksApp.view = (function () {
    'use strict';

    var Printer = (function () {
        function Printer() {
        }
        Printer.prototype.printBooks = function (data) {
            $('#all-books').html('');
            var selector = '#all-books';
            var allBooksWrapper = $(selector);

            for (var i = 0; i < data.results.length; i++) {
                var book = data.results[i];
                attachItemToDom(allBooksWrapper, book);
            };
        };

        function attachItemToDom(element, item) {
            var itemWrapper = $('<tr />');
            itemWrapper.attr('data-id', item.objectId);

            var title = $('<td />').text(item.title).attr('class', 'title');
            var author = $('<td />').text(item.author).attr('class', 'author');
            var isbn = $('<td />').text(item.isbn).attr('class', 'isbn');

            var buttons = $('<td />');
            var deleteButton = $('<button class="book-delete-btn">DELL</button>').css("background", "red");
            var editButton = $('<button class="book-edit-btn">Edit</button>');

            buttons.append(deleteButton).append(editButton);

            itemWrapper.append(title);
            itemWrapper.append(author);
            itemWrapper.append(isbn);
            itemWrapper.append(buttons);

            element.append(itemWrapper);
        }

        return Printer;
    }());

    return {
        getPrinter: function () {
            return new Printer();
        }
    }
}());
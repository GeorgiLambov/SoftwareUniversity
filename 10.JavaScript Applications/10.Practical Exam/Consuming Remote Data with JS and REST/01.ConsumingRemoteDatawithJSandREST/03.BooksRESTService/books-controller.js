var booksApp = booksApp || {};

booksApp.controller = (function () {
    'use strict';
    function Controller(dataPersister, views) {
        this.persister = dataPersister;
        this.view = views;
    }
    Controller.prototype.load = function () {
        this.attachEvents();
        this.ListAllBooks();
    };

    Controller.prototype.ListAllBooks = function () {
        var _this = this;
        this.persister.booksRepository.getAll(
            function (data) {
                _this.view.printBooks(data);
            },
            function (error) {
                console.log(error);
            });
    };

    Controller.prototype.attachEvents = function () {

        var _this = this;

        $('#add-book').on('click', function (ev) {
            var book = {
                title: $('#title').val(),
                author: $('#author').val(),
                isbn: $('#isbn').val()
            };
            _this.persister.booksRepository.add(
                book,
				function addItemtSuccessHandler(data) {
				    _this.ListAllBooks();
				    $('#title').val('');
				    $('#author').val('');
				    $('#isbn').val('');
				},
				function addItemErrorHandler(error) {
				    console.log(error);
				}
			);
        });

        $('#all-books').on('click', '.book-delete-btn', function (ev) {
            var id = $(this).parent().parent().attr('data-id');
            _this.persister.booksRepository.delete(
				id,
                function deleteItemSuccessHandler(data) {
                    $(ev.target).parent().parent().remove();
                },
				function deleteItemErrorHandler(error) {
				    console.log(error);
				}
			);
        });

        $('#all-books').on('click', '.book-edit-btn', function (ev) {
            //var id = $(this).parent().parent().attr('data-id');

            var $book = $(ev.target).parent().parent();

            var editBook = {
                title: $book.find('.title').text(),
                author: $book.find('.author').text(),
                isbn: $book.find('.isbn').text(),
                objectId: $book.attr('data-id')
            };

            $('#title').val(editBook.title).focus();
            $('#author').val(editBook.author);
            $('#isbn').val(editBook.isbn);
            $('tfoot > tr').attr('data-id', editBook.objectId);

            $('#all-books').hide();
            $('#add-book').hide();
            $('#edit-book').show();

        });

        $('#edit-book').on('click', function (ev) {

            var $book = $(ev.target).parent().parent();
            var id = $book.attr('data-id');
            var book = {
                title: $('#title').val(),
                author: $('#author').val(),
                isbn: $('#isbn').val()
            };
            _this.persister.booksRepository.edit(
                id,
                book,
                function editItemSuccessHandler() {
                    _this.ListAllBooks();
                    $('#all-books').show();
                    $('#edit-book').hide();
                    $('#add-book').show();
                    $('#title').val('');
                    $('#author').val('');
                    $('#isbn').val('');
                },
                function editItemErrorHandler(error) {
                    console.log(error);
                }
            );
        });
    };

    return {
        get: function (dataPersister, views) {
            return new Controller(dataPersister, views);
        }
    };
}());
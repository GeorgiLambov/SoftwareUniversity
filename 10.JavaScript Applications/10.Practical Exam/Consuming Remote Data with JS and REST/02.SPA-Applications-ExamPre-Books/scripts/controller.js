var bookApp = bookApp || {};
'use strict'
bookApp.controller = (function () {
    function BaseController(data) {
        this._data = data;
    }

    BaseController.prototype.loadHome = function (selector) {
        $(selector).load('./templates/home.html');
        $('#reg').show();
        $('#home').show();
        $('#log').show();
    }

    BaseController.prototype.loadLogin = function (selector) {
        $('#reg').show();
        $('#log').show();
        $(selector).load('./templates/login.html');
    }

    BaseController.prototype.loadRegister = function (selector) {
        $('#reg').show();
        $('#log').show();
        $(selector).load('./templates/register.html');
    }

    BaseController.prototype.loadBooks = function (selector) {
        if (!this._data.users.validateToken()) {
            $('#reg').hide();
            $('#log').hide();
            $('#home').hide();
            
            this._data.books.getAll()
                .then(function (data) {
                    $.get('templates/books.html', function (template) {
                        var output = Mustache.render(template, data);
                        $(selector).html(output);

                        $(selector).prepend($('<div>').attr('id', 'logout-row')
                            .text('Welcome ' + localStorage.userName + '!')
                            .append($('<input>').attr('type', 'button').attr('id', 'logoutButton').attr('value', 'Logout')))
                    })
                }, function (error) {
                    console.log(error);
                });
        } else {
            $(selector).load('./templates/home.html');
        }
    }

    BaseController.prototype.attachEventHandlers = function () {
        var selector = '#wrapper';
        attachLoginHandler.call(this, selector);      // this e konkretnata instancia na Basecontroler
        attachRegisterHandler.call(this, selector);
        attachCreateBookHandler.call(this, selector);
        attachDeleteBookHandler.call(this, selector);
        attachEditBookHandler.call(this, selector);
        attachLogOUTHandler.call(this, selector);
    }

    var attachRegisterHandler = function (selector) {
        var _this = this;                                     // this v event e konkretnia button
        $(selector).on('click', '#register', function () {       // ako ne podadene this, shte e window
            var username = $('#username').val();
            var password = $('#password').val();
            if (!username || !password) {
                alert('The name and password must be non-empty string');
            } else {
                _this._data.users.register(username, password)
                    .then(function (data) {
                        alert('Hello ' + username);
                        //window.history.replaceState('Books', 'Books', '#/books');
                        _this.loadBooks(selector);
                        // window.parent.location = "#/books";
                        // return data;
                    },
                        function (error) {
                            alert('Error - Unsuccessful registration!');
                        });
            };
        });
    }

    var attachLoginHandler = function (selector) {
        var _this = this;
        $(selector).on('click', '#login', function () {
            var username = $('#username').val();
            var password = $('#password').val();
            if (!username || !password) {
                _this.loadLogin(selector);
                return alert('The name and password must be non-empty string');
            } else {
                _this._data.users.login(username, password)
                    .then(function (data) {
                        _this.loadBooks(selector);
                        // window.parent.location = "#/books";
                    },
                    function (error) {
                        _this.loadRegister(selector);
                        console.log(error);
                        alert('Invalid login!');
                    });
            };
        });
    }

    var attachLogOUTHandler = function (selector) {
        var _this = this;
        $(selector).on('click', '#logoutButton', function () {
            _this._data.users.logOUT()
            $('#logout-row').remove();
            _this.loadHome(selector);
            window.location.replace("#/");
        })
    }

    var attachCreateBookHandler = function (selector) {
        var _this = this;
        $(selector).on('click', '#add-book', function (ev) {
            var book = {
                title: $('#title').val(),
                author: $('#author').val(),
                isbn: $('#isbn').val(),
                ACL: {}
            };
            var userId = userSessionData.getUserObjectId();
            book.ACL[userId] = {
                "write": true,
                "read": true
            }

            _this._data.books.add(book)
				.then(function (data) {
				    // _this.loadBooks('#wrapper');     //prezarejda vsichki knigi 

				    _this._data.books.getById(data.objectId)
                .then(function (book) {
                    $.get('templates/book.html', function (template) {
                        var row = Mustache.render(template, book);
                        $('tbody').append(row);
                    })
                    $('input').val('');
                    return data;
                }, function (error) {
                    console.log(error);
                });
				    return data;
				}, function (error) {
				    console.log(error);
				});
        });
    }

    var attachDeleteBookHandler = function (selector) {
        var _this = this;
        $(selector).on('click', '.delete-book-btn', function (ev) {
            var deleteConfirmed = confirm('Do you want to delete this book!');
            if (deleteConfirmed) {
                var objectId = $(this).closest('tr').data('id');
                //var objectId = $(this).parent().parent().data('id');
                _this._data.books.delete(objectId)
					.then(function () {
					    $(ev.target).closest('tr').remove();
					},
					function (error) {
					    console.log(error);
					})
            };
        })
    }

    var attachEditBookHandler = function (selector) {          // atthach whit EDIT Buton
        var _this = this;
        var objectId;
        $(selector).on('click', '.book-edit-btn', function () {
            objectId = $(this).parent().parent().data('id');

            _this._data.books.getById(objectId)
                .then(function (data) {
                    $('#title').val(data.title).focus();
                    $('#author').val(data.author);
                    $('#isbn').val(data.isbn);

                    $('#all-books').hide();
                    $('#add-book').hide();
                    $('#edit-book').show();

                }, function (error) {
                    console.log(error);
                });
        });

        $(selector).on('click', '#edit-book', function () {
            var book = {
                title: $('#title').val(),
                author: $('#author').val(),
                isbn: $('#isbn').val()
            };
            _this._data.books.edit(book, objectId)
              .then(function () {
                  _this.loadBooks('#wrapper');   // prezarevda vs knigi i izliza na sahstoto miasto
                  $('#all-books').show();
                  $('#edit-book').hide();
                  $('#add-book').show();
                  $('#title').val('');
                  $('#author').val('');
                  $('#isbn').val('');
              },
              function (error) {
                  console.log(error);
              })
        });
    }


    //var attachEditBookHandler = function (selector) {
    //    var _selfInstanse = this;

    //    $(selector).on('click', 'td.title, td.author, td.isbn', function () {
    //        var _this, oldValue, _input, classType;
    //        _this = $(this);
    //        oldValue = _this.text();
    //        classType = _this.attr('class');
    //        _input = $("<input/>", {
    //            "class": "xlarge",
    //            value: oldValue,
    //            data: {
    //                old_value: oldValue,
    //                classType: classType
    //            },
    //            autofocus: true
    //        });

    //        _this.html(_input);
    //    });

    //    $(selector).on("focusout keydown mouseleave", "td input.xlarge", function (e) {
    //        var _this, val, oldVal, objectId, book, classType;

    //        if (e.type === 'keydown' && e.which !== 13) {
    //            return true;
    //        }

    //        _this = $(this);
    //        val = _this.val();
    //        oldVal = _this.data('old_value');
    //        classType = _this.data('classType');

    //        if (oldVal === val) {
    //            _this.parent().text(val);
    //            return false;
    //        }

    //        objectId = _this.closest('tr').data('id');
    //        if (!objectId) {
    //            _this.parent().text(val);
    //            Console.log('Erro ID!!!');
    //        }

    //        //if (classType == 'title') {
    //        //    book.title = val;
    //        //}
    //        book = {
    //            title: val,
    //            author: val,
    //            isbn: val
    //        };

    //        _selfInstanse._data.books.edit(book, objectId)
    //            .then(function () { }, function (error) {
    //                console.log(error);
    //            });

    //        return _this.parent().text(val);
    //    });
    //};

    return {
        get: function (data) {
            return new BaseController(data);
        }
    }
}());

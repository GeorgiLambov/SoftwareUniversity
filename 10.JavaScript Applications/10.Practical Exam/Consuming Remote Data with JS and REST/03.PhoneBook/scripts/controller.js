var app = app || {};

app.controller = (function () {
    'use strict'
    function BaseController(data) {
        this._data = data;
    }

    BaseController.prototype.loadRegister = function (selector) {
        $('#text-header').text(' - Registration');
        $(selector).load('./templates/register-form.html');
    }

    BaseController.prototype.loadLogin = function (selector) {
        $('#text-header').text(' - Login');
        $(selector).load('./templates/login-form.html');
    }

    BaseController.prototype.loadHome = function (selectorWrapper) {
        var SessionToken = userSessionData.getSessionToken();

        $(selectorWrapper).load('./templates/user-home-screen.html');
        $('#menu-span').load('./templates/left-sidebar-menu.html');
        if (SessionToken) {
            this._data.users.validateToken()
                .then(function (data) {
                    if (SessionToken === data.sessionToken) {
                        var userName = data.username;
                        var userFullName = data.fullName;
                        $('#menu').show();
                        $('#text-header').text(' - Home');
                        $('#welome-name').text(userFullName + '(' + userName + ')');
                    }
                }, function (error) {
                    console.log('Error validateToken');
                });
        }
    }

    BaseController.prototype.loadPhonebook = function () {
        $('#text-header').text(' - List');
        this._data.phones.getAll()
                     .then(function (data) {
                         $.get('templates/phonebook-table.html', function (template) {
                             var output = Mustache.render(template, data);
                             $('#wrapper').html(output);
                             showSuccessMessage("Load phonebook is Done!!")
                         })
                     }, function (error) {
                         //console.log(error);
                         showAjaxError("Unable to load requested data!", error);
                     });
    }

    BaseController.prototype.attachEventHandlers = function () {
        var selectorWrapper = '#wrapper';
        var selectorMenu = '#menu-span';
        // this e konkretnata instancia na Basecontroler
        attachRegisterHandler.call(this, selectorWrapper);
        attachLoginHandler.call(this, selectorWrapper);
        attachCreatePhoneHandler.call(this, selectorWrapper);

        attachHOMEHandler.call(this, selectorMenu);
        attachListAllPhones.call(this, selectorMenu);
        attachDeletePhoneHandler.call(this, selectorWrapper);
        attachEditPhoneHandler.call(this, selectorWrapper);
        attachLogOUTHandler.call(this, selectorMenu);
        attachEditUserHandler.call(this, selectorMenu);
    }

    var attachHOMEHandler = function (selectorMenu) {
        var _this = this;
        $(selectorMenu).on('click', '#home-button', function () {
            _this.loadHome('#wrapper');
        });
    }

    var attachRegisterHandler = function (selectorWrapper) {
        var _this = this;                                     // this v event e konkretnia button
        $(selectorWrapper).on('click', '#register-button', function () {       // ako ne podadene this, shte e window
            var username = $('#username').val();
            var password = $('#password').val();
            var fullName = $('#fullName').val();
            if (!username || !password || !fullName) {
                alert('The name and password must be non-empty string');
            } else {
                _this._data.users.register(username, password, fullName)
                          .then(function (data) {
                              //alert('Hello ' + username);
                              _this.loadHome(selectorWrapper);
                              showSuccessMessage('Register Success!!');
                              //window.history.replaceState('Books', 'Books', '#/books');
                              // window.parent.location = "#/books";
                          },
                         function (error) {
                             //alert('Error - Unsuccessful registration!');
                             showAjaxError("Invalid Register", error);
                         });
            };
        });
    }

    var attachLoginHandler = function (selectorWrapper) {
        var _this = this;
        $(selectorWrapper).on('click', '#login-button', function () {
            var username = $('#username').val();
            var password = $('#password').val();
            if (!username || !password) {
                _this.loadLogin(selectorWrapper);
                return alert('The name and password must be non-empty string');
            } else {
                _this._data.users.login(username, password)
                       .then(function (data) {
                           _this.loadHome(selectorWrapper);
                           showSuccessMessage('Login Success!');
                           // window.parent.location = "#/books";
                       },
                    function (error) {
                        showAjaxError("Invalid login", error);
                        _this.loadLogin(selectorWrapper);
                        //alert('Invalid login!');
                    });
            };
        });
    }

    var attachLogOUTHandler = function (selectorMenu) {
        var _this = this;
        $(selectorMenu).on('click', '#logout-button', function () {
            _this._data.users.logOUT()
            $('#menu').hide();
            _this.loadLogin('#wrapper');
            showSuccessMessage("Logout successful");
        })
    }

    var attachEditUserHandler = function (selectorMenu) {
        var _this = this;
        var userName, userFullName, userId;
        $(selectorMenu).on('click', '#edit-user-buton', function () {
            _this._data.users.validateToken()           // ima gi v userSessiondata moje i fullname da se setne tam
                   .then(function (data) {
                       userName = data.username;
                       userFullName = data.fullName;
                       userId = data.objectId;
                       $('#wrapper').load('./templates/edit-user-profile-screen.html', function () {
                           $('#text-header').text(' - Edit Profile');
                           $('#username').attr('value', userName);
                           $('#password').attr('value', '');
                           $('#fullName').attr('value', userFullName);
                       }, function (error) {
                           console.log('Error validateToken');
                       });

                   });
        });

        $('#wrapper').on('click', '#edit-user-confirm-btn', function () {

            var user = {
                username: $('#username').val(),
                password: $('#password').val(),
                fullName: $('#fullName').val()
            };
            if (!username || !password || !fullName) {
                alert('The name and password must be non-empty string');
            } else {
                _this._data.users.edit(user, userId)
                          .then(function (data) {
                              _this.loadPhonebook();
                              showSuccessMessage('Edit user data Success!');
                          },
                         function (error) {
                             //console.log(error);
                             showAjaxError('Edit user eroor:', error);
                         })
            }
        });

        $('#wrapper').on('click', '#edit-user-cancel-btn', function () {
            _this.loadHome();
        });
    }

    var attachListAllPhones = function (selectorMenu) {
        var _this = this;
        $(selectorMenu).on('click', '#list-phonebook', function (ev) {
            _this.loadPhonebook();
        });
    }

    var attachCreatePhoneHandler = function (selectorWrapper) {
        var _this = this;

        $(selectorWrapper).on('click', '#add-phone', function (ev) {
            $(selectorWrapper).load('./templates/add-phone-screen.html', function () {
                $('#text-header').text(' - Add Phone');
            });
        });

        $(selectorWrapper).on('click', '#add-phone-menu', function (ev) {
            var phone = {
                name: $('#personName').val(),
                phone: $('#phoneNumber').val(),
                ACL: {}
            };
            var userId = userSessionData.getUserObjectId();
            phone.ACL[userId] = { "write": true, "read": true };

            _this._data.phones.add(phone)
                            .then(function (data) {
                                showSuccessMessage("Phone added successfully!");
                                _this.loadPhonebook();
                            }, function (error) {
                                //console.log(error);
                                showAjaxError("Phone was not added due to error", error);
                            });
        });

        $(selectorWrapper).on('click', '#cancel-phone-menu', function () {
            _this.loadPhonebook();
        });
    }

    var attachDeletePhoneHandler = function (selectorWrapper) {
        var _this = this;
        var objectId, name, phone;

        $(selectorWrapper).on('click', '.delete-phone-btn', function (ev) {
            objectId = $(this).closest('tr').data('id');
            _this._data.phones.getById(objectId)
                   .then(function (data) {
                       name = data.name;
                       phone = data.phone;
                       $(selectorWrapper).load('./templates/delete-phone-screen.html', function () {
                           $('#text-header').text(' - Delete Phone');
                           $('#personName').attr('value', name);
                           $('#phoneNumber').attr('value', phone);
                       });
                   }, function (error) {
                       console.log(error);
                   });
        })

        $(selectorWrapper).on('click', '#delete-confirm-btn', function () {
            _this._data.phones.delete(objectId)
                        .then(function () {
                            _this.loadPhonebook();
                            showSuccessMessage('Phone was add!!');
                            //$(ev.target).closest('tr').remove();
                        },
                       function (error) {
                           showAjaxError("Phone was not deleted!", error)
                       })
        });

        $(selectorWrapper).on('click', '#delete-cancel-btn', function () {
            _this.loadPhonebook();
        });

    }

    var attachEditPhoneHandler = function (selectorWrapper) {          // atthach whit EDIT Buton
        var _this = this;
        var objectId, name, phone;

        $(selectorWrapper).on('click', '.edit-phone-btn', function () {
            objectId = $(this).closest('tr').data('id');
            _this._data.phones.getById(objectId)
               .then(function (data) {
                   name = data.name;
                   phone = data.phone;
                   $(selectorWrapper).load('./templates/edit-phone-screen.html', function () {
                       $('#text-header').text(' - Edit Phone');
                       $('#personName').attr('value', name);
                       $('#phoneNumber').attr('value', phone);
                   });
               }, function (error) {
                   console.log(error);
               });
        })

        $(selectorWrapper).on('click', '#edit-confirm-btn', function () {
            var phone = {
                name: $('#personName').val(),
                phone: $('#phoneNumber').val()
            };

            _this._data.phones.edit(phone, objectId)
                        .then(function () {
                            _this.loadPhonebook();
                            showSuccessMessage('Phone was eddit sucsesful!');
                        },
                       function (error) {
                           showAjaxError("Invalid edit!", error);
                       })
        });

        $(selectorWrapper).on('click', '#edit-cancel-btn', function () {
            _this.loadPhonebook();
        });
    }

    // Noty
    function showAjaxError(message, error) {
        var errorMessage = error.responseJSON;
        if (errorMessage && errorMessage.error) {
            showErrorMessage(message + ": " + errorMessage.error);
        } else {
            showErrorMessage(message + ".");
        }
    }

    function showSuccessMessage(message) {
        noty({
            text: message,
            type: 'success',
            layout: 'topCenter',
            timeout: 2000
        }
        );
    }

    function showErrorMessage(message) {
        noty({
            text: message,
            type: 'error',
            layout: 'topCenter',
            timeout: 5000
        }
        );
    }

    return {
        get: function (data) {
            return new BaseController(data);
        }
    }
}());




//$.get('templates/phonebook-table', function (template) {
//    var output = Mustache.render(template, data);
//    $('#wrapper').html(output);                     za pechat na vs s must
//})

//    _this._data.phones.getById(data.objectId)              za pechat na edno
//.then(function (phone) {
//    $.get('templates/phone.html', function (template) {
//        var row = Mustache.render(template, phone);
//        $('tbody').append(row);
//    })
//    $('input').val(''); 
//    return data;
//}, function (error) {
//    console.log(error);
//});


//  window.location.replace("#/");

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
var app = app || {};

app.controller = (function () {
    'use strict'
    var selectorMain = '#main';
    var selectorMenu = '#header';

    function BaseController(data) {
        this._data = data;
    }

    BaseController.prototype.loadMainMenu = function () {
        window.parent.location = "#/";
        $(selectorMenu).load('./templates/main-menu.html');
    }

    BaseController.prototype.loadUserHomeMenu = function () {
        var _this = this;
        $(selectorMenu).load('./templates/user-menu.html', function () {
            $(selectorMain).load('./templates/welcome-user.html', function () {
                _this._data.users.validateToken()
                    .then(function (data) {
                        var userName = data.username;
                        $('#userName').text(userName);
                    });
            });
        });
    }

    BaseController.prototype.loadProducts = function () {
        var _this = this;
        this._data.products.getAll()
                     .then(function (data) {
                         $.get('templates/products-list.html', function (template) {
                             var products = data.results;
                             var userId = _this._data.users.getUserData().userId;

                             products.forEach(function (pr) {
                                 if (pr.ACL[userId]) {
                                     pr.showButtons = true;
                                 }
                             });

                             var output = Mustache.render(template, data);
                             $(selectorMain).html(output);
                             showSuccessMessage("Load products is Done!!")
                         })
                     }, function (error) {
                         showAjaxError("Unable to load requested data!", error);
                     });
    }

    BaseController.prototype.filterProducts = function () {
        var _this = this;
        this._data.products.getAll()
                     .then(function (data) {
                         var keyword = $('#search-bar').val();
                         var minPrice = parseFloat($('#min-price').val());
                         var maxPrice = parseFloat($('#max-price').val());
                         var category = $('#category').val();
                         var resultArr = data.results;

                         var results = resultArr.filter(function (product) {
                             var productName = product.name;
                             var productCategory = product.category
                             var productPrice = parseFloat(product.price);

                             return productName.contains(keyword) &&
                                    productCategory.contains(category) &&
                                    minPrice <= productPrice &&
                                    maxPrice >= productPrice;

                         })

                         $.get('templates/products-list.html', function (template) {
                             var userId = _this._data.users.getUserData().userId;
                             results.forEach(function (pr) {
                                 if (pr.ACL[userId]) {
                                     pr.showButtons = true;
                                 }
                             });
                             data.results = results;
                             var output = Mustache.render(template, data);
                             $(selectorMain).html(output);
                             showSuccessMessage("Load products is Done!!")
                         })
                     }, function (error) {
                         showAjaxError("Unable to load requested data!", error);
                     });
    }

    BaseController.prototype.attachEventHandlers = function () {

        attachRegisterHandler.call(this, selectorMain);
        attachLoginHandler.call(this, selectorMain);
        attachLogOUTHandler.call(this, selectorMenu);
        attachUserHomeHandler.call(this, selectorMenu);
        attacLoadProductsHandler.call(this, selectorMenu);
        attachCreateProductHandler.call(this, selectorMenu);
        attachEditProductHandler.call(this, selectorMain);
        attachDeleteProductHandler.call(this, selectorMain);
        attachFilterProductHandler.call(this, selectorMain);
    }

    var attachRegisterHandler = function (selectorMain) {
        var _this = this;
        $(selectorMain).on('click', '#register-button', function () {
            var username = $('#username').val();
            var password = $('#password').val();
            var confirmPassword = $('#confirm-password').val();
            if (!username || (password !== confirmPassword)) {
                showAjaxError("Invalid Register: Error confirm password!");
            } else {
                _this._data.users.register(username, password)
                          .then(function () {
                              _this.loadUserHomeMenu();
                              showSuccessMessage('Register Success!!');
                          },
                         function (error) {
                             showAjaxError("Invalid Register", error);
                         });
            };
        });
    }

    var attachLoginHandler = function (selectorMain) {
        var _this = this;
        $(selectorMain).on('click', '#login-button', function () {
            var username = $('#username').val();
            var password = $('#password').val();
            _this._data.users.login(username, password)
                         .then(function (data) {
                             _this.loadUserHomeMenu(selectorMain);
                             showSuccessMessage('Login Success!');
                         },
                      function (error) {
                          showAjaxError("Invalid login", error);
                      });
        });
    };

    var attachLogOUTHandler = function (selectorMenu) {
        var _this = this;
        $(selectorMenu).on('click', '#logout-button', function () {
            _this._data.users.logOUT()
            _this.loadMainMenu();              //todo main menu
            showSuccessMessage("Logout successful");
        })
    }

    var attachUserHomeHandler = function (selectorMenu) {
        var _this = this;
        $(selectorMenu).on('click', '#home-menu-button', function () {
            _this.loadUserHomeMenu();
        })
    }

    var attacLoadProductsHandler = function (selectorMenu) {
        var _this = this;
        $(selectorMenu).on('click', '#list-all-products', function () {
            _this.loadProducts();
        })
    }

    var attachCreateProductHandler = function (selectorMenu) {
        var _this = this;

        $(selectorMenu).on('click', '#add-product', function (ev) {
            $(selectorMain).load('./templates/add-product-form.html', function () {
            });
        });

        $(selectorMain).on('click', '#add-product-button', function (ev) {
            var product = {
                name: $('#product-name').val(),
                category: $('#product-category').val(),
                price: $('#product-price').val(),
                ACL: {}
            };
            var userId = userSessionData.getUserObjectId();
            product.ACL[userId] = { "write": true, "read": true };
            product.ACL["*"] = { "read": true };

            _this._data.products.add(product)
                            .then(function () {
                                showSuccessMessage("Product added successfully!");
                                _this.loadProducts();
                            }, function (error) {
                                //console.log(error);
                                showAjaxError("Product was not added due to error", error);
                            });
        });

        $(selectorMain).on('click', '#cancel-add-product', function () {
            _this.loadProducts();
        });
    }

    var attachEditProductHandler = function (selectorMain) {
        var _this = this;
        var objectId, name, category, price;

        $(selectorMain).on('click', '.edit-button', function () {
            objectId = $(this).closest('li').data('id');
            _this._data.products.getById(objectId)
               .then(function (data) {
                   name = data.name;
                   category = data.category;
                   price = data.price;
                   $(selectorMain).load('./templates/edit-product-form.html', function () {
                       $('#product-name').attr('value', name);
                       $('#product-category').attr('value', category);
                       $('#product-price').attr('value', price);
                   });
               }, function (error) {
                   console.log(error);
               });
        })

        $(selectorMain).on('click', '#edit-confirm-btn', function () {
            var product = {
                name: $('#product-name').val(),
                category: $('#product-category').val(),
                price: $('#product-price').val()
            };

            _this._data.products.edit(product, objectId)
                        .then(function () {
                            showSuccessMessage('Product was eddit sucsesful!');
                            _this.loadProducts();
                        },
                       function (error) {
                           showAjaxError("Invalid edit!", error);
                       })
        });

        $(selectorMain).on('click', '#edit-cancel-btn', function () {
            _this.loadProducts();
        });
    }

    var attachDeleteProductHandler = function (selectorMain) {
        var _this = this;
        var objectId, name, category, price;

        $(selectorMain).on('click', '.delete-button', function (ev) {
            objectId = $(this).closest('li').data('id');
            _this._data.products.getById(objectId)
                   .then(function (data) {
                       name = data.name;
                       category = data.category;
                       price = data.price;
                       $(selectorMain).load('./templates/delete-product-form.html', function () {
                           $('#name').attr('value', name);
                           $('#category').attr('value', category);
                           $('#price').attr('value', price);
                       });
                   }, function (error) {
                       console.log(error);
                   });
        })

        $(selectorMain).on('click', '#delete-confirm-btn', function () {
            _this._data.products.delete(objectId)
                        .then(function () {
                            _this.loadProducts();
                            showSuccessMessage('Product was dellete sucsesful!!');
                        },
                       function (error) {
                           showAjaxError("Product not dellete!!", error)
                       })
        });

        $(selectorMain).on('click', '#cancel-dell-button', function () {
            _this.loadProducts();
        });
    }

    var attachFilterProductHandler = function (selectorMain) {
        var _this = this;
        $(selectorMain).on('click', '#filter', function (ev) {
            _this.filterProducts();
        })
        $(selectorMain).on('click', '#clear-filters', function (ev) {
            _this.loadProducts();
            $('input').val('');
        })

    }

    String.prototype.contains = function (needle) {
        return this.toLowerCase().indexOf(needle.toLowerCase()) !== -1;
    }

    // Noty
    function showAjaxError(message, error) {
        if (error) {
            var errorMessage = error.responseJSON;
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

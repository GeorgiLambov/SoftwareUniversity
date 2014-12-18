function processRestaurantManagerCommands(commands) {
    'use strict';
    
    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };
    
    Object.prototype.validateNonEmptyString = function (value, variableName) {
        if (typeof (value) != 'string' || !value) {
            throw new Error("The {0} is required.".format(variableName));
        }
    };
    
    Object.prototype.validatePositiveInteger = function (value, variableName) {
        if (typeof (value) != 'number') {
            throw new Error(variableName + " should be a number.");
        }
        if (value !== parseInt(value, 10)) {
            throw new Error(variableName + " should be integer.");
        }
        if (value <= 0) {
            throw new Error("The {0} must be positive".format(variableName));
        }
    };
    
    String.prototype.repeat = function (num) {
        return new Array(num + 1).join(this);
    };
    
    if (!String.prototype.format) {
        String.prototype.format = function () {
            var args = arguments;
            return this.replace(/{(\d+)}/g, function (match, number) {
                return typeof args[number] != 'undefined'? args[number]: match;
            });
        };
    }
    
    Object.defineProperty(Array.prototype, "remove", {
        enumerable: false,
        value: function (item) {
            var removeCounter = 0;
            
            for (var index = 0; index < this.length; index++) {
                if (this[index] === item) {
                    this.splice(index, 1);
                    removeCounter++;
                    index--;
                }
            }
            return removeCounter;
        }
    });
    
    
    
    var RestaurantEngine = (function () {
        var _restaurants, _recipes;
        
        var MetricUnit = {
            "Grams": 'g',
            "Milliliters" : 'ml'
        };
        
        function initialize() {
            _restaurants = [];
            _recipes = [];
        }
        
        var Restaurant = (function () {
            function Restaurant(name, location) {
                this.setName(name);
                this.setLocation(location);
                this._recipes = [];  //this.setRecipe();
            }
            
            //Restaurant.prototype.setRecipe = function () {
            //    this._recipes = [];
            //}
            
            //Restaurant.prototype.getResipe = function () {
            //    return this._recipes;
            //}
            Restaurant.prototype.getName = function () {
                return this._name;
            };
            Restaurant.prototype.setName = function (name) {
                this.validateNonEmptyString(name, "name");
                this._name = name;
            };
            Restaurant.prototype.getLocation = function () {
                return this._location;
            };
            Restaurant.prototype.setLocation = function (location) {
                this.validateNonEmptyString(location, "location");
                this._location = location;
            };
            Restaurant.prototype.addRecipe = function (recipe) {
                this._recipes.push(recipe);      // if (this._recipes.indexOf(recipe) == -1) { }
            };
            Restaurant.prototype.removeRecipe = function (recipe) {
                this._recipes.remove(recipe);      // var index = this._recipes.indexOf(recipe);
                                                   // this._recipes.splice(index, 1);
            };
            Restaurant.prototype.appendRecipesToMenu = function (menu, title, currentRecipes) {
                if (currentRecipes.length > 0) {
                    var sortedRecipes = currentRecipes.sort(function (a, b) {
                        return a.getName().localeCompare(b.getName());
                    });
                    var charset = '~'.repeat(5);
                    var recipeStr = "{0} {1} {0}\n".format(charset, title, charset);
                    
                    menu.push(recipeStr);
                    
                    for (var i = 0; i < sortedRecipes.length; i++) {
                        menu.push(sortedRecipes[i]);
                    }
                }
            };
            Restaurant.prototype.printRestaurantMenu = function () {
                var result = '';
                var asteriks = '' + '*'.repeat(5);
                result += "{0} {1} - {2} {0}\n".format(asteriks, this.getName(), this.getLocation());
                if (this._recipes.length == 0) {
                    result += "No recipes... yet\n";
                } else {
                    var menu = [];                  //if (recipe instanceof Drink) 
                    
                    var drinks = this._recipes.filter(function (recipe) { return recipe.constructor.name == "Drink"; });
                    this.appendRecipesToMenu(menu, "DRINKS", drinks);
                    
                    var salads = this._recipes.filter(function (recipe) { return recipe.constructor.name == "Salad"; });
                    this.appendRecipesToMenu(menu, "SALADS", salads);
                    
                    var mainCourses = this._recipes.filter(function (recipe) { return recipe.constructor.name == "MainCourse"; });
                    this.appendRecipesToMenu(menu, "MAIN COURSES", mainCourses);
                    
                    var desserts = this._recipes.filter(function (recipe) { return recipe.constructor.name == "Dessert"; });
                    this.appendRecipesToMenu(menu, "DESSERTS", desserts);
                    
                    
                    for (var i = 0; i < menu.length; i++) {
                        result += menu[i].toString();
                    }
                }
                
                return result;
            };
            return Restaurant;
        }());
        
        var Recipe = (function () {
            function Recipe(name, price, calories, quantity, timeToPrepare, unit) {
                if (this.constructor === Recipe) {
                    throw new Error("Can't instantiate abstract class Recipe.");
                }
                
                this.setName(name);
                this.setPrice(price);
                this.setCalories(calories);
                this.setQuantity(quantity);
                this.setTimeToPrepare(timeToPrepare);
                this.setUnit(unit);
            }
            
            Recipe.prototype.getName = function () {
                return this._name;
            };
            Recipe.prototype.setName = function (name) {
                this.validateNonEmptyString(name, "name");
                this._name = name;
            };
            Recipe.prototype.getPrice = function () {
                return this._price;
            };
            Recipe.prototype.setPrice = function (price) {
                this.validatePositiveInteger(price, "price");
                this._price = price;
            };
            Recipe.prototype.getCalories = function () {
                return this._calories;
            };
            Recipe.prototype.setCalories = function (calories) {
                this.validatePositiveInteger(calories, "calories");
                this._calories = calories;
            };
            Recipe.prototype.getQuantity = function () {
                return this._quantity;
            };
            Recipe.prototype.setQuantity = function (quantity) {
                this.validatePositiveInteger(quantity, "quantity");
                this._quantity = quantity;
            };
            Recipe.prototype.getTimeToPrepare = function () {
                return this._timeToPrepare;
            };
            Recipe.prototype.setTimeToPrepare = function (timeToPrepare) {
                this.validatePositiveInteger(timeToPrepare, "timeToPrepare");
                this._timeToPrepare = timeToPrepare;
            };
            Recipe.prototype.getUnit = function () {
                return this._unit;
            };
            Recipe.prototype.setUnit = function (unit) {
                this._unit = unit;
            };
            
            //function getUnitString() {
            //    switch (this.getUnit()) {
            //        case MetricUnit.Grams:
            //            return "g";
            //        case MetricUnit.Milliliters:
            //            return "ml";
            //        default:
            //            throw new Error("Invalid type of unit selected.");
            //    }
            //}
            Recipe.prototype.toString = function () {
                var result = '';
                result += "==  {0} == ${1}\n".format(this.getName(), this.getPrice().toFixed(2));
                result += "Per serving: {0} {1}, {2} kcal\n".format(this.getQuantity(), this.getUnit(), this.getCalories());
                result += "Ready in {0} minutes\n".format(this.getTimeToPrepare());
                
                return result;
            };
            
            return Recipe;
        }());
        
        var Drink = (function () {
            
            var MaxDrinkCalories = 100;
            var MaxDrinkTimeToPrepare = 20;
            
            function Drink(name, price, calories, quantity, timeToPrepare, isCarbonated) {
                Recipe.call(this, name, price, calories, quantity, timeToPrepare, MetricUnit.Milliliters);
                
                this.setIsCarbonated(isCarbonated);
            }
            
            Drink.extends(Recipe);
            
            Drink.prototype.getIsCarbonated = function () {
                return this._isCarbonated;
            };
            Drink.prototype.setIsCarbonated = function (isCarbonated) {
                this._isCarbonated = isCarbonated;
            };
            
            Drink.prototype.setCalories = function (calories) {
                //this.validatePositiveInteger(calories, "calories");
                Recipe.prototype.setCalories.call(this, calories);
                
                if (calories > MaxDrinkCalories) {
                    throw new Error("The calories in a drink must not be greater than { 0 }.".format(calories));
                }
                
                this._calories = calories;
            };
            
            Drink.prototype.setTimeToPrepare = function (timeToPrepare) {
                this.validatePositiveInteger(timeToPrepare, "timeToPrepare");
                if (timeToPrepare > MaxDrinkTimeToPrepare) {
                    throw new Error("The time to prepare a drink must not be greater than {0} minutes.".format(timeToPrepare));
                }
                
                this._timeToPrepare = timeToPrepare;
            };
            Drink.prototype.toString = function () {
                var carbonated = this.getIsCarbonated() ? "yes" : "no";
                return Recipe.prototype.toString.call(this) + "Carbonated: " + carbonated + "\n";
            };
            
            return Drink;
        }());
        
        var Meal = (function () {
            
            function Meal(name, price, calories, quantity, timeToPrepare, isVegan) {
                if (this.constructor === Meal) {
                    throw new Error("Can't instantiate abstract class Meal.");
                }
                
                Recipe.call(this, name, price, calories, quantity, timeToPrepare, MetricUnit.Grams);
                this.setIsVegan(isVegan);
            }
            
            Meal.extends(Recipe);
            
            Meal.prototype.getIsVegan = function () {
                return this._isVegan;
            };
            Meal.prototype.setIsVegan = function (isVegan) {
                this._isVegan = isVegan;
            };
            Meal.prototype.toggleVegan = function () {
                var isVegan = !this.getIsVegan();
                this.setIsVegan(isVegan);
            };
            Meal.prototype.toString = function () {
                var result = '';
                if (this.getIsVegan()) {
                    result += "[VEGAN] ";
                }
                return result + Recipe.prototype.toString.call(this);
            };
            return Meal;
        }());
        
        var Dessert = (function () {
            function  Dessert(name, price, calories, quantity, timeToPrepare, isVegan) {
                Meal.call(this, name, price, calories, quantity, timeToPrepare, isVegan);
                
                this._withSugar = true;
            }
            
            Dessert.extends(Meal);
            
            //Dessert.prototype.getWithSugar = function () {
            //    return this._widthSugar;
            //}
            
            //Dessert.prototype.setWithSugar = function (whitSugar) {
            //    this._withSugar = whitSugar;
            //}
            
            Dessert.prototype.toggleSugar = function () {
                this._withSugar = !this._withSugar;   //  this.setWithSugar(!(this.getWithSugar()));
            };
            Dessert.prototype.toString = function () {
                var result = '';
                if (!this._withSugar) {
                    result += "[NO SUGAR] ";
                }
                
                return result + Meal.prototype.toString.call(this);
            };
            return Dessert;
        }());
        
        var MainCourse = (function () {
            function MainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type) {
                Meal.call(this, name, price, calories, quantity, timeToPrepare, isVegan);
                
                this.setType(type);
            }
            
            MainCourse.extends(Meal);
            
            MainCourse.prototype.getType = function () {
                return this._type;
            };
            MainCourse.prototype.setType = function (type) {
                this._type = type;
            };
            MainCourse.prototype.toString = function () {
                return Meal.prototype.toString.call(this) + "Type: " + this.getType() + "\n";
            };
            return MainCourse;
        }());
        
        var Salad = (function () {
            function Salad(name, price, calories, quantity, timeToPrepare, containsPasta) {
                Meal.call(this, name, price, calories, quantity, timeToPrepare, true);
                
                this.setContainsPasta(containsPasta);
            }
            
            Salad.extends(Meal);
            
            Salad.prototype.getContainsPasta = function () {
                return this._containsPasta;
            };
            Salad.prototype.setContainsPasta = function (containsPasta) {
                this._containsPasta = containsPasta;
            };
            Salad.prototype.toggleVegan = function () {
                throw new Error("A salad must should always be vegan.");
            };
            Salad.prototype.toString = function () {
                var containsPasta = "Contains pasta: " + (this.getContainsPasta() ? "yes" : "no");
                return Meal.prototype.toString.call(this) + containsPasta + "\n";
            };
            return Salad;
        }());
        
        var Command = (function () {
            
            function Command(commandLine) {
                this._params = new Array();
                this.translateCommand(commandLine);
            }
            
            Command.prototype.translateCommand = function (commandLine) {
                var self, paramsBeginning, name, parametersKeysAndValues;
                self = this;
                paramsBeginning = commandLine.indexOf("(");
                
                this._name = commandLine.substring(0, paramsBeginning);
                name = commandLine.substring(0, paramsBeginning);
                parametersKeysAndValues = commandLine
                    .substring(paramsBeginning + 1, commandLine.length - 1)
                    .split(";")
                    .filter(function (e) { return true; });
                
                parametersKeysAndValues.forEach(function (p) {
                    var split = p
                        .split("=")
                        .filter(function (e) { return true; });
                    self._params[split[0]] = split[1];
                });
            };
            return Command;
        }());
        
        function createRestaurant(name, location) {
            _restaurants[name] = new Restaurant(name, location);
            return "Restaurant " + name + " created\n";
        }
        
        function createDrink(name, price, calories, quantity, timeToPrepare, isCarbonated) {
            _recipes[name] = new Drink(name, price, calories, quantity, timeToPrepare, isCarbonated);
            return "Recipe " + name + " created\n";
        }
        
        function createSalad(name, price, calories, quantity, timeToPrepare, containsPasta) {
            _recipes[name] = new Salad(name, price, calories, quantity, timeToPrepare, containsPasta);
            return "Recipe " + name + " created\n";
        }
        
        function createMainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type) {
            _recipes[name] = new MainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type);
            return "Recipe " + name + " created\n";
        }
        
        function createDessert(name, price, calories, quantity, timeToPrepare, isVegan) {
            _recipes[name] = new Dessert(name, price, calories, quantity, timeToPrepare, isVegan);
            return "Recipe " + name + " created\n";
        }
        
        function toggleSugar(name) {
            var recipe;
            
            if (!_recipes.hasOwnProperty(name)) {
                throw new Error("The recipe " + name + " does not exist");
            }
            recipe = _recipes[name];
            
            if (recipe instanceof Dessert) {
                recipe.toggleSugar();
                return "Command ToggleSugar executed successfully. New value: " + recipe._withSugar.toString().toLowerCase() + "\n";
            } else {
                return "The command ToggleSugar is not applicable to recipe " + name + "\n";
            }
        }
        
        function toggleVegan(name) {
            var recipe;
            
            if (!_recipes.hasOwnProperty(name)) {
                throw new Error("The recipe " + name + " does not exist");
            }
            
            recipe = _recipes[name];
            if (recipe instanceof Meal) {
                recipe.toggleVegan();
                return "Command ToggleVegan executed successfully. New value: " +
                    recipe._isVegan.toString().toLowerCase() + "\n";
            } else {
                return "The command ToggleVegan is not applicable to recipe " + name + "\n";
            }
        }
        
        function printRestaurantMenu(name) {
            var restaurant;
            
            if (!_restaurants.hasOwnProperty(name)) {
                throw new Error("The restaurant " + name + " does not exist");
            }
            
            restaurant = _restaurants[name];
            return restaurant.printRestaurantMenu();
        }
        
        function addRecipeToRestaurant(restaurantName, recipeName) {
            var restaurant, recipe;
            
            if (!_restaurants.hasOwnProperty(restaurantName)) {
                throw new Error("The restaurant " + restaurantName + " does not exist");
            }
            if (!_recipes.hasOwnProperty(recipeName)) {
                throw new Error("The recipe " + recipeName + " does not exist");
            }
            
            restaurant = _restaurants[restaurantName];
            recipe = _recipes[recipeName];
            restaurant.addRecipe(recipe);
            return "Recipe " + recipeName + " successfully added to restaurant " + restaurantName + "\n";
        }
        
        function removeRecipeFromRestaurant(restaurantName, recipeName) {
            var restaurant, recipe;
            
            if (!_recipes.hasOwnProperty(recipeName)) {
                throw new Error("The recipe " + recipeName + " does not exist");
            }
            if (!_restaurants.hasOwnProperty(restaurantName)) {
                throw new Error("The restaurant " + restaurantName + " does not exist");
            }
            
            restaurant = _restaurants[restaurantName];
            recipe = _recipes[recipeName];
            restaurant.removeRecipe(recipe);
            return "Recipe " + recipeName + " successfully removed from restaurant " + restaurantName + "\n";
        }
        
        function executeCommand(commandLine) {
            var cmd, params, result;
            cmd = new Command(commandLine);
            params = cmd._params;
            
            switch (cmd._name) {
                case 'CreateRestaurant':
                    result = createRestaurant(params["name"], params["location"]);
                    break;
                case 'CreateDrink':
                    result = createDrink(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), parseInt(params["time"]), parseBoolean(params["carbonated"]));
                    break;
                case 'CreateSalad':
                    result = createSalad(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), parseInt(params["time"]), parseBoolean(params["pasta"]));
                    break;
                case "CreateMainCourse":
                    result = createMainCourse(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), parseInt(params["time"]), parseBoolean(params["vegan"]), params["type"]);
                    break;
                case "CreateDessert":
                    result = createDessert(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), parseInt(params["time"]), parseBoolean(params["vegan"]));
                    break;
                case "ToggleSugar":
                    result = toggleSugar(params["name"]);
                    break;
                case "ToggleVegan":
                    result = toggleVegan(params["name"]);
                    break;
                case "AddRecipeToRestaurant":
                    result = addRecipeToRestaurant(params["restaurant"], params["recipe"]);
                    break;
                case "RemoveRecipeFromRestaurant":
                    result = removeRecipeFromRestaurant(params["restaurant"], params["recipe"]);
                    break;
                case "PrintRestaurantMenu":
                    result = printRestaurantMenu(params["name"]);
                    break;
                default:
                    throw new Error('Invalid command name: ' + cmdName);
            }
            
            return result;
        }
        
        function parseBoolean(value) {
            switch (value) {
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    throw new Error("Invalid boolean value: " + value);
            }
        }
        
        return {
            initialize: initialize,
            executeCommand: executeCommand
        };
    }());
    
    
    // Process the input commands and return the results
    var results = '';
    RestaurantEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != "") {
            try {
                var cmdResult = RestaurantEngine.executeCommand(cmd);
                results += cmdResult;
            } catch (err) {
                results += err.message + "\n";
            }
        }
    });
    
    return results.trim();
}

// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

(function () {
    var arr = [];
    if (typeof (require) == 'function') {
        // We are in node.js --> read the console input and process it
        require('readline').createInterface({
            input: process.stdin,
            output: process.stdout
        }).on('line', function (line) {
                arr.push(line);
            }).on('close', function () {
                console.log(processRestaurantManagerCommands(arr));
            });
    }
})();

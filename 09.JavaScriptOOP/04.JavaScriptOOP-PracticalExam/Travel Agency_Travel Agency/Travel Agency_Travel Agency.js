function processTravelAgencyCommands(commands) {
    'use strict';
    
    var Types = {
        Boolean: typeof true,
        Number: typeof 0,
        String: typeof "",
        Object: typeof {},
        Undefined: typeof undefined,
        Function: typeof function () { }
    };
    
    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
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
    
    
    Object.prototype.validateNonEmptyString = function (value, variableName) {
        if (typeof (value) != Types.String || !value) {
            throw new Error(variableName + " should be non-empty string.");
        }
    }
    
    Object.prototype.validateEmptyString = function (value, variableName) {
        if (typeof (value) != Types.Undefined && !value) {
            throw new Error(variableName + " should be non-empty string.");
        }
    }
    
    Object.prototype.validateNonEmptyObject = function (value, className, variableName) {
        if (!(value instanceof className)) {
            throw new Error(variableName + " should be non-empty " + 
                className.prototype.constructor.name + ".");
        }
    }
    
    Object.prototype.validatePositiveInteger = function (value, variableName) {
        if (typeof (value) != 'number' || isNaN(value)) {
            throw new Error(variableName + " should be a number.");
        }
        if (value < 0) {
            throw new Error("The {0} must be positive".format(variableName));
        }
    };
    var dates = {
        convert: function (d) {
            // Converts the date in d to a date-object. The input can be:
            //   a date object: returned without modification
            //  an array      : Interpreted as [year,month,day]. NOTE: month is 0-11.
            //   a number     : Interpreted as number of milliseconds
            //                  since 1 Jan 1970 (a timestamp) 
            //   a string     : Any format supported by the javascript engine, like
            //                  "YYYY/MM/DD", "MM/DD/YYYY", "Jan 31 2009" etc.
            //  an object     : Interpreted as an object with year, month and date
            //                  attributes.  **NOTE** month is 0-11.
            return (
                d.constructor === Date ? d :
                    d.constructor === Array ? new Date(d[0], d[1], d[2]) :
                    d.constructor === Number ? new Date(d) :
                    d.constructor === String ? new Date(d) :
                    typeof d === "object" ? new Date(d.year, d.month, d.date) :
                    NaN
);
        },
        compare: function (a, b) {
            // Compare two dates (could be of any type supported by the convert
            // function above) and returns:
            //  -1 : if a < b
            //   0 : if a = b
            //   1 : if a > b
            // NaN : if a or b is an illegal date
            // NOTE: The code inside isFinite does an assignment (=).
            return (
                isFinite(a = this.convert(a).valueOf()) &&
                    isFinite(b = this.convert(b).valueOf()) ?
                    (a > b) - (a < b) :
                    NaN
);
        },
        inRange: function (d, start, end) {
            // Checks if date in d is between dates in start and end.
            // Returns a boolean or NaN:
            //    true  : if d is between start and end (inclusive)
            //    false : if d is before start or after end
            //    NaN   : if one or more of the dates is illegal.
            // NOTE: The code inside isFinite does an assignment (=).
            return (
                isFinite(d = this.convert(d).valueOf()) &&
                    isFinite(start = this.convert(start).valueOf()) &&
                    isFinite(end = this.convert(end).valueOf()) ?
                    start <= d && d <= end :
                    NaN
);
        }
    };
    
    var Models = (function () {
        var Destination = (function () {
            function Destination(location, landmark) {
                this.setLocation(location);
                this.setLandmark(landmark);
            }
            
            Destination.prototype.getLocation = function () {
                return this._location;
            }
            
            Destination.prototype.setLocation = function (location) {
                if (location === undefined || location === "") {
                    throw new Error("Location cannot be empty or undefined.");
                }
                this._location = location;
            }
            
            Destination.prototype.getLandmark = function () {
                return this._landmark;
            }
            
            Destination.prototype.setLandmark = function (landmark) {
                if (landmark === undefined || landmark == "") {
                    throw new Error("Landmark cannot be empty or undefined.");
                }
                this._landmark = landmark;
            }
            
            Destination.prototype.toString = function () {
                return this.constructor.name + ": " +
                    "location=" + this.getLocation() +
                    ",landmark=" + this.getLandmark();
            }
            
            return Destination;
        }());
        
        var Travel = (function () {
            function Travel(name, startDate, endDate, price) {
                if (this.constructor === Travel) {
                    throw new Error("Can't instantiate abstract class Travel.");
                }
                
                this.setName(name);
                this.setStartDate(startDate);
                this.setEndDate(endDate);
                this.setPrice(price);
            }
            Travel.prototype.getName = function () {
                return this._name;
            };
            Travel.prototype.setName = function (name) {
                this.validateNonEmptyString(name, "name");
                this._name = name;
            };
            Travel.prototype.getStartDate = function () {
                return this._startDate;
            };
            Travel.prototype.setStartDate = function (date) {
                this.validateNonEmptyObject(date, Date, "StartDate");
                this._startDate = date;
            };
            Travel.prototype.getEndDate = function () {
                return this._endDate;
            };
            Travel.prototype.setEndDate = function (date) {
                this.validateNonEmptyObject(date, Date, "EndDate");
                this._endDate = date;
            };
            Travel.prototype.getPrice = function () {
                return this._price;
            };
            Travel.prototype.setPrice = function (price) {
                this.validatePositiveInteger(price, "Price");
                this._price = price;
            };
            Travel.prototype.toString = function () {
                var result = ' * ' + this.constructor.name + ": name=" + this.getName();
                result += ",start-date=" + formatDate(this.getStartDate());
                result += ",end-date=" + formatDate(this.getEndDate());
                result += ",price=" + this.getPrice().toFixed(2);
                return result;
            };
            
            return Travel;
        }());
        
        var Excursion = (function () {
            function Excursion(name, startDate, endDate, price, transport) {
                Travel.call(this, name, startDate, endDate, price);
                
                this.setTransport(transport);
                this.setDestinations();
            }
            Excursion.extends(Travel);
            
            Excursion.prototype.getTransport = function () {
                return this._transport;
            };
            Excursion.prototype.setTransport = function (transport) {
                this.validateNonEmptyString(transport, "Transport");
                this._transport = transport;
            };
            Excursion.prototype.setDestinations = function () {
                this._destinations = [];
            }
            Excursion.prototype.getDestinations = function () {
                return this._destinations;
            }
            Excursion.prototype.addDestination = function (destination) {
                this._destinations.push(destination);
            }
            Excursion.prototype.removeDestination = function (destination) {
                if (this._destinations.indexOf(destination) == -1) {
                    throw new Error("There is no such current destination");
                }
                
                this._destinations.remove(destination);
            }
            Excursion.prototype.toString = function () {
                var result = '' + Travel.prototype.toString.call(this);
                result += ",transport=" + this.getTransport();
                result += "\n ** Destinations: ";
                var resulArr = [];
                if (this.getDestinations().length > 0) {
                    this._destinations.forEach(function (destination) {
                        resulArr.push(destination);
                    });
                    
                    result += resulArr.join(";");
                } else {
                    result += "-";
                }
                
                return result;
            };
            
            return Excursion;
        }());
        
        var Cruise = (function () {
            
            var CRUISE_TRANSPORT = "cruise liner";
            
            function Cruise(name, startDate, endDate, price, startDock) {
                Excursion.call(this, name, startDate, endDate, price, CRUISE_TRANSPORT);
                
                this.setStartDock(startDock);
            }
            Cruise.extends(Excursion);
            
            Cruise.prototype.getStartDock = function () {
                return this._startDock;
            };
            Cruise.prototype.setStartDock = function (startDock) {
                this.validateEmptyString(startDock, "StartDock");
                this._startDock = startDock;
            };
            
            return Cruise;
        }());
        
        var Vacation = (function () {
            function Vacation(name, startDate, endDate, price, location, accommodation) {
                Travel.call(this, name, startDate, endDate, price);
                
                this.setLocation(location);
                this.setAccommodation(accommodation);
            }
            Vacation.extends(Travel);
            
            Vacation.prototype.getLocation = function () {
                return this._location;
            };
            Vacation.prototype.setLocation = function (location) {
                this.validateNonEmptyString(location, "Location");
                this._location = location;
            };
            Vacation.prototype.getAccommodation = function () {
                return this._accommodation;
            };
            Vacation.prototype.setAccommodation = function (accommodation) {
                this.validateEmptyString(accommodation, "accommodation");
                this._accommodation = accommodation;
            };
            Vacation.prototype.toString = function () {
                var result = Travel.prototype.toString.call(this);
                result += ",location=" + this.getLocation();
                if (this.getAccommodation() !== undefined) {
                    result += ",accommodation=" + this.getAccommodation();
                }
                
                return result;
            };
            
            return Vacation;
        }());
        
        return {
            Destination: Destination,
            Vacation : Vacation,
            Cruise: Cruise,
            Excursion: Excursion
        }
    }());
    
    var TravellingManager = (function () {
        var _travels;
        var _destinations;
        
        function init() {
            _travels = [];
            _destinations = [];
        }
        
        var CommandProcessor = (function () {
            
            function processInsertCommand(command) {
                var object;
                
                switch (command["type"]) {
                    case "excursion":
                        object = new Models.Excursion(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["transport"]);
                        _travels.push(object);
                        break;
                    case "vacation":
                        object = new Models.Vacation(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["location"], command["accommodation"]);
                        _travels.push(object);
                        break;
                    case "cruise":
                        object = new Models.Cruise(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["start-dock"]);
                        _travels.push(object);
                        break;
                    case "destination":
                        object = new Models.Destination(command["location"], command["landmark"]);
                        _destinations.push(object);
                        break;
                    default:
                        throw new Error("Invalid type.");
                }
                
                return object.constructor.name + " created.";
            }
            
            function processDeleteCommand(command) {
                var object,
                    index,
                    destinations;
                
                switch (command["type"]) {
                    case "destination":
                        object = getDestinationByLocationAndLandmark(command["location"], command["landmark"]);
                        _travels.forEach(function (t) {
                            if (t instanceof Models.Excursion && t.getDestinations().indexOf(object) !== -1) {
                                t.removeDestination(object);
                            }
                        });
                        index = _destinations.indexOf(object);
                        _destinations.splice(index, 1);
                        break;
                    case "excursion":
                    case "vacation":
                    case "cruise":
                        object = getTravelByName(command["name"]);
                        index = _travels.indexOf(object);
                        _travels.splice(index, 1);
                        break;
                    default:
                        throw new Error("Unknown type.");
                }
                
                return object.constructor.name + " deleted.";
            }
            
            function processListCommand(command) {
                return formatTravelsQuery(_travels);
            }
            
            function processAddDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);
                
                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.addDestination(destination);
                
                return "Added destination to " + travel.getName() + ".";
            }
            
            function processRemoveDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);
                
                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.removeDestination(destination);
                
                return "Removed destination from " + travel.getName() + ".";
            }
            
            function getTravelByName(name) {
                var i;
                
                for (i = 0; i < _travels.length; i++) {
                    if (_travels[i].getName() === name) {
                        return _travels[i];
                    }
                }
                throw new Error("No travel with such name exists.");
            }
            
            function getDestinationByLocationAndLandmark(location, landmark) {
                var i;
                
                for (i = 0; i < _destinations.length; i++) {
                    if (_destinations[i].getLocation() === location 
                        && _destinations[i].getLandmark() === landmark) {
                        return _destinations[i];
                    }
                }
                throw new Error("No destination with such location and landmark exists.");
            }
            
            function formatTravelsQuery(travelsQuery) {
                var queryString = "";
                
                if (travelsQuery.length > 0) {
                    queryString += travelsQuery.join("\n");
                } else {
                    queryString = "No results.";
                }
                
                return queryString;
            }
            
            function processFilterTravelsCommand(command) {
                var type = command["type"];
                var minPrice = (Number)(command["price-min"]);
                var maxPrice = (Number)(command["price-max"]);
                
                var sorted = _travels
                    .filter(function (travel) {
                        return travel.constructor.name.toString().toLowerCase() == type ||
                            type == "all";
                    });
                sorted = sorted.filter(function (travel) {
                    return travel.getPrice() <= maxPrice && travel.getPrice() >= minPrice;
                });
                sorted = sorted.sort(function (a, b) {
                    // sort work with 0, 1, -1
                    var result = dates.compare(a.getStartDate(), b.getStartDate());
                    if (result === 0) {
                        result = a.getName().localeCompare(b.getName());
                    }
                    
                    return result;
                });
                //sorted = sorted.sort(function (a, b) {
                //    return a.getName().localeCompare(b.getName());
                //});  dates.compare(
                
                return formatTravelsQuery(sorted);
            }
            
            return {
                processInsertCommand: processInsertCommand,
                processDeleteCommand: processDeleteCommand,
                processListCommand: processListCommand,
                processAddDestinationCommand: processAddDestinationCommand,
                processRemoveDestinationCommand: processRemoveDestinationCommand,
                processFilterTravelsCommand: processFilterTravelsCommand
            }
        }());
        
        var Command = (function () {
            function Command(cmdLine) {
                this._cmdArgs = processCommand(cmdLine);
            }
            
            function processCommand(cmdLine) {
                var parameters = [],
                    matches = [],
                    pattern = /(.+?)=(.+?)[;)]/g,
                    key,
                    value,
                    split;
                
                split = cmdLine.split("(");
                parameters["command"] = split[0];
                while ((matches = pattern.exec(split[1])) !== null) {
                    key = matches[1];
                    value = matches[2];
                    parameters[key] = value;
                }
                
                return parameters;
            }
            
            return Command;
        }());
        
        function executeCommands(cmds) {
            var commandArgs = new Command(cmds)._cmdArgs,
                action = commandArgs["command"],
                output;
            
            switch (action) {
                case "insert":
                    output = CommandProcessor.processInsertCommand(commandArgs);
                    break;
                case "delete":
                    output = CommandProcessor.processDeleteCommand(commandArgs);
                    break;
                case "add-destination":
                    output = CommandProcessor.processAddDestinationCommand(commandArgs);
                    break;
                case "remove-destination":
                    output = CommandProcessor.processRemoveDestinationCommand(commandArgs);
                    break;
                case "list":
                    output = CommandProcessor.processListCommand(commandArgs);
                    break;
                case "filter":
                    output = CommandProcessor.processFilterTravelsCommand(commandArgs);
                    break;
                default:
                    throw new Error("Unsupported command.");
            }
            
            return output;
        }
        
        return {
            init: init,
            executeCommands: executeCommands
        }
    }());
    
    var parseDate = function (dateStr) {
        if (!dateStr) {
            return undefined;
        }
        var date = new Date(Date.parse(dateStr.replace(/-/g, ' ')));
        var dateFormatted = formatDate(date);
        if (dateStr != dateFormatted) {
            throw new Error("Invalid date: " + dateStr);
        }
        return date;
    }
    
    var formatDate = function (date) {
        var day = date.getDate();
        var monthName = date.toString().split(' ')[1];
        var year = date.getFullYear();
        return day + '-' + monthName + '-' + year;
    }
    
    var output = "";
    TravellingManager.init();
    
    commands.forEach(function (cmd) {
        var result;
        if (cmd != "") {
            try {
                result = TravellingManager.executeCommands(cmd) + "\n";
            } catch (e) {
                result = "Invalid command." + "\n";
            }
            output += result;
        }
    });
    
    return output;
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
                console.log(processTravelAgencyCommands(arr));
            });
    }
})();
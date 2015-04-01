function processEstatesAgencyCommands(commands) {
    
    'use strict';

    Object.prototype.extends = function(parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    }

    function isInteger(x) {
        return ((x ^ 0) === x);
    }


    var Estate = (function() {

        var MIN_AREA = 1;
        var MAX_AREA = 10000;

        function Estate(name, area, location, isFurnitured) {
            if (this.constructor === Estate) {
                throw new Error('Cannot instantiate abstract class Estate.');
            }
            this.setName(name);
            this.setArea(area);
            this.setLocation(location);
            this.setIsFurnitured(isFurnitured);
        }

        Estate.prototype._type = 'Estate';

        Estate.prototype.getType = function() {
            return this._type;
        }

        Estate.prototype.getName = function() {
            return this._name;
        }

        Estate.prototype.setName = function(name) {
            if (typeof (name) != 'string') {
                throw new Error('Name should be a string.');
            }
            if (!name) {
                throw new Error('Name cannot be empty.');
            }
            this._name = name;
        }

        Estate.prototype.getArea = function() {
            return this._area;
        }

        Estate.prototype.setArea = function(area) {
            if (! isInteger(area)) {
                throw new Error('Area should be an integer number.');
            }
            if (! (area >= MIN_AREA && area <= MAX_AREA)) {
                throw new Error('Area should be in range [' +
                    MIN_AREA + '...' + MAX_AREA + '].');
            }
            this._area = area;
        }

        Estate.prototype.getLocation = function() {
            return this._location;
        }

        Estate.prototype.setLocation = function(location) {
            if (typeof (location) != 'string') {
                throw new Error('Location should be a string.');
            }
            if (!location) {
                throw new Error('Location cannot be empty.');
            }
            this._location = location;
        }

        Estate.prototype.getIsFurnitured = function() {
            return this._isFurnitured;
        }

        Estate.prototype.setIsFurnitured = function(isFurnitured) {
            if (typeof (isFurnitured) != 'boolean') {
                throw new Error('IsFurnitured should be a boolean value.');
            }
            this._isFurnitured = isFurnitured;
        }

        Estate.prototype.toString = function() {
            var furnitured = this.getIsFurnitured() ? 'Yes' : 'No';
            return this.getType() + ': Name = ' + this.getName() +
                ', Area = ' + this.getArea() + ', Location = ' +
                this.getLocation() + ', Furnitured = ' + furnitured;
        }

        return Estate;
    }());


    var BuildingEstate = (function() {

        var MIN_ROOMS = 0;
        var MAX_ROOMS = 100;

        function BuildingEstate(name, area, location, isFurnitured, rooms, hasElevator) {
            if (this.constructor === BuildingEstate) {
                throw new Error('Cannot instantiate abstract class BuildingEstate.');
            }
            Estate.apply(this, arguments);
            this.setRooms(rooms);
            this.setHasElevator(hasElevator);
        }

        BuildingEstate.extends(Estate);

        BuildingEstate.prototype._type = 'BuildingEstate';

        BuildingEstate.prototype.getRooms = function() {
            return this._rooms;
        }

        BuildingEstate.prototype.setRooms = function(rooms) {
            if (! isInteger(rooms)) {
                throw new Error('Rooms should be an integer number.');
            }
            if (! (rooms >= MIN_ROOMS && rooms <= MAX_ROOMS)) {
                throw new Error('Rooms should be in range [' +
                    MIN_ROOMS + '...' + MAX_ROOMS + '].');
            }
            this._rooms = rooms;
        }

        BuildingEstate.prototype.getHasElevator = function() {
            return this._hasElevator;
        }

        BuildingEstate.prototype.setHasElevator = function(hasElevator) {
            if (typeof (hasElevator) != 'boolean') {
                throw new Error('HasElevator should be a boolean value.');
            }
            this._hasElevator = hasElevator;
        }

        BuildingEstate.prototype.toString = function() {
            var elevator = this.getHasElevator() ? 'Yes' : 'No';
            return Estate.prototype.toString.call(this) +
                ', Rooms: ' + this.getRooms() + ', Elevator: ' + elevator;
        }

        return BuildingEstate;
    }());


    var Apartment = (function() {
        function Apartment(name, area, location, isFurnitured, rooms, hasElevator) {
            BuildingEstate.apply(this, arguments);
        }

        Apartment.extends(BuildingEstate);

        Apartment.prototype._type = 'Apartment';

        return Apartment;
    }());


    var Office = (function() {
        function Office(name, area, location, isFurnitured, rooms, hasElevator) {
            BuildingEstate.apply(this, arguments);
        }

        Office.extends(BuildingEstate);

        Office.prototype._type = 'Office';

        return Office;
    }());


    var House = (function() {

        var MIN_FLOORS = 1;
        var MAX_FLOORS = 10;

        function House(name, area, location, isFurnitured, floors) {
            Estate.apply(this, arguments);
            this.setFloors(floors);
        }

        House.extends(Estate);

        House.prototype._type = 'House';

        House.prototype.getFloors = function() {
            return this._floors;
        }

        House.prototype.setFloors = function(floors) {
            if (! isInteger(floors)) {
                throw new Error('Rooms should be an integer number.');
            }
            if (! (floors >= MIN_FLOORS && floors <= MAX_FLOORS)) {
                throw new Error('Floors should be in range [' +
                    MIN_FLOORS + '...' + MAX_FLOORS + '].');
            }
            this._floors = floors;
        }

        House.prototype.toString = function() {
            return Estate.prototype.toString.call(this) +
                ', Floors: ' + this.getFloors();
        }

        return House;
    }());


    var Garage = (function() {

        var MIN_WIDTH_HEIGHT = 1;
        var MAX_WIDTH_HEIGHT = 500;

        function Garage(name, area, location, isFurnitured, width, height) {
            Estate.apply(this, arguments);
            this.setWidth(width);
            this.setHeight(height);
        }

        Garage.extends(Estate);

        Garage.prototype._type = 'Garage';

        Garage.prototype.getWidth = function() {
            return this._width;
        }

        Garage.prototype.setWidth = function(width) {
            if (! isInteger(width)) {
                throw new Error('Width should be an integer number.');
            }
            if (! (width >= MIN_WIDTH_HEIGHT && width <= MAX_WIDTH_HEIGHT)) {
                throw new Error('Width should be in range [' +
                    MIN_WIDTH_HEIGHT + '...' + MAX_WIDTH_HEIGHT + '].');
            }
            this._width = width;
        }

        Garage.prototype.getHeight = function() {
            return this._height;
        }

        Garage.prototype.setHeight = function(height) {
            if (! isInteger(height)) {
                throw new Error('Height should be an integer number.');
            }
            if (! (height >= MIN_WIDTH_HEIGHT && height <= MAX_WIDTH_HEIGHT)) {
                throw new Error('Height should be in range [' +
                    MIN_WIDTH_HEIGHT + '...' + MAX_WIDTH_HEIGHT + '].');
            }
            this._height = height;
        }

        Garage.prototype.toString = function() {
            return Estate.prototype.toString.call(this) +
                ', Width: ' + this.getWidth() + ", Height: " + this.getHeight();
        }

        return Garage;
    }());


    var Offer = (function() {

        var MIN_PRICE = 1;

        function Offer(estate, price) {
            if (this.constructor === Offer) {
                throw new Error('Cannot instantiate abstract class Offer.');
            }
            this.setEstate(estate);
            this.setPrice(price);
        }

        Offer.prototype._type = 'Offer';

        Offer.prototype.getType = function() {
            return this._type;
        }

        Offer.prototype.getEstate = function() {
            return this._estate;
        }

        Offer.prototype.setEstate = function(estate) {
            if (!(estate instanceof Estate)) {
                throw new Error('Estate should be instance of Estate class or its subclass.');
            }
            this._estate = estate;
        }

        Offer.prototype.getPrice = function() {
            return this._price;
        }

        Offer.prototype.setPrice = function(price) {
            if (! isInteger(price)) {
                throw new Error('Price should be an integer number.');
            }
            if (! (price > MIN_PRICE)) {
                throw new Error('Price should be greater than ' + MIN_PRICE + '.');
            }
            this._price = price;
        }

        Offer.prototype.toString = function() {
            return this.getType() + ': Estate = ' + this.getEstate().getName() +
                ', Location = ' + this.getEstate().getLocation() +
                ', Price = ' + this.getPrice();
        }

        return Offer;
    }());


    var RentOffer = (function() {
        function RentOffer(estate, price) {
            Offer.apply(this, arguments);
        }

        RentOffer.extends(Offer);

        RentOffer.prototype._type = 'Rent';

        return RentOffer;
    }());


    var SaleOffer = (function() {
        function SaleOffer(estate, price) {
            Offer.apply(this, arguments);
        }

        SaleOffer.extends(Offer);

        SaleOffer.prototype._type = 'Sale';

        return SaleOffer;
    }());


    var EstatesEngine = (function() {
        var _estates;
        var _uniqueEstateNames;
        var _offers;

        function initialize() {
            _estates = [];
            _uniqueEstateNames = {};
            _offers = [];
        }

        function executeCommand(command) {
            var cmdParts = command.split(' ');
            var cmdName = cmdParts[0];
            var cmdArgs = cmdParts.splice(1);
            switch (cmdName) {
            case 'create':
                return executeCreateCommand(cmdArgs);
            case 'status':
                return executeStatusCommand();
            case 'find-sales-by-location':
                return executeFindSalesByLocationCommand(cmdArgs[0]);
            case 'find-rents-by-location':
                return executeFindRentsByLocationCommand(cmdArgs[0]);
            case 'find-rents-by-price':
                return executeFindRentsByPriceRangeCommand(
                    Number(cmdArgs[0]), Number(cmdArgs[1]));
            default:
                throw new Error('Unknown command: ' + cmdName);
            }
        }

        function executeCreateCommand(cmdArgs) {
            var objType = cmdArgs[0];
            switch (objType) {
            case 'Apartment':
                var apartment = new Apartment(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                    parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
                addEstate(apartment);
                break;
            case 'Office':
                var office = new Office(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                    parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
                addEstate(office);
                break;
            case 'House':
                var house = new House(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                    parseBoolean(cmdArgs[4]), Number(cmdArgs[5]));
                addEstate(house);
                break;
            case 'Garage':
                var garage = new Garage(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                    parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), Number(cmdArgs[6]));
                addEstate(garage);
                break;
            case 'RentOffer':
                var estate = findEstateByName(cmdArgs[1]);
                var rentOffer = new RentOffer(estate, Number(cmdArgs[2]));
                addOffer(rentOffer);
                break;
            case 'SaleOffer':
                estate = findEstateByName(cmdArgs[1]);
                var saleOffer = new SaleOffer(estate, Number(cmdArgs[2]));
                addOffer(saleOffer);
                break;
            default:
                throw new Error('Unknown object to create: ' + objType);
            }
            return objType + ' created.';
        }

        function parseBoolean(value) {
            switch (value) {
            case "true":
                return true;
            case "false":
                return false;
            default:
                throw new Error("Invalid boolean value: " + value);
            }
        }

        function findEstateByName(estateName) {
            for (var i = 0; i < _estates.length; i++) {
                if (_estates[i].getName() == estateName) {
                    return _estates[i];
                }
            }
            return undefined;
        }

        function addEstate(estate) {
            if (_uniqueEstateNames[estate.getName()]) {
                throw new Error('Duplicated estate name: ' + estate.getName());
            }
            _uniqueEstateNames[estate.getName()] = true;
            _estates.push(estate);
        }

        function addOffer(offer) {
            _offers.push(offer);
        }

        function executeStatusCommand() {
            var result = '', i;
            if (_estates.length > 0) {
                result += 'Estates:\n';
                for (i = 0; i < _estates.length; i++) {
                    result += "  " + _estates[i].toString() + '\n';
                }
            } else {
                result += 'No estates\n';
            }

            if (_offers.length > 0) {
                result += 'Offers:\n';
                for (i = 0; i < _offers.length; i++) {
                    result += "  " + _offers[i].toString() + '\n';
                }
            } else {
                result += 'No offers\n';
            }

            return result.trim();
        }

        function executeFindSalesByLocationCommand(location) {
            return findOffersByLocation(location, SaleOffer);
        }

        function executeFindRentsByLocationCommand(location) {
            return findOffersByLocation(location, RentOffer);
        }

        function executeFindRentsByPriceRangeCommand(minPrice, maxPrice) {
            if (! isInteger(minPrice) || ! isInteger(maxPrice)) {
                throw new Error("Invalid price range.");
            }
            // Select all rent offers within the price range
            var selectedOffers = _offers.filter(function(offer) {
                return offer.getPrice() >= minPrice &&
                    offer.getPrice() <= maxPrice &&
                    offer instanceof RentOffer;
            });

            // Sort selected offers by name
            selectedOffers.sort(function(a, b) {
                return a.getEstate().getName().localeCompare(b.getEstate().getName());
            });

            // Sort the sorted by name offers by price
            selectedOffers.sort(function(a, b) {
                return a.getPrice() - b.getPrice();
            });

            return formatQueryResults(selectedOffers);
        }

        function findOffersByLocation(location, offerClass) {
            if (!location) {
                throw new Error("Location cannot be empty.");
            }
            var selectedOffers = _offers.filter(function(offer) {
                return offer.getEstate().getLocation() === location &&
                    offer instanceof offerClass;
            });
            selectedOffers.sort(function(a, b) {
                return a.getEstate().getName().localeCompare(b.getEstate().getName());
            });
            return formatQueryResults(selectedOffers);
        }

        function formatQueryResults(offers) {
            var result = '';
            if (offers.length == 0) {
                result += 'No Results\n';
            } else {
                result += 'Query Results:\n';
                for (var i = 0; i < offers.length; i++) {
                    var offer = offers[i];
                    result += '  [Estate: ' + offer.getEstate().getName() +
                        ', Location: ' + offer.getEstate().getLocation() +
                        ', Price: ' + offer.getPrice() + ']\n';
                }
            }
            return result.trim();
        }

        return {
            initialize: initialize,
            executeCommand: executeCommand
        };
    }());

    
    // Process the input commands and return the results
    var results = '';
    EstatesEngine.initialize();
    commands.forEach(function(cmd) {
        if (cmd != '') {
            try {
                var cmdResult = EstatesEngine.executeCommand(cmd);
                results += cmdResult + '\n';
            } catch (err) {
                //console.log(err);
                results += 'Invalid command.\n';
            }
        }
    });
    return results.trim();

}


// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

(function() {
    var arr = [];
    if (typeof (require) == 'function') {
        // We are in node.js --> read the console input and process it
        require('readline').createInterface({
            input: process.stdin,
            output: process.stdout
        }).on('line', function(line) {
            arr.push(line);
        }).on('close', function() {
            console.log(processEstatesAgencyCommands(arr));
        });
    }
})();

function processTrainingCenterCommands(commands) {
    
    'use strict';
    
    var trainingcenter = (function () {
        
        var extendClass = function (child, parent) {
            child.prototype = Object.create(parent.prototype);
            child.prototype.constructor = child;
        }
        

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
        
        
        var Validators = {
            validateNonEmptyString: function (value, variableName) {
                if (typeof (value) != 'string' || !value) {
                    throw new Error(variableName + " should be a non-empty string. Invalid value: " + value);
                }
            },
            
            validateIntegerRange: function (value, variableName, minValue, maxValue) {
                if (typeof (value) != 'number') {
                    throw new Error(variableName + " should be a number. Invalid value: " + value);
                }
                if (value !== parseInt(value, 10)) {
                    throw new Error(variableName + " should be an integer. Invalid value: " + value);
                }
                if (value < minValue || value > maxValue) {
                    throw new Error(variableName + " should be an integer in the range [" +
                        minValue + "..." + maxValue + "]. Invalid value: " + value);
                }
            },
            
            validateNonEmptyObject: function (value, variableName, className) {
                if (!(value instanceof className)) {
                    throw new Error(variableName + " should be a non-empty " +
                        className.prototype.constructor.name + ". Invalid value: " + value);
                }
            },
            
            validateEmail: function (value, variableName) {
                if (typeof (value) != 'string') {
                    throw new Error(variableName + " should be a string. Invalid value: " + value);
                }
                if (value.indexOf('@') == -1) {
                    throw new Error(variableName + " should hold an email address. Invalid value: " + value);
                }
            },

            validateDateRange: function (date, variableName, minDate, maxDate) {
                if (typeof (date) != 'object' || ! (date instanceof Date)) {
                    throw new Error(variableName + " should be a Date object. Invalid value: " + date);
                }
                if (isNaN(date.getTime())) {
                    throw new Error(variableName + " should be a valid date. Invalid value: " + date);
                }
                if (date.getTime() < minDate.getTime() || date.getTime() > maxDate.getTime()) {
                    throw new Error(variableName + " should be a date in range[" +
                        formatDate(minDate) + "..." + formatDate(maxDate) + "]. Invalid value: " + date);
                }
            },

            validateNumberOfArguments: function (args, expectedArgsCount, className) {
                if (args.length != expectedArgsCount) {
                    throw new Error(className + "'s constructor expects " + expectedArgsCount +
                        "arguments but is invoked with " + expectedArgsCount);
                }
            },

            isNullOrUndefined: function(value) {
                return (typeof (value) == 'undefined') || (value == null);
            }
        }
        
        
        var Trainer = (function () {
            
            function Trainer(username, firstName, lastName, email) {
                Validators.validateNumberOfArguments(arguments, 4, "Trainer");
                this.setUsername(username);
                this.setFirstName(firstName);
                this.setLastName(lastName);
                this.setEmail(email);
            }
            
            Trainer.prototype.getUsername = function () {
                return this._username;
            }
            
            Trainer.prototype.setUsername = function (username) {
                Validators.validateNonEmptyString(username, "username");
                this._username = username;
            }
            
            Trainer.prototype.getFirstName = function () {
                return this._firstName;
            }
            
            Trainer.prototype.setFirstName = function (firstName) {
                if (! Validators.isNullOrUndefined(firstName)) {
                    Validators.validateNonEmptyString(firstName, "firstName");
                    this._firstName = firstName;
                } else {
                    delete this._firstName;
                }
            }
            
            Trainer.prototype.getLastName = function () {
                return this._lastName;
            }
            
            Trainer.prototype.setLastName = function (lastName) {
                Validators.validateNonEmptyString(lastName, "lastName");
                this._lastName = lastName;
            }
            
            Trainer.prototype.getEmail = function () {
                return this._email;
            }
            
            Trainer.prototype.setEmail = function (email) {
                if (! Validators.isNullOrUndefined(email)) {
                    Validators.validateEmail(email, "email");
                    this._email = email;
                } else {
                    delete this._email;
                }
            }
            
            Trainer.prototype.toString = function () {
                var emailText = this.getEmail() ? ";email=" + this.getEmail() : '';
                var firstNameText = this.getFirstName() ? ";first-name=" + this.getFirstName() : '';
                return "Trainer[username=" + this.getUsername() +
                    firstNameText +
                    ";last-name=" + this.getLastName() +
                    emailText + "]";
            }
            
            return Trainer;
        }());
        
        
        var Training = (function () {
            
            var MIN_DURATION = 1;
            var MAX_DURATION = 99;

            var MIN_DATE = parseDate("1-Jan-2000");
            var MAX_DATE = parseDate("31-Dec-2020");
            
            function Training(name, description, trainer, startDate, duration) {
                if (this.constructor === Training) {
                    throw new Error('Cannot instantiate abstract class Training.');
                }
                this.setName(name);
                this.setDescription(description);
                this.setTrainer(trainer);
                this.setStartDate(startDate);
                this.setDuration(duration);
            }
            
            Training.prototype.getName = function () {
                return this._name;
            }
            
            Training.prototype.setName = function (name) {
                Validators.validateNonEmptyString(name, "name");
                this._name = name;
            }
            
            Training.prototype.getDescription = function () {
                return this._description;
            }
            
            Training.prototype.setDescription = function (description) {
                if (! Validators.isNullOrUndefined(description)) {
                    Validators.validateNonEmptyString(description, "description");
                    this._description = description;
                } else {
                    delete this._description;
                }
            }
            
            Training.prototype.getTrainer = function () {
                return this._trainer;
            }
            
            Training.prototype.setTrainer = function (trainer) {
                if (! Validators.isNullOrUndefined(trainer)) {
                    Validators.validateNonEmptyObject(trainer, "trainer", Trainer);
                    this._trainer = trainer;
                } else {
                    delete this._trainer;
                }
            }
            
            Training.prototype.getStartDate = function () {
                return this._startDate;
            }
            
            Training.prototype.setStartDate = function (startDate) {
                Validators.validateDateRange(startDate, "startDate", MIN_DATE, MAX_DATE);
                this._startDate = startDate;
            }
            
            Training.prototype.getDuration = function () {
                return this._duration;
            }
            
            Training.prototype.setDuration = function (duration) {
                if (! Validators.isNullOrUndefined(duration)) {
                    Validators.validateIntegerRange(duration, "duration", MIN_DURATION, MAX_DURATION);
                    this._duration = duration;
                } else {
                    delete this._duration;
                }
            }
            
            Training.prototype.toStringNameDescriptionTrainer = function () {
                var descriptionText = this.getDescription() ? ";description=" + this.getDescription() : "";
                var trainerText = this.getTrainer() ? ";trainer=" + this.getTrainer().toString() : "";
                return this.constructor.name +
                    "[name=" + this.getName() +
                    descriptionText +
                    trainerText;
            }
            
            Training.prototype.toStringNameDescriptionTrainerStartDateDuration = function () {
                var durationText = this.getDuration() ? ";duration=" + this.getDuration() : "";
                return this.toStringNameDescriptionTrainer() +
                    ";start-date=" + formatDate(this.getStartDate()) +
                    durationText;
            }
            
            Training.prototype.toString = function () {
                return this.toStringNameDescriptionTrainerStartDateDuration() + "]";
            }
            
            return Training;
        }());
        
        
        var Course = (function () {
            
            function Course(name, description, trainer, startDate, duration) {
                Validators.validateNumberOfArguments(arguments, 5, "Course");
                Training.call(this, name, description, trainer, startDate, duration);
            }
            
            extendClass(Course, Training);
            
            return Course;
        }());
        
        
        var Seminar = (function () {
            
            function Seminar(name, description, trainer, date) {
                Validators.validateNumberOfArguments(arguments, 4, "Seminar");
                Training.call(this, name, description, trainer, date);
            }
            
            extendClass(Seminar, Training);
            
            Seminar.prototype.toString = function () {
                return this.toStringNameDescriptionTrainer() +
                    ";date=" + formatDate(this.getStartDate()) + "]";
            }
            
            return Seminar;
        }());
        
        
        var RemoteCourse = (function () {
            
            function RemoteCourse(name, description, trainer, startDate, duration, location) {
                Validators.validateNumberOfArguments(arguments, 6, "RemoteCourse");
                Course.call(this, name, description, trainer, startDate, duration);
                this.setLocation(location);
            }
            
            extendClass(RemoteCourse, Course);
            
            RemoteCourse.prototype.getLocation = function () {
                return this._location;
            }
            
            RemoteCourse.prototype.setLocation = function (location) {
                Validators.validateNonEmptyString(location, "location");
                this._location = location;
            }
            
            RemoteCourse.prototype.toString = function () {
                return this.toStringNameDescriptionTrainerStartDateDuration() +
                    ";location=" + this.getLocation() + "]";
            }
            
            return RemoteCourse;
        }());
        
        
        var TrainingCenterEngine = (function () {
            
            var _trainers;
            var _uniqueTrainerUsernames;
            var _trainings;
            
            function initialize() {
                _trainers = [];
                _uniqueTrainerUsernames = {};
                _trainings = [];
            }
            
            function executeCommand(command) {
                var cmdParts = command.split(' ');
                var cmdName = cmdParts[0];
                var cmdArgs = cmdParts.splice(1);
                switch (cmdName) {
                    case 'create':
                        return executeCreateCommand(cmdArgs);
                    case 'list':
                        return executeListCommand();
                    case 'delete':
                        return executeDeleteCommand(cmdArgs);
                    default:
                        throw new Error('Unknown command: ' + cmdName);
                }
            }
            
            function executeCreateCommand(cmdArgs) {
                var objectType = cmdArgs[0];
                var createArgs = cmdArgs.splice(1).join(' ');
                var objectData = JSON.parse(createArgs);
                var trainer;
                switch (objectType) {
                    case 'Trainer':
                        trainer = new trainingcenter.Trainer(objectData.username, objectData.firstName, 
                            objectData.lastName, objectData.email);
                        addTrainer(trainer);
                        break;
                    case 'Course':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var course = new trainingcenter.Course(objectData.name, objectData.description, trainer,
                            parseDate(objectData.startDate), objectData.duration);
                        addTraining(course);
                        break;
                    case 'Seminar':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var seminar = new trainingcenter.Seminar(objectData.name, objectData.description, 
                            trainer, parseDate(objectData.date));
                        addTraining(seminar);
                        break;
                    case 'RemoteCourse':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var remoteCourse = new trainingcenter.RemoteCourse(objectData.name, objectData.description,
                            trainer, parseDate(objectData.startDate), objectData.duration, objectData.location);
                        addTraining(remoteCourse);
                        break;
                    default:
                        throw new Error('Unknown object to create: ' + objectType);
                }
                return objectType + ' created.';
            }
            
            function findTrainerByUsername(username) {
                if (! username) {
                    return undefined;
                }
                for (var i = 0; i < _trainers.length; i++) {
                    if (_trainers[i].getUsername() == username) {
                        return _trainers[i];
                    }
                }
                throw new Error("Trainer not found: " + username);
            }
            
            function addTrainer(trainer) {
                if (_uniqueTrainerUsernames[trainer.getUsername()]) {
                    throw new Error('Duplicated trainer: ' + trainer.getUsername());
                }
                _uniqueTrainerUsernames[trainer.getUsername()] = true;
                _trainers.push(trainer);
            }
            
            function addTraining(training) {
                _trainings.push(training);
            }
            
            function executeListCommand() {
                var result = '', i;
                if (_trainers.length > 0) {
                    result += 'Trainers:\n' + ' * ' + _trainers.join('\n * ') + '\n';
                } else {
                    result += 'No trainers\n';
                }
                
                if (_trainings.length > 0) {
                    result += 'Trainings:\n' + ' * ' + _trainings.join('\n * ') + '\n';
                } else {
                    result += 'No trainings\n';
                }
                
                return result.trim();
            }
            
            function executeDeleteCommand(cmdArgs) {
                var objectType = cmdArgs[0];
                var deleteArgs = cmdArgs.splice(1).join(' ');
                switch (objectType) {
                    case 'Trainer':
                        deleteTrainer(deleteArgs);
                        break;
                    default:
                        throw new Error('Unknown object to delete: ' + objectType);
                }
                return objectType + ' deleted.';
            }
            
            function deleteTrainer(username) {
                if (!_uniqueTrainerUsernames[username]) {
                    throw new Error('Cannot delete missing trainer: ' + username);
                }
                
                delete _uniqueTrainerUsernames[username];
                
                _trainers = _trainers.filter(function (trainer) {
                    return trainer.getUsername() != username;
                });
                
                _trainings.forEach(function (training) {
                    training.setTrainer(undefined);
                });
            }
            
            var trainingCenterEngine = {
                initialize: initialize,
                executeCommand: executeCommand
            };
            return trainingCenterEngine;
        }());
        
        
        var trainingcenter = {
            Trainer: Trainer,
            Course: Course,
            Seminar: Seminar,
            RemoteCourse: RemoteCourse,
            engine: {
                TrainingCenterEngine: TrainingCenterEngine
            }
        };
        
        return trainingcenter;

    })();
    
    
    // Process the input commands and return the results
    var results = '';
    trainingcenter.engine.TrainingCenterEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != '') {
            try {
                var cmdResult = trainingcenter.engine.TrainingCenterEngine.executeCommand(cmd);
                results += cmdResult + '\n';
            } catch (err) {
                //console.log(err.stack);
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
            console.log(processTrainingCenterCommands(arr));
        });
    }
})();

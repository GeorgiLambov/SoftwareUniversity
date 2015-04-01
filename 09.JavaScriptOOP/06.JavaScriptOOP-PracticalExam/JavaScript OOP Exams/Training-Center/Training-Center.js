function processTrainingCenterCommands(commands) {
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
    };
    
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
            // if type is different by string and is a empty str or undefined
            throw new Error(variableName + " should be non-empty string or Undefined.");
        }
    }
    
    Object.prototype.validateEmptyString = function (value, variableName) {
        if (typeof (value) != Types.Undefined && !value) {
            throw new Error(variableName + " should be non-empty string.");
        }
    }
    
    Object.prototype.validateNonEmptyObject = function (value, className, variableName) {
        if (!(value instanceof className)) {
            throw new Error(variableName + " should be non-empty" + 
                className.prototype.constructor.name + ".");
        }
    }
    Object.prototype.isNullOrUndefined = function (value) {
        
        return (typeof (value) == 'undefined') || (value == null);
      
    }
    
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
    
    
    
    var trainingcenter = (function () {
        
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
                        var seminar = new trainingcenter.Seminar(objectData.name, objectData.description, trainer, parseDate(objectData.date));
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
                if (!username) {
                    return undefined;
                }
                for (var i = 0; i < _trainers.length; i++) {
                    if (_trainers[i].getUserName() == username) {
                        return _trainers[i];
                    }
                }
                throw new Error("Trainer not found: " + username);
            }
            
            function addTrainer(trainer) {
                if (_uniqueTrainerUsernames[trainer.getUserName()]) {
                    throw new Error('Duplicated trainer: ' + trainer.getUserName());
                }
                _uniqueTrainerUsernames[trainer.getUserName()] = true;
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
                var targetName = cmdArgs.splice(1).join(' ');
                switch (objectType) {
                    case 'Trainer':
                        var trainer = findTrainerByUsername(targetName);
                        delete _uniqueTrainerUsernames[username];
                        // _uniqueTrainerUsernames[trainer.getUserName()] = false;
                        _trainers.remove(trainer);
                        
                        _trainings.forEach(function (trainingCourse) {
                            if (trainingCourse.getTrainer().getUserName() === targetName) {
                                trainingCourse.setTrainer(undefined);
                            }
                        });
                        break;
                    default:
                        throw new Error('Unknown object to delete: ' + objectType);
                }
                return objectType + ' deleted.';
            }
            
            var trainingCenterEngine = {
                initialize: initialize,
                executeCommand: executeCommand
            };
            return trainingCenterEngine;
        }());
        
        var Trainer = (function () {
            function Trainer(userName, firstName, lastName, email) {
                this.setUserName(userName);
                this.setFirstName(firstName);
                this.setLastName(lastName);
                this.setEmail(email);
            }
            
            Trainer.prototype.getUserName = function () {
                return this._userName;
            };
            Trainer.prototype.setUserName = function (userName) {
                this.validateNonEmptyString(userName, "userName");
                this._userName = userName;
            };
            Trainer.prototype.getFirstName = function () {
                return this._firstName;
            };
            Trainer.prototype.setFirstName = function (firstName) {
                this.validateEmptyString(firstName, "firstName");
                this._firstName = firstName;
            };
            Trainer.prototype.getLastName = function () {
                return this._lastName;
            };
            Trainer.prototype.setLastName = function (lastName) {
                this.validateNonEmptyString(lastName, "lastName");
                this._lastName = lastName;
            };
            Trainer.prototype.getEmail = function () {
                return this._email;
            };
            Trainer.prototype.setEmail = function (email) {
                if (!this.isNullOrUndefined(email)) {
                    if (typeof (email) != 'string') {
                        throw new Error(email + " should be a string. Invalid value: " + email);
                    }
                    if (email.indexOf('@') == -1) {
                        throw new Error(email + " should hold an email address. Invalid value: " + email);
                    }
                }
                
                
                this._email = email;
            };
            
            Trainer.prototype.toString = function () {
                var result = [];
                
                if (this.getUserName() !== undefined) {
                    result.push("username=" + this.getUserName());
                }
                if (this.getFirstName() !== undefined) {
                    result.push("first-name=" + this.getFirstName());
                }
                if (this.getLastName() !== undefined) {
                    result.push("last-name=" + this.getLastName());
                }
                if (this.getEmail() !== undefined) {
                    result.push("email=" + this.getEmail());
                }
                result = result.join(";");
                
                return "Trainer[" + result + "]";
            };
            
            return Trainer;
        }());
        
        
        var Training = (function () {
            function Training(name, description, trainer, date, duration) {
                if (this.constructor === Training) {
                    throw new Error("Can't instantiate abstract class Training.");
                }
                
                this.setCourseName(name);
                this.setDescription(description);
                this.setStartDate(date);
                this.setTrainer(trainer);
                this.setDuration(duration);
            }
            Training.prototype.getCourseName = function () {
                return this._courseName;
            };
            Training.prototype.setCourseName = function (courseName) {
                this.validateNonEmptyString(courseName, "courseName");
                this._courseName = courseName;
            };
            Training.prototype.getDescription = function () {
                return this._description;
            };
            Training.prototype.setDescription = function (description) {
                this.validateEmptyString(description, 'description');
                this._description = description;
            };
            Training.prototype.getDate = function () {
                return this._startDate;
            };
            Training.prototype.setStartDate = function (date) {
                this.validateNonEmptyObject(date, Date, "Date");
                var firstDateInRange = new Date(parseDate("1-Jan-2000"));
                var secondDateInRange = new Date(parseDate("31-Dec-2020"));
                
                // -1 if a < b     0 if a = b      1 if a > b
                
                if ((dates.compare(firstDateInRange, date) != -1) && 
                    (dates.compare(secondDateInRange, date) != 1)) {
                    
                    throw new Error("Date must be greater than" + formatDate(firstDateInRange));
                }
                
                this._startDate = date;
            };
            Training.prototype.getTrainer = function () {
                return this._trainer;
            };
            Training.prototype.setTrainer = function (trainer) {
                if (!this.isNullOrUndefined(trainer)) {
                    if (!(trainer instanceof Trainer)) {
                        throw new Error(trainer + " should be non-empty" + Trainer.prototype.constructor.name + ".");
                    }
                }
                
                this._trainer = trainer;
            };
            Training.prototype.getDuration = function () {
                return this._duration;
            };
            Training.prototype.setDuration = function (duration) {
                if (!this.isNullOrUndefined(duration)) {
                    if (typeof (duration) != 'number') {
                        throw new Error(duration + " should be a number. Invalid value: " + duration);
                    }
                    if (duration !== parseInt(duration, 10)) {
                        throw new Error(duration + " should be an integer. Invalid value: " + duration);
                    }
                    if (duration <= 1 && duration >= 99) {
                        throw new Error("Course Duration must be in a range [1...99].");
                    }
                }
                
                this._duration = duration;
            };
            
            Training.prototype.toString = function () {
                var result = '' + this.constructor.name;
                result += "[name=" + this.getCourseName();
                if (this.getDescription() !== undefined) {
                    result += ";description=" + this.getDescription();
                }
                if (this.getTrainer() !== undefined) {
                    result += ";trainer=" + this.getTrainer();
                }
                
                return result;
            };
            
            return Training;
        }());
        
        
        var Course = (function () {
            function Course(name, description, trainer, date, duration) {
                Training.call(this, name, description, trainer, date, duration);
            }
            
            Course.extends(Training);
            
            Course.prototype.toStringDateDuration = function () {
                var result = '' + Training.prototype.toString.call(this);
                var dateStr = formatDate(this.getDate());
                result += ";start-date=" + dateStr;
                if (this.getDuration() !== undefined) {
                    result += ";duration=" + this.getDuration();
                }
                
                return result;
            }
            
            Course.prototype.toString = function () {
                
                return this.toStringDateDuration() + "]";
            };
            
            return Course;
        }());
        
        
        var RemoteCourse = (function () {
            function RemoteCourse(name, description, trainer, date, duration, location) {
                Course.call(this, name, description, trainer, date, duration);
                
                this.setLocation(location);
            }
            
            RemoteCourse.extends(Course);
            
            RemoteCourse.prototype.getLocation = function () {
                return this._location;
            };
            
            RemoteCourse.prototype.setLocation = function (location) {
                this.validateNonEmptyString(location, "location");
                this._location = location;
            };
            RemoteCourse.prototype.toString = function () {
                var result = '' + Course.prototype.toStringDateDuration.call(this);
                if (this.getLocation() !== undefined) {
                    result += ";location=" + this.getLocation();
                }
                
                return result + "]";
            };
            
            return RemoteCourse;
        }());
        
        
        var Seminar = (function () {
            function Seminar(name, description, trainer, date) {
                Training.call(this, name, description, trainer, date);
            }
            
            Seminar.extends(Training);
            
            Seminar.prototype.toString = function () {
                var result = '' + Training.prototype.toString.call(this);
                var dateStr = formatDate(this.getDate());
                result += ";date=" + dateStr + "]";
                return result;
            };
            
            return Seminar;
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
    };
    var formatDate = function (date) {
        var day = date.getDate();
        var monthName = date.toString().split(' ')[1];
        var year = date.getFullYear();
        return day + '-' + monthName + '-' + year;
    };
    
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

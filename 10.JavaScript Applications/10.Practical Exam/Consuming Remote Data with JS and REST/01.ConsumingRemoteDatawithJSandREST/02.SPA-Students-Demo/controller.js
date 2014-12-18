var studentsApp = studentsApp || {};

studentsApp.controller = (function () {
    'use strict';
    function Controller(dataPersister) {
        this.persister = dataPersister;
    }
    Controller.prototype.load = function (selector) {
        this.attachEvents();
        this.ListAllStudents();     // ListAllBooks.call(this); prez func
    };

    Controller.prototype.ListAllStudents = function () {
        var _this = this;
        this.persister.students.getAll(
            function (data) {
                _this.printStudents(data);
            },
            function (error) {
                console.log(error);
            });
    };

    Controller.prototype.printStudents = function (data) {
        $('#all-students').html('');
        var selector = '#all-students';
        var allStudentsWrapper = $(selector);

        for (var i = 0; i < data.results.length; i++) {
            var student = data.results[i];
            attachStudentToDom(allStudentsWrapper, student);
        };
    };

    function attachStudentToDom(element, student) {
        var studentWrapper = $('<div />');
        studentWrapper.attr('data-id', student.objectId);
        var name = $('<div />').append('Name: ' + student.name);
        var grade = $('<div />').append('Grade:' + student.grade);
        var deleteButton = $('<button class="student-delete-btn">X</button>');
        var editButton = $('<button class="student-edit-btn">Edit</button>');

        studentWrapper.append(name);
        studentWrapper.append(grade);
        studentWrapper.append(deleteButton);
        studentWrapper.append(editButton);

        element.append(studentWrapper);
    }

    Controller.prototype.attachEvents = function () {

        var _this = this;

        $('#add-student').on('click', function (ev) {
            var student = {
                name: $('#name').val(),
                grade: $('#grade').val()
            };
            _this.persister.students.add(
                student,
				function addStudentSuccessHandler(data) {
				    //var studentsWrapper = $('#all-students');
				    //attachStudentToDom(studentsWrapper, student);
				    _this.ListAllStudents();
				},
				function addStudentErrorHandler(error) {
				    console.log(error);
				}
			);
        });

        $('#all-students').on('click', '.student-delete-btn', function (ev) {
            var id = $(this).parent().attr('data-id');
            _this.persister.students.delete(
				id,
                function deleteStudentSuccessHandler(data) {
                    $(ev.target).parent().remove();
                },
				function deleteStudentErrorHandler(error) {
				    console.log(error);
				}
			);
        });

        $('#all-students').on('click', '.student-edit-btn', function (ev) {
            var id = $(this).parent().attr('data-id');

            var student = {
                name: $('#name').val(),
                grade: $('#grade').val()
            };
            _this.persister.students.edit(
				id,
                student,
			    function editStudentSuccessHandler() {
			        _this.ListAllStudents();
			    },
				function editStudentErrorHandler(error) {
				    console.log(error);
				}
			);
        });
    };

    return {
        get: function (dataPersister) {
            return new Controller(dataPersister);
        }
    };
}());
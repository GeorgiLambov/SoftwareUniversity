/**
 * Created by Zhivko on 1.12.2014 г..
 */
var Question = (function(){
    function Question(id){
        this._id = id;
    }

    Question.prototype.setTrueAnswer = function (trueAnsswerId) {
        this._trueAnswerId = trueAnsswerId;
    };

    Question.prototype.saveUserAnswer = function (userAnswerId) {
        this._userAnswerId = userAnswerId;
        localStorage.setItem(this._id, userAnswerId);
    };

    Question.prototype.loadUserAnswer = function () {
        if(localStorage[this._id]){
            this._userAnswerId = localStorage[this._id];
            $('#' + this._userAnswerId).attr('checked', true);
        }

    };

    Question.prototype.showTrueAnswer = function () {
        $('#'  + this._trueAnswerId + '+ label').css('background', 'greenyellow');
    };

    Question.prototype.emptyStorage = function () {
        delete localStorage[this._id];
    };

    return Question;
})();
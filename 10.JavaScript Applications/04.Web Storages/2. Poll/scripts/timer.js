/**
 * Created by Zhivko on 30.11.2014 г..
 */
var Timer = (function () {
    var INTERVAL_TIMER_IN_SECONDS = 1;

    function Timer(seconds, selector, doThisWhenTimeIsUp) {
        this._startSeconds = seconds;
        this._isStop = true;
        this._doThisWhenTimeIsUp = doThisWhenTimeIsUp;

        if (!localStorage['timer']) {
            localStorage.setItem(
                'timer',
                JSON.stringify({
                    remainingSeconds: seconds
                })
            );
        } else {
            $('<div id="timer">')
                .text(seconds)
                .appendTo(selector);
        }
    };

    function showTime(selector) {
        var timer = JSON.parse(localStorage['timer']);
        $('#timer').text(timer.remainingSeconds);
    }

    Timer.prototype.start = function () {
        var _this = this;
        if (this._isStop) {
            this._timerId = setInterval(function () {
                    var timer = JSON.parse(localStorage['timer']);
                    timer.remainingSeconds -= INTERVAL_TIMER_IN_SECONDS;
                    localStorage.setItem(
                        'timer',
                        JSON.stringify({
                            remainingSeconds: timer.remainingSeconds
                        })
                    );

                    showTime();

                    if (timer.remainingSeconds <= 0) {
                        clearInterval(_this._timerId);
                        if (_this._doThisWhenTimeIsUp) {
                            _this._doThisWhenTimeIsUp();
                        }
                    }
                },
                INTERVAL_TIMER_IN_SECONDS * 1000
            );
            this._isStop = false;
        }
    };

    Timer.prototype.stop = function () {
        this._isStop = true;
        clearInterval(this._timerId);
        delete localStorage['timer'];
    };

    return Timer;
})();
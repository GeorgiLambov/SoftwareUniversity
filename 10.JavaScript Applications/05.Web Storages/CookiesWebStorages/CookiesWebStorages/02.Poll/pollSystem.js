(function () {
    $(function () {

        init();
        setTimer('.timer');

        $('input[name="question1"]')
			.on('click', function () {
			    localStorage.setItem('question1', $(this).attr('id'));
			});

        $('input[name="question2"]')
			.on('click', function () {
			    localStorage.setItem('question2', $(this).attr('id'));
			});

        $('input[name="question3"]')
			.on('click', function () {
			    localStorage.setItem('question3', $(this).attr('id'));
			});

        $('#submit').on('click', showResults);
        $('#go-back').on('click', goBack);
    });

    function setTimer(selector) {
        var timerInSec = 300;
        var seconds = 60;

        var timer = setInterval(function () {
            timerInSec--;
            seconds--;
            var minutes = Math.floor(timerInSec / 60);
            var secondsInString = seconds;
            if (seconds < 10) {
                secondsInString = '0' + seconds;
            }

            $(selector).text(minutes + ':' + secondsInString);

            if (seconds == 0) {
                seconds = 60;
            }
            if ((timerInSec / 60) === 0) {
                clearInterval(timer);
                timeOut();
            }
        }, 1000);
    }

    function goBack() {
        $('.result').hide(500);
        $('.questions-form').show(500);
    }

    function timeOut() {
        localStorage.clear();
        $('.questions-form').children().remove();
        $('.questions-form').append($('<h1 class="text-center">').text('Time is up.'))
    }

    function showResults() {
        var answer1 = $('input[name="question1"]:checked').val();
        var answer2 = $('input[name="question2"]:checked').val();
        var answer3 = $('input[name="question3"]:checked').val();

        $('.questions-form').hide(500);
        $('.result').find('#result-answer1').text(answer1);
        $('.result').find('#result-answer2').text(answer2);
        $('.result').find('#result-answer3').text(answer3);
        $('.result').show(500);
    }

    function makeChecked(id) {
        var currentAnswer = '#' + id;
        $(currentAnswer).attr('checked', 'checked');
    }

    function init() {
        if (localStorage.question1) {
            makeChecked(localStorage.question1);
        }
        if (localStorage.question2) {
            makeChecked(localStorage.question2);
        }
        if (localStorage.question3) {
            makeChecked(localStorage.question3);
        }
    }

})();
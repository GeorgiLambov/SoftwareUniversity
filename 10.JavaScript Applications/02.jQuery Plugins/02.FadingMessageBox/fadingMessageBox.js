(function ($) {
    $.fn.messageBox = function () {
        var $this = $(this);

        return {
            success: function (message) {
                $this.each(function () {
                    $this.css('background-color', 'green');
                    $this.animate({ 'opacity': 1 }, 1000);
                    $(this).html(message);
                    setInterval(function () { $this.animate({ 'opacity': 0 }, 1000); }, 3000);
                });

                return $this;
            },
            error: function (message) {
                $this.each(function () {
                    $this.css('background-color', 'red');
                    $this.animate({ 'opacity': 1 }, 1000);
                    $(this).html(message);
                    setInterval(function () { $this.animate({ 'opacity': 0 }, 1000); }, 3000);
                });

                return $this;
            }

        };
    };
}(jQuery));

$(document).ready(function () {
    var onSuccessButton = $('#on-success-btn').on('click', function () {
        var messageBox = $('#message-box').messageBox();
        messageBox.success('Success mesage');

    });

    var onErrorButton = $('#on-error-btn').on('click', function () {
        var messageBox = $('#message-box').messageBox();
        messageBox.error('Error mesage');
    });
});
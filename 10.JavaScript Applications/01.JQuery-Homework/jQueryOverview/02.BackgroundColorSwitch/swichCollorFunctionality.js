(function () {
    $(document).ready(function () {
        $('#paintButton').on('click', switchColor);
    });
    function switchColor() {
        var $targetClass = $('#class').val();
        var $targetColor = $('#color-picker').val();

        $('.' + $targetClass).css('background-color', $targetColor);

    }
}());
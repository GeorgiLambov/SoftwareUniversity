(function () {
    $(document).ready(function () {
        $('#after').on('click', addElementAfter);
        $('#before').on('click', addElementBefore);
    });

    function addElementAfter() {
        var targetDiv = $("<div class='demo-div'></div>").css("background-color", "#2a00ff");
        $(targetDiv).insertAfter($(".demo-div").last());

    }
    function addElementBefore() {
        var targetDiv = $("<div class='demo-div'></div>").css("background-color", "#0ae6f5");
        $(targetDiv).insertBefore($(".demo-div").first());
    }
}());


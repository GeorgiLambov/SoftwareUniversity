$(function () {
    var sliderPages = $("div").filter(function () {
        return this.id.match(/slider-page-\d+/);
    }).hide();
    $(sliderPages.get(0)).show();

    setInterval(function () { showPage("next"); }, 5000);

    sliderPages.click(function (e) {
        if (e.offsetX > ($("#slider").width() / 2)) {
            showPage("next");
        }
        else {
            showPage("previous");
        }
    });

    function showPage(whichPage) {
        var currentShownPage = $('div')
            .filter(function () {
                return this.id.match(/slider-page-\d+/);
            })
            .filter(":visible");
        currentShownPage.hide();

        var currentShownPageNumber = currentShownPage.attr("id").match(/\d+/)[0];

        switch (whichPage) {
            case "next":
                if (currentShownPageNumber == sliderPages.length) {
                    currentShownPageNumber = 0;
                }

                currentShownPageNumber++;
                break;
            case "previous":
                if (currentShownPageNumber == 1) {
                    currentShownPageNumber = sliderPages.length + 1;
                }
                currentShownPageNumber--;
                break;
        }
        $("#slider-page-" + currentShownPageNumber).fadeIn(800);
    }
});
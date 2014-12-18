$(function () {
    var PARSE_APP_ID = "95OfM71T3mihVLZTGcrMNhkBNnqzQcjMV6AAm0ri";
    var PARSE_REST_API_KEY = "JZb5nuvaPuPy1X1qSmKQBkinSHAFsqaXcOhhbN7I";

    loadCountries();

    $('#add-country-button').on('click', function () {
        var $countryName = $('#add-country').val();
        // check if name is not empty or whitespacess string
        if (/^\s*$/.test($countryName)) {
            addItemError();
            return;
        }

        addCountry($countryName);
        $('#add-country').val('');
    });

    $('#add-town-button').on('click', function () {
        var $townName = $('#add-town').val();
        // check if name is not empty or whitespacess string
        if (/^\s*$/.test($townName)) {
            addItemError();
            return;
        }

        addTown($townName);
        $('#add-country').val('');
    });

    function addCountry(countryName) {
        // format country name before making the AJAX request
        var countryNameFormated = formatString(countryName);
        $.ajax({
            method: "POST",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: "https://api.parse.com/1/classes/Country",
            data: JSON.stringify({
                "name": countryNameFormated
            }),
            contentType: "application/json",
            // on success notify user  about changes and reload countries on the page 
            // so that the newly added countries could be displyed
            success: [addedSuccessfully, loadCountries],
            error: ajaxError
        });
    };

    function loadCountries() {
        $('#countries-list li').remove();
        $('#towns').hide();
        $.ajax({
            method: "GET",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: "https://api.parse.com/1/classes/Country",
            success: countriesLoading,
            Error: ajaxError
        });
    }

    function countriesLoading(data) {
        if (data.results.length) {
            $('#countries').show();
        }

        for (var c in data.results) {
            var country = data.results[c];

            var countryItem = $('<li>').attr('id', 'country.name').text(country.name);

            $(countryItem).data('country', country);

            var listTownsButton = $('<a href="#" class="button list">List Towns</a>');
            var editButton = $('<a href="#" class="button edit">Edit</a>');
            var deleteButton = $('<a href="#" class="button delete">Delete</a>');
            // atach data about each country on the list item holding it
            $(listTownsButton).data('country', country);
            $(editButton).data('country', country);
            $(deleteButton).data('country', country);

            listTownsButton.appendTo(countryItem);
            listTownsButton.click(listCountryTowns);
            editButton.appendTo(countryItem);
            //editButton.click("");
            deleteButton.appendTo(countryItem);
            deleteButton.click(deleteCountry);

            countryItem.appendTo($("#countries-list"));
        }
    }

    function deleteCountry() {
        $('#towns').hide();
        var country = $(this).data('country');
        $.ajax({
            method: "DELETE",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: "https://api.parse.com/1/classes/Country/" + country.objectId,
            // on success notify user  about changes and reload countries on the page 
            // so that the newly added countries could be displyed
            success: [deletedSuccessfully, loadCountries],
            error: ajaxError
        });
    }

    function listCountryTowns() {
        var country = $(this).data('country');
        var countryID = country.objectId;

        $.ajax({
            method: "GET",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: 'https://api.parse.com/1/classes/Town?where={"country":{"__type":"Pointer","className":"Country","objectId":"' + countryID + '"}}',
            success: townsLoading,
            Error: ajaxError
        });
    }

    function townsLoading(data) {
        $("#towns ul").html('');
        $("#towns h2").html('');

        if (data.results.length > 0) {
            var townString = (data.results.length == 1 ? "Town" : "Towns");
            $('#towns h2').text(townString);
        }

        for (var t in data.results) {
            var town = data.results[t];
            var townItem = $('<li>');
            townItem.text(town.name);
            townItem.appendTo($('#towns ul'));
        }
        $('#towns').show();
    }

    function addTown(townName) {

        var country = $('#towns h2').data('country');

        // format country name before making the AJAX request
        var townNameFormated = formatString(townName);
        $.ajax({
            method: "POST",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: "https://api.parse.com/1/classes/Town",
            data: JSON.stringify({
                "name": townNameFormated,
                'country': {
                    "__type": "Pointer",
                    "className": "Country",
                    "objectId": country.objectId
                }
            }),
            contentType: "application/json",
            // on success notify user  about changes and reload countries on the page 
            // so that the newly added countries could be displyed
            success: [addedSuccessfully, listCountryTowns],
            error: ajaxError
        });
    };

    function deleteTown() {

        var town = $('#deleteTown').data('town');
        $.ajax({
            method: "DELETE",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: "https://api.parse.com/1/classes/Town/" + town.objectId,

            success: [deletedSuccessfully, listCountryTowns],
            error: ajaxError
        });

        $(this).dialog("close");
    };

    function formatString(string) {
        var trimmed = string.trim();
        return trimmed.charAt(0).toUpperCase() + string.slice(1);
    }

    function ajaxError() {
        noty({
            text: 'Cannot load AJAX data.',
            type: 'error',
            layout: 'topCenter',
            timeout: 5000
        });
    }
    // noty function for an invalid item name error
    function addItemError() {
        noty({
            text: 'Text can not be empty',
            type: 'error',
            layout: 'topCenter',
            timeout: 1000
        });
    }

    // noty function for succssfuly added item
    function addedSuccessfully() {
        noty({
            text: 'Item added successfully',
            type: 'success',
            layout: 'topCenter',
            timeout: 2000
        });
    }
    function deletedSuccessfully() {
        noty({
            text: 'Item deleted successfully',
            type: 'success',
            layout: 'topCenter',
            timeout: 2000
        });
    }
});
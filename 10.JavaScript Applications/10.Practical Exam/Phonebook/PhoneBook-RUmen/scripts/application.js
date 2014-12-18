'use strict';

(function(){
    $(document).ready(function () {
          registerEventHandlers();

        if(userSessionData.loadData()){
            showPhonebookView();
        }else{
            showHomeView();
        }
    });

    function registerEventHandlers(){
        $("#welcomeRegisterButton").on("click",showRegisterView);
        $("#welcomeLoginButton").on("click", showLoginView);
        $("#registrationRegisterButton").on("click",registerButtonClicked);
        $("#loginLoginButton").on("click",loginButtonClicked);
        $("#registrationLoginButton").on("click",showLoginView);
        $("#loginRegisterButton").on("click",showRegisterView);
        $("#menuHome").on("click",showUserHomeView);
        $("#menuPhonebook").on("click",showPhonebookView);
        $("#menuLogout").on("click",sessionLogout);
        $("#menuAddPhone").on("click", showAddPhoneView);
        $("#addButton").on("click", showAddPhoneView);
        $("#addPhoneAddButton").on("click", addPhone);
        $("#addPhoneCancelButton").on("click", showPhonebookView);
        $("#deleteViewDeleteButton").on("click", deletePhone);
        $("#deleteViewCancelButton").on("click", showPhonebookView);

    }

    function showHomeView(){
        $("main > *, ul").hide();
        $("#header > span").text(" - Welcome");
        $("#welcome-form").show();
    }

    function showRegisterView() {
        $("main > *, ul").hide();
        $("#header > span").text(" - Registration");
        $("#register-form").show();
    }

    function showLoginView() {
        var loginUsername = $("#loginUsername").val("");
        var loginPassword = $("#loginPassword").val("");
        $("main > *, ul").hide();
        $("#header > span").text(" - Login");
        $("#login-form").show();
    }

    function showUserHomeView() {
        $("main > *, ul").hide();
        $("#header > span").text(" - Home");

        //TODO add fullname and username in the Welcome -> <span>

        $("#userHomeView, #menu").show();
    }

    function showPhonebookView (){
        var currentUser = userSessionData.loadData();
        $(".dataRow").remove();
        if(currentUser) {
            $("main > *").hide();
            $("#header > span").text(" - List");
            var sessionToken = currentUser.sessionToken;

            ajaxRequester.getPhones(sessionToken, loadPhonesSuccess, loadPhonesFailure);

            $("#phones, #addButton").show();
        }else{
            showHomeView();
        }
    }

    function showAddPhoneView (){
        var addedPhonePersonName = $("#addPhonePersonName").val("");
        var addedPhoneNumber = $("#addPhoneNumber").val("");

        $("main > *").hide();
            $("#header > span").text(" - Add Phone");
            $("#add-phone-form").show();
    }

    function showDeletePhoneView (){
        $("main > *").hide();
        $("#header > span").text(" - Delete Phone");

        var phoneData = $(this).parent().data("phone");
        var $person = phoneData.person;
        var $number = phoneData.number;
        var $phoneId = phoneData.objectId;
        $(this).data("phoneId", $phoneId)

        $("#deletePhonePersonName").val($person);
        $("#deletePhoneNumber").val($number);
        $("#delete-phone-form").show();
    }

    function registerButtonClicked(){
        var registerUsername = $("#registrationUsername").val();
        var registerPassword = $("#registrationPassword").val();
        var registerFullName = $("#registrationFullName").val();
        $("#registrationRegisterButton").data("FullName", registerUsername);

        ajaxRequester.register(registerUsername, registerPassword, registerFullName, authenticationSuccess, registerFailure);
    }

    function authenticationSuccess(data){
        showSuccessMessage("Login successful");
        userSessionData.saveData(data);
        showUserHomeView();
    }

    function registerFailure(error){
        showAjaxError("Invalid login", error);
    }

    function loginButtonClicked(){
        var loginUsername = $("#loginUsername").val();
        var loginPassword = $("#loginPassword").val();

        ajaxRequester.login(loginUsername, loginPassword, authenticationSuccess, loginFailure);
    }

    function loginFailure(error){
        showAjaxError("Invalid login", error);
    }

    function sessionLogout(){
        userSessionData.deleteData();
        showLoginView();
        showSuccessMessage("Logout successful");
    }



    function loadPhonesSuccess(data){
        var result = data.results;
        var $phoneTable = $("#phones");

        for(var phone in result){
            var phoneData = result[phone];
            var phonePerson = phoneData.person;
            var phoneNumber = phoneData.number;

            var $tableRow = $('<tr class="dataRow">');
            $tableRow.data("phone", phoneData);

            var $tablePersonName = $("<td>").text(phonePerson);
            $tableRow.append($tablePersonName);
            var $tablePersonNumber = $("<td>").text(phoneNumber);
            $tableRow.append($tablePersonNumber);
            var $tableEditButton = $('<a href="#" class="link">').text("Edit ");
//            $tableEditButton.click(showDeletePhoneView);
            $tableRow.append($tableEditButton);
            var $tableDeleteButton = $('<a href="#" class="link">').text("Delete");
            $tableDeleteButton.click(showDeletePhoneView);
            $tableRow.append($tableDeleteButton);
            $phoneTable.append($tableRow);
        }
    }

    function loadPhonesFailure(error){
        showAjaxError("Unable to load requested data!", error);
    }

    function addPhone(){
        var addedPhonePersonName = $("#addPhonePersonName").val();
        var addedPhoneNumber = $("#addPhoneNumber").val();
        var currentUser = userSessionData.loadData();
        var userId = currentUser.objectId;

        ajaxRequester.addPhone(addedPhonePersonName, addedPhoneNumber, userId, addPhoneSuccess, addPhoneFailure)
    }

    function addPhoneSuccess(){
        showSuccessMessage("Phone added successfully!");
    }

    function addPhoneFailure(error){
        showAjaxError("Phone was not added due to error", error);
    }

    function deletePhone(){
        var currentUser = userSessionData.loadData();
        var sessionToken = currentUser.sessionToken;
        var phoneData = $(this).data("phoneId");
        var $phoneId = phoneData.objectId;

        ajaxRequester.deletePhone(sessionToken, $phoneId, showPhonebookView, deletePhoneError);
    }

    function deletePhoneError(error){
        showAjaxError("Phone was not deleted!", error)
    }

    function showAjaxError(message, error) {
        var errorMessage = error.responseJSON;
        if (errorMessage && errorMessage.error) {
            showErrorMessage(message + ": " + errorMessage.error);
        } else {
            showErrorMessage(message + ".");
        }
    }

    function showSuccessMessage(message) {
        noty({
                text: message,
                type: 'success',
                layout: 'topCenter',
                timeout: 2000}
        );
    }

    function showErrorMessage(message) {
        noty({
                text: message,
                type: 'error',
                layout: 'topCenter',
                timeout: 2000}
        );
    }
}());

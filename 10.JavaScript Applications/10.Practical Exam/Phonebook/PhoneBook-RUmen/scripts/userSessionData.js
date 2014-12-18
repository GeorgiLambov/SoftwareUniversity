'use strict';

var userSessionData = (function(){

    function saveData(data){
        sessionStorage.setItem("data", JSON.stringify(data));
    }

    function loadData(){
        if(sessionStorage.getItem("data")){
            var loginData = JSON.parse(sessionStorage.getItem("data"));
        }
        return loginData;
    }

    function deleteData(){
        sessionStorage.clear();
    }

    return {
        saveData: saveData,
        loadData: loadData,
        deleteData: deleteData
    }
}());
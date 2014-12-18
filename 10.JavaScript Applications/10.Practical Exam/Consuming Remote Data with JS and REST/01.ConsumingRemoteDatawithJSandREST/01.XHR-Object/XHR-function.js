(function () {
    var xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function() {
        if (xhr.readyState == 4) {
            var statusType = Math.floor(xhr.status / 100);
            if (statusType === 2) {
                console.log('Successful status: ' + xhr.status);
            } else if (statusType === 3) {
                console.log('Redirect status: ' + xhr.status);
            } else if (statusType === 4) {
                console.log('Not found status: ' + xhr.status);
            } else if (statusType === 5) {
                console.log('Server error status: ' + xhr.status);
            }
        };
    };

    xhr.open('GET', 'https://api.parse.com/1/classes/Country', true);
    xhr.send(null);   // pri 'GET' zaiavka
}());
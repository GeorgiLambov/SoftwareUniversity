(function () {
    //task 01: Like/Unlike Button
    var likeUnlikeButton = document.getElementById('first-task-button');
    likeUnlikeButton.addEventListener('click', function () {
        if (likeUnlikeButton.innerText === 'Like') {
            likeUnlikeButton.innerText = 'Unlike';
        }
        else {
            likeUnlikeButton.innerText = 'Like';
        }
    });

    //task 02: Divs into ul
    var divs = document.querySelectorAll('#second-task div');
    var result = document.getElementById('result');

    var fragment = document.createDocumentFragment();
    var liModel = document.createElement('li');

    for (var div in divs) {
        if (divs[div] instanceof HTMLDivElement && !(divs[div].classList.contains('empty'))) {
            var currentLi = liModel.cloneNode(true);
            currentLi.textContent = divs[div].innerText;
            fragment.appendChild(currentLi);
        }
    }

    result.appendChild(fragment);

    //task 03: Hide odd rows
    var list = document.getElementById('third-task');
    var listTable = list.children[0];

    var btnHideOddRows = document.getElementById('btnHideOddRows');
    btnHideOddRows.addEventListener('click', function () {
        for (var i = 0; i < listTable.rows.length; i++) {
            if (i % 2 === 0) {
                listTable.rows[i].style.display = 'none';
            }
        }
    });

    //task 04: Numbers only field
    var numberResult = document.getElementById('fourth-task-result');

    var numberInput = document.getElementById('fourth-task-input');
    var previousValue = numberInput.value;
    numberInput.addEventListener('keyup', function (ev) {
        var target = ev.target;
        var value = target.value;

        if (isNaN(value)) {
            target.value = previousValue;
            numberResult.style.backgroundColor = 'red';
            numberInput.setAttribute('readonly', 'readonly');

            setTimeout(function () {
                numberResult.style.backgroundColor = 'white';
                numberInput.removeAttribute('readonly');
            }, 1000);
        }
        else {
            previousValue = value;
            numberResult.innerText = previousValue;
        }
    });

    //task 05: Mouse position
    var mousePositionContainer = document.getElementById('fifth-task');
    var mouse = { x: 0, y: 0 };

    document.addEventListener('mousemove', function (e) {
        mouse.x = e.clientX || e.pageX;
        mouse.y = e.clientY || e.pageY;
        mousePositionContainer.innerText = 'X: ' + mouse.x + ' Y: ' + mouse.y;
    }, false);

})();
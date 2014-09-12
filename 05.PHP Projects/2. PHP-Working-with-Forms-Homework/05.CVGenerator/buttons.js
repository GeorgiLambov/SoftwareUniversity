var nextId = 0;
var nextId2 = 0;
function addPcLanguage() {
    nextId++;
    var pcDiv = document.createElement('div');
    pcDiv.setAttribute('id', 'pc-lang' + nextId);
    pcDiv.innerHTML = '<input type="text" name="pc-lang[]"/>' + ' <select name="pc-level[]">' + '<option value="Beginner">Beginner</option>' + '<option value="Programmer">Programmer</option>' + '<option value="Ninja">Ninja</option>' + '</select>'
    document.getElementById('pclang-box').appendChild(pcDiv);

}

function removePcLanguage(id) {
    nextId--;
    var pcDiv = document.getElementById(id);
    document.getElementById('pclang-box').removeChild(pcDiv);
}

function addLanguage() {
    nextId2++;
    var langDiv = document.createElement('div');
    langDiv.setAttribute('id', 'lang' + nextId2);
    langDiv.innerHTML = '<input type="text" name="lang[]"/>' + ' <select name="compr-level[]">' + '<option>-Comprehension-</option>' + '<option value="Beginner">Beginner</option>' + '<option value="Intermediate">Intermediate</option>' + '<option value="Advanced">Advanced</option>' + '</select>' + ' <select name="read-level[]">' + '<option>-Reading-</option>' + '<option value="Beginner">Beginner</option>' + '<option value="Intermediate">Intermediate</option>' + '<option value="Advanced">Advanced</option>' + '</select>' + ' <select name="write-level[]">' + '<option>-Writing-</option>' + '<option value="Beginner">Beginner</option>' + '<option value="Intermediate">Intermediate</option>' + '<option value="Advanced">Advanced</option>' + '</select>';
    document.getElementById('lang-box').appendChild(langDiv);
}

function removeLanguage(id) {
    nextId2--;
    var langDiv = document.getElementById(id);
    document.getElementById('lang-box').removeChild(langDiv);
}

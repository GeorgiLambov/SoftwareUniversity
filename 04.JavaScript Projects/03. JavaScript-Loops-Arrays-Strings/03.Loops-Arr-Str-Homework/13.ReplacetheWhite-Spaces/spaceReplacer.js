function replaceSpaces(str) {
    var find = ' ';
    var re = new RegExp(find, 'g');
    var str = str.replace(re, '');
    console.log(str);
}

replaceSpaces("But you were living in another world tryin' to get your message through");
function reverseWordsInString(str) {
    var wordsArr = str.split(' ');
    var result = '';
    for (var i = 0; i < wordsArr.length; i++) {
        var reverse = wordsArr[i].split("").reverse().join("");
        result += reverse + " ";
    }
    result.trim();
    console.log(result);

}
reverseWordsInString("Hello, how are you.");
reverseWordsInString("Life is pretty good, isn't it?");
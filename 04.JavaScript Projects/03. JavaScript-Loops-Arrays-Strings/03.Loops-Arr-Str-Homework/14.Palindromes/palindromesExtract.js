function findPalindromes(str) {
    var palindromes = [];
    str = str.toLowerCase();
    str = str.replace(".", "").replace(",", "");
    str = str.split(" ");
    for (var i = 0; i < str.length; i++) {
        var reversed = str[i].split('').reverse().join('');
        if (str[i] === reversed) {
            palindromes.push(str[i]);
        }
    }
    console.log(palindromes.join(', '));
}


findPalindromes("There is a man, his name was Bob.");
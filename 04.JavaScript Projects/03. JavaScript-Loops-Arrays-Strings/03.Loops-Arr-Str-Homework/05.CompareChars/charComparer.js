function compareChars(arr1, arr2) {
    
    var counterOfEqualElements = 0;
    if (arr1.length != arr2.length) {
        return "Not Equal";
    } else {
        for (var i = 0; i < arr1.length; i++) {
            if (arr1[i] === arr2[i]) {
                counterOfEqualElements++;
            }
        }
        if (counterOfEqualElements == arr1.length) {
            return "Equal";
        } else {
            return "Not Equal";
        }
    }
    
}
console.log(compareChars(['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q'], ['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q']));
console.log(compareChars(['3', '5', 'g', 'd'], ['5', '3', 'g', 'd']));
console.log(compareChars(['q', 'g', 'q', 'h', 'a', 'k', 'u', '8', '}', 'q', '.', 'h', '|', ';'], ['6', 'f', 'w', 'q', ':', '”', 'd', '}', ']', 's', 'r']));
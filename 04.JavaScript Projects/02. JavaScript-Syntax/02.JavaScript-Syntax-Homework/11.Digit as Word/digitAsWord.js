function convertDigitToWord(value) {
    switch (value) {
        case 1: return "One"; break;
        case 2: return "Two"; break;
        case 3: return "Three"; break;
        case 4: return "Four"; break;
        case 5: return "Five"; break;
        case 6: return "Six"; break;
        case 7: return "Seven"; break;
        case 8: return "Eight"; break;
        case 9: return "Nine"; break;
        default: "Error"; break;

    }
}

console.log(convertDigitToWord(8));
console.log(convertDigitToWord(3));
console.log(convertDigitToWord(5));
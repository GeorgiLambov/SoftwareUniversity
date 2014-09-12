function findCardFrequency(input) {
    
    var cards = input.split(/[♥♣♦♠ ]+/);
    cards.pop();
    var cardsFrequence = [];
    var n = cards.length;
    
    for (var i = 0; i < cards.length; i++) {
        var card = cards[i];
        
        if (card in cardsFrequence) {
            cardsFrequence[card]++;      // if exist, frequencies is + 1      
        } else {
            cardsFrequence[card] = 1;
        }
    }
    
    //all unique cards and their frequency
    cards = getUniqueElements(cards);
    
    function getUniqueElements(arr) {
        var uniqueElements = [];
        
        for (var i in arr) {
            if (uniqueElements.indexOf(arr[i]) === -1) {
                // if elements doesn't exist, add it to the array
                uniqueElements.push(arr[i]);
            }
        }
        
        return uniqueElements;
    }
    
    // Print in the order of the card face's first appearance in the input
    for (var i = 0; i < cards.length; i++) {
        var card = cards[i];
        var procent = (cardsFrequence[card] / n) * 100;
        console.log(card + " -> " + procent.toFixed(2) + "%");
    }
}

findCardFrequency('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦');
findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠');
findCardFrequency('10♣ 10♥');
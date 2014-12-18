function Solve(input) {
    var text = input[0];
    text = text.replace('J', 11);
    text = text.replace('Q', 12);
    text = text.replace('K', 13);
    text = text.replace('A', 14);
    var cardsArr = text.split(', ');
    var result = '';

    for (var a = 0; a < cardsArr.length; a++) {
        for (var b = 0; b < cardsArr.length; b++) {
            for (var c = 0; c < cardsArr.length; c++) {
                for (var d = 0; d < cardsArr.length; d++) {
                    for (var f = 0; f < cardsArr.length; f++) {
                        var reg1 = /[0-9]*/;
                        var reg2 = /[^0-9]/;
                        var card1Order = parseInt('' + cardsArr[a].match(reg1));
                        var card1Suit = '' + cardsArr[a].match(reg2);

                        var card2Order = parseInt('' + cardsArr[b].match(reg1));
                        var card2Suit = '' + cardsArr[b].match(reg2);

                        var card3Order = parseInt('' + cardsArr[c].match(reg1));
                        var card3Suit = '' + cardsArr[c].match(reg2);

                        var card4Order = parseInt('' + cardsArr[d].match(reg1));
                        var card4Suit = '' + cardsArr[d].match(reg2);

                        var card5Order = parseInt('' + cardsArr[f].match(reg1));
                        var card5Suit = '' + cardsArr[f].match(reg2);

                        var check = (card1Suit == card2Suit) && (card2Suit == card3Suit) && (card3Suit == card4Suit) && (card4Suit == card5Suit);
                        var check1 = (card2Order == card1Order + 1) && (card3Order == card2Order + 1) && (card4Order == card3Order + 1) && (card5Order == card4Order + 1);

                        if (check && check1) {

                            result += "[" + cardSwich(card1Order) + card1Suit + ", " + cardSwich(card2Order) + card2Suit + ", " + cardSwich(card3Order) + card3Suit + ", " + cardSwich(card4Order) + card4Suit + ", " + cardSwich(card5Order) + card5Suit + "]\n";

                        }
                    }
                }
            }
        }
    }
    console.log(result);
    function cardSwich(cardOrder) {
        if (cardOrder > 10) {
            switch (cardOrder) {
                case 11: return "J"; break;
                case 12: return "Q"; break;
                case 13: return "K"; break;
                case 14: return "A"; break;
            }
        }
        return cardOrder;
    }
}
//Solve(['9D, 2S, 10D, AD, 10H, JD, QD, KD']);
//Solve(['AS, KH, 10C']);
//Solve(['2S, 2C, 2D, 2H, AS, KH, 10C']);
Solve(['5H, AS, 10C, 8H, KS, KH, KD, 9H, JH, QS, 3H, QD, 4H, QH, 8S, 10D, 6H, 10S, 10H, 7C, JD, JS, 2H, 7S, 7D']);
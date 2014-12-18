function Solve(input) {
    var startingDay = Number(input[0]);
    var d = Number(input[1]);
    var Watermelon = 0;
    var melon = 0;
    while (d > 0) {
        switch (startingDay) {
            case 1: Watermelon += 1; break;
            case 2: melon += 2; break;
            case 3: Watermelon += 1; melon += 1; break;
            case 4: Watermelon += 2; break;
            case 5: Watermelon += 2; melon += 2; break;
            case 6: Watermelon += 1; melon += 2; break;
            case 7: break;
        }
        d--;
        startingDay++;
        if (startingDay > 7) {
            startingDay = 1;
        }
    }
    if (Watermelon > melon) {
        console.log("%d more watermelons", Watermelon - melon);
    } else if (melon > Watermelon) {
        console.log("%d more melons", melon - Watermelon);
    } else {
        console.log("Equal amount: %d", melon);
    }

}

Solve(['5', '6']);
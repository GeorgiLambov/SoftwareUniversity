function Solve(input) {
    var stacks = 0;
    var beers = 0;
    for (var i = 0; i < input.length; i++) {
        var str = input[i];
        if (str === "End") {
            break;
        }
        str = str.split(' ');
        var count = Number(str[0]);
        var measure = str[1];
        if (measure === 'stacks') {
            stacks += count;
        } else {
            beers += count;
        }
        if (beers > 19) {
            stacks += Math.floor(beers / 20);
            beers = beers % 20;
        }
    }
    console.log("%d stacks + %d beers", stacks, beers);
}

Solve(['4 stacks',
'12 beers',
'10 beers',
'1 stacks',
'1 beers',
'End']);
Solve(['41 beers',
'1 stacks',
'19 beers',
'End']);

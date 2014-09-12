function findMaxSequence(arr) {
    var count = 0;
    var maxCount = 1;
    var posision = 0;
    var result = [];
    for (var i = 0; i < arr.length; i++) {
        count = 0;
        var j = i;
        
        while (arr[j] === arr[i]) {
            count++;
            j++;
            if (j == arr.length) {
                break;
            }
        }
        if (count >= maxCount) {
            maxCount = count;
            posision = i;

        }
    }
    result = arr.slice(posision, (maxCount + posision));
    console.log(result);
}

findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);
findMaxSequence(['happy']);
findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3'])
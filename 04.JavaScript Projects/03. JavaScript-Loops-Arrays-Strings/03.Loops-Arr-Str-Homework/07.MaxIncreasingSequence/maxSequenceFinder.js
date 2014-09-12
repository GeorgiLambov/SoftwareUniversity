function findMaxSequence(arr) {
    var currentSequence = 1;
    var longestSequence = 1;
    var indexOfLongest;
    var isSequence = false;

    for (var i = 0; i < arr.length; i++) {
        if (arr[i] < arr[i + 1]) {
            currentSequence++;
        } else {
            if (longestSequence < currentSequence) {
                longestSequence = currentSequence;
                indexOfLongest = i - currentSequence + 1;
                isSequence = true;
            }
            currentSequence = 1;
        }
    }

    if (isSequence) {
        var result = arr.slice(indexOfLongest, indexOfLongest + longestSequence);
        console.log(result);
    }
    else {
        console.log('no');
    }


}

findMaxSequence([3, 2, 3, 4, 2, 2, 4]);
findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]);
findMaxSequence([3, 2, 1]);
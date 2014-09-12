function sortArray(arr) {
    
    for (var i = 0; i < arr.length; i++) {
        var currMin = i;
        for (var j = i + 1; j < arr.length; j++) {
            if (arr[currMin] > arr[j]) {
                currMin = j;
            }
        }
        var temp = arr[i];
        arr[i] = arr[currMin];
        arr[currMin] = temp;
    }
    console.log(arr.join(", "));
    
}

sortArray([5, 4, 3, 2, 1]);
sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]);
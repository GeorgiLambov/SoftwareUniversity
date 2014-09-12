(function () {

    function biggerThanNeighbors(index, arr) {
        if (!arr[index]) {
            return 'invalid index';
        }
        if (index === 0 || index === arr.length - 1) {
            return 'only one neighbor';
        }
        if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1]) {
            return 'bigger';
        } else {
            return 'not bigger';
        }
    }
    console.log(biggerThanNeighbors(2, [1, 2, 3, 3, 5]));
    console.log(biggerThanNeighbors(2, [1, 2, 5, 3, 4]));
    console.log(biggerThanNeighbors(5, [1, 2, 5, 3, 4]));
    console.log(biggerThanNeighbors(5, [1, 2, 5, 3, 4]));
}());





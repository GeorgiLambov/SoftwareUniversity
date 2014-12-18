function Solve(params) {
    var N = parseInt(params[0]);
    
    var numbers = [];
    var answer = 0;
    
    for (var i = 0; i < N; i++) {
        numbers[i] = parseInt(params[i + 1]);
    }
    
    for (var i = 1; i < N; i++) {
        if (numbers[i - 1] > numbers[i]) {    // ako pred e po goliamo pochva nova redica!
            answer++;
        }
        if ((i == N - 1)) {
            answer++;
        }
    }
    //console.log(answer);
    return answer;
}


Solve([7, 1, 2, -3, 4, 4, 0, 1]);
Solve([6, 1, 3, -5, 8, 7, -6]);
//Solve([9, 1, 8, 8, 7, 6, 5, 7, 7, 6]);
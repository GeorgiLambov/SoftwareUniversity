function solve(input) {
    //we get the input and split to array of numbers
    var nums = input[0].split(/[ ()]+/);
    nums = nums.filter(function(v){return v!==''});
//  console.log(nums.join(' '));

    //find the longest alternating sequence
    var maxLength = 0;
    var currLength = 0;
    var oddRule = nums[0] % 2 != 0; //if true number is odd
    for (var i = 0; i < nums.length; i++) {
        var isOdd = nums[i] % 2 != 0; //if true number is odd
        if(isOdd == oddRule || nums[i] == 0) {
            currLength++;
        } else {
            oddRule = isOdd;
            currLength = 1;
        }
        oddRule = !oddRule;
        if (currLength > maxLength) {
            maxLength = currLength;
        }
    }
    console.log(maxLength);
}

//when you submit the code into the Judge system, do not copy the code below!
solve(['(102)(103)(0)(105)  (107)(1)']);

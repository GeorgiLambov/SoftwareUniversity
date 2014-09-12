function findLargestBySumOfDigits(nums) {
    if (arguments.length < 1) {
        console.log(undefined);
    } else {
        var digitMaxSum = 0;
        var result;
        for (var i = 0; i < nums.length; i++) {
            var digit = nums[i];
            var sum = 0;
            if (digit < 0) {
                digit = digit * -1;
            }
            if (parseInt(nums[i]) !== nums[i]) {
                // if 3 !== 3.3
                result = undefined;
            } else {
                
                while (digit > 0) {
                    sum = sum + (digit % 10);
                    digit = Math.floor(digit / 10);
                }
                if (sum > digitMaxSum) {
                    digitMaxSum = sum;
                    result = nums[i];
                }
            }

        }
        console.log(result);
    }
}
findLargestBySumOfDigits([5, 10, 15, 111]);
findLargestBySumOfDigits([33, 44, -99, 0, 20]);
findLargestBySumOfDigits(['hello']);
findLargestBySumOfDigits([5, 3.3]);
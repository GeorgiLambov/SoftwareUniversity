function isPrime(num) {
    for (var i = 2; i < Math.sqrt(num) ; i++) {
        if (num % i == 0) {
            return false;
        }
        return true;
    }
}
console.log(isPrime(7));
console.log(isPrime(254));
console.log(isPrime(587));
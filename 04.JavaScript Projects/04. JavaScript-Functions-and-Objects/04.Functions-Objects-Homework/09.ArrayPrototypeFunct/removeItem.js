Array.prototype.removeItem = function (value) {
    while (this.indexOf(value) >= 0) {
        this.splice(this.indexOf(value), 1);
    }
    console.log(this);
    return this;
};
var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
arr.removeItem(1);

var arr1 = ['hi', 'bye', 'hello' ];
arr1.removeItem('bye');
'use strict';

function printArgs() {
    console.log('Number of arguments in %s() is %d.', printArgs.name, arguments.length);
    
    // Convert arguments to Array
    var args = Array.prototype.slice.call(arguments);
    // or [].slice.call(arguments)
    args.forEach(function (arg) { console.log('Argument: %s is %s.', arg, typeof arg); });
}

printArgs();
printArgs(1, "siso");
printArgs([2, 3, 4, 5, 7]);
printArgs(true);

var specialConsole = (function () {
    function write(method, args) {
        var result = args[0];
        
        if (args && args.length > 1) {
            for (var i = 1; i < args.length; i += 1) {
                var regEx = new RegExp('\\{' + (i - 1) + '\\}', 'gi');
                result = result.replace(regEx, args[i]);
            }
        }
        
        console[method](result.toString());
    }
    
    return {
        writeLine: function () {
            write('log', arguments);
        },
        
        writeError: function () {
            write('error', arguments);
        },
        
        writeWarning: function () {
            write('warn', arguments);
        },
    };
}());

specialConsole.writeLine("Message: hello");
specialConsole.writeLine("Message: {0}", "hello");
specialConsole.writeError("Error: {0}", "A fatal error has occurred.");
specialConsole.writeWarning("Warning: {0}", "You are not allowed to do that!");

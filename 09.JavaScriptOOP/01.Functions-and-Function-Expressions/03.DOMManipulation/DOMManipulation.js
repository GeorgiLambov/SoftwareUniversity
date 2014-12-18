var domModule = (function dom() {
    // simple 'shiv' for unsupported querrySelector
    if (!document.querySelector) {
        var script = document.createElement('script');
        script.src = 'http://code.jquery.com/jquery-2.1.1.min.js';
        document.body.appendChild(script);
        
        document.querySelector = querrySelectorWithJQuery;
        document.querySelectorAll = querrySelectorWithJQuery;
        
        function querrySelectorWithJQuery(querry) {
            return $(querry);
        }
    }
    
    var allHolders = {};
    
    function appendChild(elementToAppend, parentQuerrySelector) {
        document.querySelector(parentQuerrySelector).appendChild(elementToAppend);
    }
    
    function removeChild(parentElementQuerrySelector, childElementQuerrySelector) {
        document.querySelector(parentElementQuerrySelector).removeChild(childElementQuerrySelector);
    }
    
    function addHandler(elementQuerrySelector, eventType, eventHandler) {
        var selected = document.querySelectorAll(elementQuerrySelector);
        
        for (var i = 0, len = selected.length; i < len; i += 1) {
            selected[i].addEventListener(eventType, eventHandler);
        }
    }
    
    function appendToBuffer(parentQuerrySelector, elementToAppend) {
        var parent = document.querySelector(parentQuerrySelector);
        
        if (!allHolders[parent]) {
            allHolders[parent] = [];
        }
        
        allHolders[parent].push(elementToAppend);
        
        if (allHolders[parent].length >= 100) {
            var frag = document.createDocumentFragment();
            
            for (var i = 0, len = allHolders[parent].length; i < len; i += 1) {
                frag.appendChild(allHolders[parent][i]);
            }
            
            allHolders[parent] = [];
            
            parent.appendChild(frag);
        }
    }
    
    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
    };
}());


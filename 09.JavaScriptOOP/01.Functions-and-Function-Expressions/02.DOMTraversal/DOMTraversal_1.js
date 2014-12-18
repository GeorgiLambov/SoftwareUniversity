function traverse(selector) {
    'use strict';
    
    var element = document.querySelector(selector);
    traverseElement(element, '');
    
    function traverseElement(element, spacing) {
        var len, child, elementAsString;
        spacing = spacing || "    ";
        
        elementAsString = spacing + element.nodeName.toLowerCase() + ':';
        
        if (element.hasAttribute('id')) {
            elementAsString += ' id="' + element.id;
        }
        if (element.hasAttribute('class')) {
            elementAsString += ' class="' + element.className + '"';
        }
        
        console.log(elementAsString);
        
        [].forEach.call(element.childNodes, function (child) {
            if (child.nodeType === 1) {
                traverseElement(child, spacing + "    ");
            }
        });
    }
}

var selector = ".birds";
traverse(selector);
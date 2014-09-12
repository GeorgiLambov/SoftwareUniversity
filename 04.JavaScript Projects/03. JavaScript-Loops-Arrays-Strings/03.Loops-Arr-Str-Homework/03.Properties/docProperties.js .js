function displayProperties(value) {
    var properties = [];
    for (var prop in value) {
        properties.push(prop);
    }
    properties.sort();
    for (var i = 0; i < properties.length; i++) {
        console.log(properties[i]);
    }
    
}

displayProperties(document);
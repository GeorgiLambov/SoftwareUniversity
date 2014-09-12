function extractContent(input) {
    var re = />[^><]+</g,
        matchs = input.match(re),
        result = '';
    
    for (var i in matchs) {
        result += matchs[i].replace(/[<>\s]/g, '');
    }
    console.log(result)



}
extractContent('<p>Hello</p><a href="http://w3c.org">W3C</a>');
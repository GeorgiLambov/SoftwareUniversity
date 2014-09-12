function countDivs(html) { 
    var reg = /<div[\w\W\n]/g;
    var str = html.match(reg);
    var result = str.length;
    console.log(result);

}
countDivs('<!DOCTYPE html>' +
                        '<html>' +
                        '<head lang="en">' +
                            '<meta charset="UTF-8">' +
                                '<title>index</title>' +
                                '<script src="/yourScript.js" defer></script>' +
                            '</head>' +
                            '<body>' +
                                '<div id="outerDiv">' +
                                   '<div' +
                                    'class="first">' +
                                       '<div><div>hello</div></div>' +
                                    '</div>' +
                                    '<div>hi<div></div></div>' +
                                    '<div>I am a div</div>' +
                                '</div>' +
                            '</body>' +
                        '</html>');
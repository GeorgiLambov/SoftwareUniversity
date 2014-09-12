function replaceATag(input) { 
    var re = /<a([\w\W]*)>([\w\W]*)<\/a>/gi;
    var result = input.replace(re, '[URL $1]$2[/URL]');
    console.log(result);
}
replaceATag("<ul>\n     <li>\n   <a href=http://softuni.bg>SoftUni</a>\n    </li>\n</ul>");
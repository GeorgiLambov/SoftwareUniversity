function fixCasing(inputString) {
    inputString = inputString.replace(/<\w+>([^<>]+)<\/\w+>/g, changeText);
    console.log(inputString);

    function mixcase(str) {
        var strAsArray = [],
            i;

        for (i in str) {
            if (Math.round(Math.random())) {
                strAsArray.push(str[i].toUpperCase());
            } else {
                strAsArray.push(str[i].toLowerCase());
            }
        }

        return strAsArray.join('');
    }

    function changeText(match) {

        var myRegexp = /<(\w+)>([\W\w]+)<\/\w+>/g,
            content = myRegexp.exec(match);

        switch (content[1]) {
            case 'upcase':
                content[2] = content[2].toUpperCase();
                break;
            case 'lowcase':
                content[2] = content[2].toLowerCase();
                break;
            case 'mixcase':
                content[2] = mixcase(content[2]);
                break;
        }

        return content[2];
    }

    
}
fixCasing("We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>ANYTHING</lowcase> else.");
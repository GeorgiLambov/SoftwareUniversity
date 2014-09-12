function findMostFreqWord(str) {
    str = str.toLowerCase();
    str = str.match(/\b\w+/g);
    
    var obj = {};
    var keyMaxCount = 0;
    var bestWords = [];
    
    
    for (var i = 0; i < str.length; i++) {
        var word = str[i];
        
        if (!(word in obj)) {
            obj[word] = 1;
        } else {
            obj[word] += 1;
        }
        if (obj[word] > keyMaxCount) {
            keyMaxCount = obj[word];
        }
    }
    // check best words
    for (var key in obj) {
        if (obj[key] === keyMaxCount) {
            bestWords.push({ word: key, times: keyMaxCount });
        }
    }
    // alphabetical order word/key!!!     pri map[0-9][word.neshto si]                                           http://stackoverflow.com/questions/6712034/sort-array-by-firstname-alphabetically-in-javascript
    bestWords.sort(
    function (a, b) {
        return a.word.localeCompare(b.word);
    });
    
    //print the result
    for (var key in bestWords) {
        console.log(bestWords[key].word + " -> " + bestWords[key].times + " times");
    }

}


//findMostFreqWord('in the middle of the night.');
//findMostFreqWord('Welcome to SoftUni. Welcome to Java. Welcome everyone.');
findMostFreqWord('Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.');
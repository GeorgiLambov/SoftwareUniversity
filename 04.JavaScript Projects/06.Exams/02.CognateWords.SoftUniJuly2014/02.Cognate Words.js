function Solve(input) {
    var text = input[0];
    var words = text.split(/[^A-Za-z]+/);
    words = words.filter(Boolean);         // ako ima praznen element go maha
    var isAnsewr = false;
    var result = [];
    for (var i = 0; i < words.length; i++) {
        for (var j = 0; j < words.length; j++) {
            for (var f = 0; f < words.length; f++) {
                var a = words[i];
                var b = words[j];
                var c = words[f];
                if (i !== j) {
                    if (a + b === c) {
                        var cognateWord = a + '|' + b + '=' + c;
                        if (result.indexOf(cognateWord) < 0) {
                            result.push(cognateWord);
                            isAnsewr = true;
                        }
                    }
                }
            }
        }
    }
    if (!isAnsewr) {
        console.log("No");
       
    } else {
        console.log(result.join('\n'));
    }

}

//Solve(["java..?|basics/*-+=javabasics"]);
//Solve("Hi, Hi, Hihi");
Solve(["Uni(lo,.ve=I love SoftUni (Soft)"]);
//Solve("a a aa a");
//Solve('x a ab b aba a hello+java a b aaaaa');
//Solve("aa bb bbaa");
//Solve("ho hoho");
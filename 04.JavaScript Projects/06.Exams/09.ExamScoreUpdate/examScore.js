function Solve(args) {

    var map = {};

    for (var i = 0; i < args.length; i++) {
        //starting from 3 to avoid the header, ending at -1 to avoid bottom-border


        var inputHolder = args[i].split(/[^a-zA-Z0-9.]+/);
        inputHolder = inputHolder.filter(function (n)
        { return n != '' });                   // removing empty array elements

        var score = inputHolder[2];
        var name = inputHolder[0] + " " + inputHolder[1];
        var grade = parseFloat(inputHolder[3]);

        if (!(score in map)) {
            // ako lipsva takav key (v slu4aq score na studenta e kluch za mapa) dobavqme i inicializirame

            map[score] = [grade, []];
            map[score][1].push(name); // map[score][1] e array s imenata
        }
        else {
            // ako ima takav klu4 trbva kum dosegashnata suma da dobavim ocenkata za da smetnem average posle

            map[score][0] += grade; // obnovqvame ocenkata
            if (map[score][1].indexOf(name) == -1) {
                map[score][1].push(name); //dobavqme imeto
            }
        }
    }

    for (var key in map) {
        // minavame prez vsi4ki keys ot mapa
        map[key][1].sort();   // sortirame arrays s imenata
        var result = key + " -> " + map[key][1].join(", ") + "; avg=" + (map[key][0] / map[key][1].length).toFixed(2);
        // ^^ iz4islqvame average kato razdelim sbora ot si4ki ocenki na razmera na array s imena , do 2 mesta sled to4kata
        console.log(result);
    }

}
Solve(["| George Ivanov       | 306        | 5.26  |",
"| George Stefanov     | 120        | 3.12  |",
"| Petya Koleva        | 400        | 6.00  |",
"| Aleksandar Stoyanov | 300        | 5.00  |",
"| Diana Kirova        | 120        | 3.23  |",
"| Ivan Ivanov         | 0          | 2.00  |",
"| Kalin Petrov        | 300        | 5.40  |",
"| Stoyan Kotsev       | 400        | 5.00  |",
"| Krasimir Mihaylov   | 400        | 5.98  |"]);
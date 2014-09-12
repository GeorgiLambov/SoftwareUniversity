function countSubstringOccur(arr) {
    var keyword = arr[0];
    var text = arr[1];
    var count = 0;
    var pos;
    text = text.toLowerCase();
    do {
        var substr = text.indexOf(keyword, pos);
        if (substr == -1) {
            break;
        }
        pos = substr;
        pos++;
        count++;
    } while ((substr != -1) && (pos <= text.length));
    console.log(count);

}
countSubstringOccur(["in", "We are living in a yellow submarine. We do't have anything else.Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days."]);
countSubstringOccur(["your", "No one heard a single word you said. They should have seen it in your eyes. What was going around your head."]);
countSubstringOccur(["but", "But you were living in another world tryin' to get your message through."]);
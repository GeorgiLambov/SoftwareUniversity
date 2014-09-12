<?php
$text = $_GET['text'];
$bl = $_GET['blacklist'];

$blacklist = preg_split("/\s/", $bl, -1, PREG_SPLIT_NO_EMPTY); // make arr from textarea
$pattern = "/[a-zA-Z0-9_+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+/";
preg_match_all($pattern, $text, $matches);
foreach ($matches[0] as $match) {
    $replacement = getReplacement($match, $blacklist);
    $text = str_replace($match, $replacement, $text);
}
echo "<p>$text</p>";
function getReplacement($match, $blacklist)
{
    preg_match("/(\..*)/", $match, $domain);
    $dom = '*' . $domain[0];
    if (in_array($dom, $blacklist) || in_array($match, $blacklist)) {
        return str_pad('', strlen($match), '*');
    } else {
        return "<a href=\"mailto:" . $match . "\">$match</a>";
    }
}

?>
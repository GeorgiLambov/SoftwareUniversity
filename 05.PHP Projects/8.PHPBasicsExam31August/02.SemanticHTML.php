<?php
$inputString = $_GET['html'];

$lineAll = preg_split("/\r?\n/", $inputString, -1, PREG_SPLIT_NO_EMPTY);
$result = [];


for ($i = 0; $i < count($lineAll); $i++) {
    $line = $lineAll[$i];
    $line = isOldTags($line);
    $line = isOldTagsEnd($line);
    echo $line . "\n";

}


function isOldTags($line)
{
    $tagsArr = ['main', 'header', 'nav', 'article', 'section', 'aside', 'footer'];


    foreach ($tagsArr as $tag) {
        $id = 'id';
        $pattern = '/<div\s*(.*?)\s*(' . $id . '\s*=\s*"\s*' . $tag . '\s*")\s*(.*?)\s*>/';
        preg_match_all($pattern, $line, $match);
        if (isset($match[2][0])) {
            $line = '<' . $tag;
            if ($match[1][0] != "") {
                $line = $line . " " . $match[1][0];
            }
            if ($match[3][0] != "") {
                $line = $line . " " . $match[3][0];
            }
            $line = $line . ">";
            break;
        } else {
            $id = 'class';
            $pattern = '/<div\s*(.*?)(' . $id . '\s*=\s*"\s*' . $tag . '\s*")\s*(.*?)\s*>/';
            preg_match_all($pattern, $line, $match);
            if (isset($match[2][0])) {
                $line = '<' . $tag;
                if ($match[1][0] != "") {
                    $line = $line . " " . $match[1][0];
                }
                if ($match[3][0] != "") {
                    $line = $line . " " . $match[3][0];
                }
                $line = $line . ">";
                break;
            }
        }
    }
    return $line;
}


function isOldTagsEnd($line)
{
    $tagsArr = ['main', 'header', 'nav', 'article', 'section', 'aside', 'footer'];
    foreach ($tagsArr as $tag) {
        $pattern = "/<\/div>\s*<!--\s*(" . $tag . ")\s*-->/";
        preg_match_all($pattern, $line, $match);
        if (isset($match[1][0])) {
            $line = "<" . "/" . $tag . ">";
            break;
        }
    }
    return $line;


}
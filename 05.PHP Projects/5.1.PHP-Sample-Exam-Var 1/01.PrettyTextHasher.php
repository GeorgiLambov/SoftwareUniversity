<?php
$inputString = $_GET['text'];
preg_match_all('/[\w\W]/', $inputString, $chars, PREG_SPLIT_NO_EMPTY);
$hashValue = $_GET['hashValue'];
$fontSize = $_GET['fontSize'];
$style = $_GET['fontStyle'];
$result = '';

for ($i = 0; $i < count($chars[0]); $i++) {
    $currentChar = $chars[0][$i];
    if ($currentChar != '') {
        if ($i % 2 == 0) {
            $result .= chr(ord($currentChar) + intval($hashValue));
        } else {
            $result .= chr(ord($currentChar) - intval($hashValue));
        }
    }
}
if ($style == "bold") {
    $style = "font-weight:" . $style;
} else {
    $style = "font-style:" . $style;
}

echo "<p style=\"font-size:$fontSize;$style;\">$result</p>";

?>
<?php
$text = $_GET['text'];
$keyString = $_GET['key'];

$key = array();

$key[0] = $keyString[0];
$firstChar = $keyString[0];
if (!ctype_alpha($firstChar) && !ctype_digit($firstChar)) { // proverka dali sa bukvi
    $key[0] = '\\' . $key[0];
}

for ($i = 1; $i < strlen($keyString) - 1; $i++) { //pravime patern za Key

    if (ctype_digit($keyString[$i])) { //proverka dali sa cifri v string
        $key[$i] = '\d*';
    } elseif (ctype_upper($keyString[$i])) {
        $key[$i] = '[A-Z]*';
    } elseif (ctype_lower($keyString[$i])) {
        $key[$i] = '[a-z]*';
    } else {
        $key[$i] = '\\' . $keyString[$i];
    }
}

$key[strlen($keyString) - 1] = $keyString[strlen($keyString) - 1]; //slagame poslednata poxziciq
$lastChar = $keyString[strlen($keyString) - 1];
if (!ctype_alpha($lastChar) && !ctype_digit($lastChar)) {
    $key[strlen($keyString) - 1] = '\\' . $key[strlen($keyString) - 1];
}

$key = implode('', $key);

$pattern = '/' . $key . '(.{2,6})' . $key . '/';

preg_match_all($pattern, $text, $matches);

$address = implode('', $matches[1]);

echo $address;
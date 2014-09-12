<?php
$inputString = $_GET["text"];
//$wordArr = preg_split("/[\s\W\d]+/", $inputString, -1, PREG_SPLIT_NO_EMPTY);
$str = $inputString;
$resultStr = '';
$word = "";
while (strlen($str) > 0) {
    preg_match('/([a-zA-Z]+)|([\s\W\d]*)/', $str, $match);

    $word = $match[1];
    $separator = $match[2];
    $count = strlen($word);
    $word = isUpperCase($word);
    $resultStr .= $word . $separator;
    $count += strlen($separator);

    $str = substr($str, $count, strlen($inputString));

}
echo "<p>" . htmlspecialchars($resultStr) . "</p>";

function isUpperCase($word)
{
    if (strtoupper($word) == $word) {
        $word = strrev($word);

        if (getPalindrome($word)) {
            $doubleCharWord = '';
            for ($i = 0; $i < strlen($word); $i++) {
                $currentChar = $word[$i];
                $doubleCharWord .= $currentChar . $currentChar;
            }
            return $doubleCharWord;
        }

    }
    return $word;
}

function getPalindrome($str)
{
    if ((strlen($str) == 1) || (strlen($str) == 0)) {
        return true;
    } else {
        if (substr($str, 0, 1) == substr($str, (strlen($str) - 1), 1)) {
            return getPalindrome(substr($str, 1, strlen($str) - 2));
        } else {
            return false;
        }
    }
}
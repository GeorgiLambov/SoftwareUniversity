<?php

function getRow($rowStr)
{
    preg_match('/\d+/', $rowStr, $matches);
    return $matches[0] - 1;
}

function getCrossPoints($word1, $word2)
{
    $points = array();
    $point = array();
    for ($i = 0; $i < strlen($word1); $i++) {
        for ($j = 0; $j < strlen($word2); $j++) {
            if ($word1[$i] == $word2[$j]) {
                $point[0] = $i;
                $point[1] = $j;
                $points[] = $point;
            }
        }
    }

    return $points;
}

function compareLength($str1, $str2)           //sravniava dumi po dulvinatat im
{
    return strlen($str2) - strlen($str1);
}


$input1 = $_GET['mainWord'];
$input2 = $_GET['words'];
$word1 = (array)json_decode($input1);
$words = json_decode($input2);

$rowMainWord = getRow(key($word1));
$mainWord = $word1[key($word1)];
$sizeTable = strlen($mainWord);

//create board consists only horizontal word.
$board = array();
$row = array_fill(0, strlen($mainWord), '');

for ($col = 0; $col < strlen($mainWord); $col++) {
    if ($rowMainWord == $col) {
        $board[] = str_split($mainWord);
    } else {
        $board[] = $row;
    }
}

usort($words, 'compareLength');

foreach ($words as $word) {
    $crossPoints = getCrossPoints($mainWord, $word);

    if (empty($crossPoints)) {
        continue;
    }

    $isBreak = false;

    foreach ($crossPoints as $crossPoint) {
        $upRows = $rowMainWord;        // duljinata na redovete nad dumata
        $downRows = $sizeTable - $upRows - 1;         // duljinata na redovete pod dumata
        $topLength = $crossPoint[1];                 //preseechnata tochka po redove
        $bottomLength = strlen($word) - $topLength - 1;  //presechnatata tochka po koloni

        if ($upRows >= $topLength && $downRows >= $bottomLength) {
            $isBreak = true;
            break;
        }
    }

    if ($isBreak) {
        $choiceWord = $word;
        break;
    }
}

$wordList = array_count_values($words);   // prebroiavane na klucove v  arr

if (isset($choiceWord)) {

    $colVerticalWorld = $crossPoint[0];
    $starPosVertical = $rowMainWord - $topLength;
    $endPosVertical = $rowMainWord + $bottomLength;
    $wordIndex = 0;

    for ($row = 0; $row <= $sizeTable; $row++) {
        if ($starPosVertical <= $row && $row <= $endPosVertical) {
            $board[$row][$colVerticalWorld] = $choiceWord[$wordIndex];
            $wordIndex++;
        }
    }

    unset($wordList[$choiceWord]);
}

$result = array();
ksort($wordList);

foreach ($wordList as $word => $value) {
    $result[htmlspecialchars($word)] = sumAsciiCodes($word, $value);
}

echo "<table>";
for ($i = 0; $i < $sizeTable; $i++) {
    echo "<tr>";

    for ($j = 0; $j < $sizeTable; $j++) {
        echo "<td>{$board[$i][$j]}</td>";
    }

    echo "</tr>";
}
echo "</table>";
echo json_encode($result);


function sumAsciiCodes($word, $count)
{
    $sum = 0;
    for ($i = 0; $i < strlen($word); $i++) {
        $sum += ord($word[$i]) * $count;
    }

    return $sum;
}


?>
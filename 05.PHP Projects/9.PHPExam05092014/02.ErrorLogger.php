<?php
$inputText = $_GET['errorLog'];

$pattern = "/\.([A-Za-z]+Exception):.*\n.*?\.(.*?)\((.*?):(\d+)/";
preg_match_all($pattern, $inputText, $allLines);

$result = "<ul>";
for ($i = 0; $i < count($allLines[0]); $i++) {
    $line = htmlspecialchars($allLines[4][$i]);
    $exception = htmlspecialchars($allLines[1][$i]);
    $method = htmlspecialchars($allLines[2][$i]);
    $fileName = htmlspecialchars($allLines[3][$i]);

    $result .= "<li>line <strong>$line</strong> - <strong>$exception</strong> in <em>$fileName:$method</em></li>";
}

$result .= "</ul>";
echo $result;
<?php
$inputString = $_GET['list'];
$maxSize = $_GET['maxSize'];

$lineAll = preg_split("/\r?\n/", $inputString, -1, PREG_SPLIT_NO_EMPTY);
$pattern = '/^\s*(.{0,' . $maxSize . '})/';

echo "<ul>";
for ($i = 0; $i < count($lineAll); $i++) {

    $line = trim($lineAll[$i]);
    preg_match_all($pattern, $line, $match);
    $item = $match[1][0];
    if (strlen($item) >= $maxSize) {
        $item = $item . "...";
    }

    echo "<li>" . htmlspecialchars($item) . "</li>";
}
echo "</ul>";
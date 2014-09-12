<?php
date_default_timezone_set("Europe/Sofia");
$inputString = $_GET['text'];
$pattern = "/^\s*([\w\s\-]+)\s*\%\s*([\w\s\.\-]+)\s*;\s*[\d]{2}\-([\d]{2})\-[\d]{4}\s*-\s*(.{0,100})/m";
preg_match_all($pattern, $inputString, $match);

for ($i = 0; $i < count($match[0]); $i++) {

    $articleName = trim($match[1][$i]);
    $authorsName = trim($match[2][$i]);
    $month = $match[3][$i];
    $monthName = date("F", mktime(0, 0, 0, $month, 10));
    $summary = trim($match[4][$i]);
    echo "<div>" . "\n";
    echo "<b>Topic:</b> <span>" . htmlspecialchars($articleName) . "</span>" . "\n";
    echo "<b>Author:</b> <span>" . htmlspecialchars($authorsName) . "</span>" . "\n";
    echo "<b>When:</b> <span>" . htmlspecialchars($monthName) . "</span>" . "\n";
    echo "<b>Summary:</b> <span>" . htmlspecialchars($summary) . "...</span>\n";
    echo "</div> " . "\n";
}
?>
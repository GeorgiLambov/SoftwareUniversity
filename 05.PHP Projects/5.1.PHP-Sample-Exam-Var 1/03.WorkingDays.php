<?php
date_default_timezone_set("Europe/Sofia");
// Read the input (GET)
$dateOne = strtotime($_GET['dateOne']);
$dateTwo = strtotime($_GET['dateTwo']);
$holidays = preg_split("/\s+/", $_GET['holidays'], -1, PREG_SPLIT_NO_EMPTY);

// Convert the date strings to date seconds (for comparison later)
foreach ($holidays as $key => $date) {
    $holidays[$key] = strtotime($date);
}

$currentDate = $dateOne;
$workdays = [];
while ($currentDate <= $dateTwo) {
    if (isWorkday($currentDate, $holidays)) {
        $workdays[] = $currentDate;
    }
    $currentDate = strtotime("+1 day", $currentDate);
}

if (count($workdays) == 0) {
    echo "<h2>No workdays</h2>";
} else {
    echo "<ol>";
    for ($i = 0; $i < count($workdays); $i++) {
        $date = date("d-m-Y", $workdays[$i]);
        echo "<li>$date</li>";
    }
    echo "</ol>";
}

function isWorkday($strToTime, $holidays) {
    $dayOfWeek = date("N", $strToTime);
    if ($dayOfWeek > 5 || in_array($strToTime, $holidays)) {
        return false;
    }
    return true;
}
?>
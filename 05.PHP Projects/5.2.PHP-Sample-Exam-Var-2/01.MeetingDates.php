<?php
date_default_timezone_set("Europe/Sofia");
// Read the input (GET)
$dateOne = strtotime($_GET['dateOne']);
$dateTwo = strtotime($_GET['dateTwo']);

$startDay = ($dateOne < $dateTwo) ? $dateOne : $dateTwo;
$endDay = ($startDay == $dateOne) ? $dateTwo : $dateOne;
$currentDate = $startDay;
$thursdays = [];

while ($currentDate <= $endDay) {
    $dayOfWeek = date('l', $currentDate);
    if ($dayOfWeek == 'Thursday') {
        $thursdays[] = $currentDate;
    }
    $currentDate = strtotime("+1 day", $currentDate);
}

if (count($thursdays) == 0) {
    echo "<h2>No Thursdays</h2>";
} else {
    $result="<ol>";

    for ($i = 0; $i < count($thursdays); $i++) {
        $date = date("d-m-Y", $thursdays[$i]);
        $result.="<li>$date</li>";
    }
   echo $result.="</ol>";
}
?>
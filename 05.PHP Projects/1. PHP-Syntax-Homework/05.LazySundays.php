<?php
$mount = date("F");
$year = date("Y");
$totalDays = date("t");
for ($i = 1; $i <= $totalDays; $i++) {
    $date = strtotime("$i $mount $year"); // convert string to date
    if (date('l', $date) === "Sunday") {
        echo date("jS F, Y", $date), "\n";
    }
}
?>
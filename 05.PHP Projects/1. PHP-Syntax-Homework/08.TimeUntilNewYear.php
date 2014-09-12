<?php
$now = getdate();
$start_date = new DateTime("$now[year]-$now[mon]-$now[mday] $now[hours]:$now[minutes]:$now[seconds]");
$since_start = $start_date->diff(new DateTime('2015-01-01 00:00:00'));

$totalHours = ($since_start->h) + ($since_start->days) * 24;
$totalMinutes = ($since_start->i) + $totalHours * 60;
$totalSeconds = ($since_start->s) + $totalMinutes * 60;
echo 'Hours until New Year: ' . $totalHours . '<br>';
echo 'Minutes until New Year: ' . $totalMinutes . '<br>';
echo 'Seconds until New Year: ' . $totalSeconds . '<br>';
printf('Days:Hours:Minutes:Seconds %d:%d:%d:%d', ($since_start->days), ($since_start->h), ($since_start->i), ($since_start->s));
?>
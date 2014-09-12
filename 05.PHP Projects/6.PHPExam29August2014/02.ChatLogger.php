<?php
date_default_timezone_set("Europe/Sofia");
$startDate = strtotime($_GET['currentDate']);
$input = $_GET['messages'];
preg_match_all("/[^\r\n]+/", $input, $match, PREG_SPLIT_NO_EMPTY);   //split line  "/\r?\n/"

$messagesArr = $match[0];
$resultArr = [];
for ($i = 0; $i < count($messagesArr); $i++) {
    $messageInfo = preg_split("/\s+\/\s+/", $messagesArr[$i], -1, PREG_SPLIT_NO_EMPTY);   // split po "/" escapnata
    $currentMessage = trim($messageInfo[0]);
    $currentDate = trim(strtotime($messageInfo[1]));
    $resultArr[$currentDate] = $currentMessage;
}
ksort($resultArr);
foreach ($resultArr as $key => $value) {
    echo "<div>" . htmlspecialchars($value) . "</div>" . "\n";
}

$mostResentDate = end(array_keys($resultArr));

//$date = date('d-m-Y H:i:s', $mostResentDate);
//echo $date;

//2 Years, 4 Days, 6 Hours and 8 Minutes
//$interval = new DateInterval('P2Y4DT6H8M');

//$date = new DateTime('2014-08-16');   class!!!
//$date->add(new DateInterval('P10D'));
//adds 10 days echo $date->format('Y-m-d') . "\n";


$timestamp = getTimeMark($startDate, $mostResentDate);
echo "<p>Last active: <time>$timestamp</time></p>";

function getTimeMark($startDate, $mostResentDate)
{
    $diff = abs($startDate - $mostResentDate);

    $years = floor($diff / (365 * 60 * 60 * 24));
    $months = floor(($diff - $years * 365 * 60 * 60 * 24) / (30 * 60 * 60 * 24));
    $days = floor(($diff - $years * 365 * 60 * 60 * 24 - $months * 30 * 60 * 60 * 24) / (60 * 60 * 24));

    $hours = floor(($diff - $years * 365 * 60 * 60 * 24 - $months * 30 * 60 * 60 * 24 - $days * 60 * 60 * 24) / (60 * 60));

    $minutes = floor(($diff - $years * 365 * 60 * 60 * 24 - $months * 30 * 60 * 60 * 24 - $days * 60 * 60 * 24 - $hours * 60 * 60) / 60);

    $seconds = floor(($diff - $years * 365 * 60 * 60 * 24 - $months * 30 * 60 * 60 * 24 - $days * 60 * 60 * 24 - $hours * 60 * 60 - $minutes * 60));


    $timeStamp = '';

    $lastDay = date('z', $mostResentDate); //z - The day of the year (from 0 through 365)
    $currentDay = date('z', $startDate);

    if ($lastDay == $currentDay) {
        if ($minutes < 1 && $hours == 0) {
            $timeStamp = "a few moments ago";
        } else if ($hours < 1) {
            $timeStamp = "$minutes minute(s) ago";
        } else if ($hours < 24) {
            $timeStamp = "$hours hour(s) ago";
        }
    } else if ($lastDay + 1 == $currentDay) {
        $timeStamp = "yesterday";
    } else {
        $timeStamp = date("d-m-Y", $mostResentDate);
    }

    return $timeStamp;

}
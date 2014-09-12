<?php
$recipient = $_GET['recipient'];
$subject = $_GET['subject'];
$message = $_GET['body'];
$key = $_GET['key'];
$formatEmailMessage = "<p class='recipient'>" . htmlspecialchars($recipient) . "</p><p class='subject'>" . htmlspecialchars($subject) . "</p><p class='message'>" . htmlspecialchars($message) . "</p>";

$result = [];
$counter = 0;
for ($i = 0; $i < strlen($formatEmailMessage); $i++) {
    $currentCharOrd = ord($formatEmailMessage[$i]);
    $keyCharOrd = ord($key[$counter]);
    $hex = dechex($currentCharOrd * $keyCharOrd);
    $result[] = $hex;
    $counter++;
    if ($counter == strlen($key)) {
        $counter = 0;
    }
}
$result = join("|", $result);
echo "|" . $result . "|";

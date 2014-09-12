<?php
$inputText = $_GET['text'];
$red = intval($_GET['red']);
$green = intval($_GET['green']);
$blue = intval($_GET['blue']);
$nth = intval($_GET['nth']);

$red = getHexde($red);
$green = getHexde($green);
$blue = getHexde($blue);
function getHexde($value)
{
    if ($value <= 15) {
        $value = strtolower(dechex($value));
        $value = "0" . $value;
    } else {
        $value = strtolower(dechex($value));
    }
    return $value;
}

$colour = $red . $green . $blue;
$inputArr = str_split($inputText, 1);
echo "<p>";

for ($i = 0; $i < count($inputArr); $i++) {
    if (($i + 1) % $nth == 0) {
        echo "<span style=\"color: #" . htmlspecialchars($colour) . "\">" . htmlspecialchars($inputArr[$i]) . "</span>";
    } else {
        echo htmlspecialchars($inputArr[$i]);
    }
}
echo "</p>";


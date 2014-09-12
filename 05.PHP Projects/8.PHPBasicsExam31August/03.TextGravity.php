<?php
$inputString = $_GET['text'];
$lineLength = $_GET['lineLength'];

for ($row = 0, $startIndex = 0; $startIndex < strlen($inputString); $row++, $startIndex += $lineLength) {

    for ($col = 0; $col < $lineLength; $col++) {
        if ($startIndex + $col < strlen($inputString)) {
            $matrix[$row][$col] = $inputString[$startIndex + $col];
        } else {
            $matrix[$row][$col] = " ";
        }
    }
}
for ($row = count($matrix) - 1; $row >= 0; $row--) {

    for ($col = count($matrix[$row]) - 1; $col >= 0; $col--) {

        if ($matrix[$row][$col] == " ") {

            for ($counter = 0; $row - $counter >= 0; $counter++) {
                if ($matrix[$row - $counter][$col] != " ") {
                    $matrix[$row][$col] = $matrix[$row - $counter][$col];
                    $matrix[$row - $counter][$col] = " ";
                    break;
                }
            }
        }
    }
}
echo "<table>";
for ($row = 0; $row < count($matrix); $row++) {
    echo "<tr>";
    for ($col = 0; $col < count($matrix[$row]); $col++) {
        echo "<td>" . htmlentities($matrix[$row][$col]) . "</td>";
    }
    echo "</tr>";
}
echo "<table>";

<?php
$text = $_GET['text'];
$minFontSize = intval($_GET['minFontSize']);
$maxFontSize = intval($_GET['maxFontSize']);
$step = intval($_GET['step']);
$currentStep = $minFontSize;
$stroke = "text-decoration:line-through;";
$isIncrement = true;
for ($i = 0; $i < strlen($text); $i++) {
    $currentChar = $text[$i];

    if (ord($currentChar) % 2 == 0) {
        echo "<span style='font-size:$currentStep;$stroke'>" . htmlspecialchars($currentChar) . "</span>";
    } else {
        echo "<span style='font-size:$currentStep;'>" . htmlspecialchars($currentChar) . "</span>";
    }
    if (ctype_alpha($currentChar)) {
        if ($isIncrement) {
            $currentStep += $step;

        } else {
            $currentStep -= $step;
        }
        if ($currentStep >= $maxFontSize) {
            $isIncrement = false;
        } elseif ($currentStep <= $minFontSize) {
            $isIncrement = true;
        }

    }
}

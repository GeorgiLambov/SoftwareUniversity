<?php
function NonRepeatDigits($num)
{
    $arr = array();
    for ($i = 100; $i <= $num; $i++) {
        if ($i > 999) {
            break;
        }
        $numberStr = strval($i);
        $chec = ($numberStr[0] != $numberStr[1] && $numberStr[0] != $numberStr[2] && $numberStr[2] != $numberStr[1]);
        if ($chec) {
            $arr[] = $i;
        }
    }
    if (count($arr) === 0) {
        echo 'no', "\n";
    } else {
        echo implode(", ", $arr), "\n";
    }
}

NonRepeatDigits(1234);
NonRepeatDigits(145);
NonRepeatDigits(15);
NonRepeatDigits(247);

?>
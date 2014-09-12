<?php

$name = "Ana Ivanova";//$_GET['name'];
$gender = "female";//$_GET['gender'];
$pin = "9912164756";//$_GET['pin'];

$nameArr = explode(" ", $name);

if (count($nameArr) != 2) {
    die("<h2>Incorrect data</h2>");
} else {
    $fName = $nameArr[0];
    $lName = $nameArr[1];
    if (!(ctype_upper($fName{0}) && ctype_upper($lName{0}))) {
        die("<h2>Incorrect data</h2>");
    }

}

function isValidPin($pin)
{
    $checksumDigit = intval(substr($pin, -1));
    $digitsArray = str_split($pin, 1);
    if (count($digitsArray) != 10) {
        die("<h2>Incorrect data</h2>");
    }

    $year = substr($pin, 0, 2);
    $mount = substr($pin, 2, 2);
    $day = substr($pin, 4, 2);
    if ((($mount - 40) <= 12) && ($mount - 40 > 0)) {
        $year = '20' . $year;
        $mount = $mount - 40;
    } else if ((($mount - 20) <= 12) && ($mount - 20 > 0)) {
        $year = '18' . $year;
        $mount = $mount - 20;
    } else {
        $year = '19' . $year;
    }
    if (!checkdate($mount, $day, $year)) {
        die("<h2>Incorrect data</h2>");
    }
    $sum = 0;
    for ($i = 0; $i < 10; $i++) {

        $element = (int)$digitsArray[$i];
        switch ($i) {
            case 0:
                $sum += $element * 2;
                break;
            case 1:
                $sum += $element * 4;
                break;
            case 2:
                $sum += $element * 8;
                break;
            case 3:
                $sum += $element * 5;
                break;
            case 4:
                $sum += $element * 10;
                break;
            case 5:
                $sum += $element * 9;
                break;
            case 6:
                $sum += $element * 7;
                break;
            case 7:
                $sum += $element * 3;
                break;
            case 8:
                $sum += $element * 6;
                break;

        }

    }
    $remainder = $sum % 11;
    if ($remainder == 10) {
        $remainder = 0;
        if (!($remainder == $checksumDigit)) {
            die("<h2>Incorrect data</h2>");
        }
    } else {
        if (!($remainder == $checksumDigit)) {
            die("<h2>Incorrect data</h2>");
        }
    }


}

function isCorrectGender($gender, $pin)
{
    $genderDigit = substr($pin, -2, 1);
    if ($genderDigit % 2 == 0 && $gender == 'male') {
        return true;
    } else if ($genderDigit % 2 == 1 && $gender == 'female') {
        return true;
    }
    return false;
}

if (!isCorrectGender($gender, $pin)) {
    die("<h2>Incorrect data</h2>");
};
isValidPin($pin);
$obj = (object)['name' => $name, 'gender' => $gender, "pin" => $pin];
//$output = [
//    "name" => $name,
//    "gender" => $genderString,
//    "pin" => $pin
//];
echo json_encode($obj);

?>

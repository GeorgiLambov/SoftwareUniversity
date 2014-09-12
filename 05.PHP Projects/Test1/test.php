<?php
$inputString = 'Warning: Our encryption is unbreakable and you will not be able to decrypt your information!';
//$chars = preg_split('//', $inputString, -1, PREG_SPLIT_NO_EMPTY);
preg_match_all('/[\w\W]/', $inputString, $chars, PREG_SPLIT_NO_EMPTY);
$hashValue = 1;
$fontSize = 30;
$style = 'bold';
$result = '';

for ($i = 0; $i < count($chars[0]); $i++) {
    $currentChar = $chars[0][$i];
    if ($currentChar != '') {
        if ($i % 2 == 0) {
            $result .= chr(ord($currentChar) + 1);
        } else {
            $result .= chr(ord($currentChar) - 1);
        }
    }

}
echo "<p style=\"font-size:$fontSize;font-weight:$style;\">$result</p>";
?>

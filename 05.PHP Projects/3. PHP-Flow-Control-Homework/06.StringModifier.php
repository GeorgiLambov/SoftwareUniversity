<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Modify String</title>
</head>
<body>
<form method="post" action="06.StringModifier.php">
    <input type="text" name="input"/>
    <input type="radio" name="modifies" id="palindrome" value="palindrome"/>
    <label for="palindrome">Check Palindrome </label>
    <input type="radio" name="modifies" id="reverse" value="reverse"/>
    <label for="reverse">Reverse String</label>
    <input type="radio" name="modifies" id="split" value="split"/>
    <label for="split">Split</label>
    <input type="radio" name="modifies" id="hash" value="hash"/>
    <label for="hash">Hash String</label>
    <input type="radio" name="modifies" id="shuffle" value="shuffle"/>
    <label for="shuffle">Shuffle String</label>
    <input type="submit" value="Submit"/>
</form>
    <?php
    function getPalindrome($str){
        if ((strlen($str) == 1) || (strlen($str) == 0)) {
            return "is PALINDROME";
        }
        else {
            if (substr($str,0,1) == substr($str,(strlen($str) - 1),1)) {
                return getPalindrome(substr($str,1,strlen($str) -2));
            }
            else { return "is not a PALINDROME!"; }
        }
    }
    function getReverse($str){
        return strrev($str);
    };
    function getSplit($str){
        $arr = str_split($str);
        return implode(' ', $arr);
    }
    function getHash($str){
        return crypt($str);
    }
    function getShuffle($str){
        return str_shuffle($str);
    }
    If (isset($_POST['input']) && !empty($_POST['input']) && isset($_POST["modifies"])):
        $inputString = $_POST['input'];
        $modifies = $_POST['modifies'];
        $result = '';
        switch ($modifies) {
    	case 'palindrome':$result = $inputString.' '.getPalindrome($inputString); break;
    	case 'reverse':$result = getReverse($inputString); break;
    	case 'split':$result = getSplit($inputString); break;
    	case 'hash':$result = getHash($inputString); break;
    	case 'shuffle':$result = getShuffle($inputString);break;
    		default: echo('Error!');break;
    }
    echo $result;
    endif; ?>
</body>
</html>


<?php
mb_internal_encoding('UTF-8');

if ($_POST) {
    //data normalization
    $fname = trim($_POST['fname']);
    $lname = trim($_POST['lname']);
    $mail = trim($_POST['mail']);
    $phone = trim($_POST['phone']);
    $bdate = $_POST['birthdate'];
    $nation = $_POST['nation'];
    $company = trim($_POST['company']);
    $from = $_POST['from'];
    $to = $_POST['to'];
    $pcLang = $_POST['pc-lang'];
    $pcLevel = $_POST['pc-level'];
    $lang = $_POST['lang'];
    $comprLevel = $_POST['compr-level'];
    $readLevel = $_POST['read-level'];
    $writeLevel = $_POST['write-level'];
    if (!isset($_POST['gender'])) {
        $gender = 'Please select gender!';
    } else {
        $gender = $_POST['gender'];
    }

    if (empty($bdate)) {
        $bdate = 'Please enter Birth Date!';
    }

    if (empty($from)) {
        $from = 'Please select Date!';
    }

    if (empty($to)) {
        $to = 'Please select Date!';
    }
    if (empty($_POST['category'])) {
        $category = [];
    } else {
        $category = $_POST['category'];
    }

    //data validation
    if (!(ctype_alpha($fname)) || mb_strlen($fname) <= 2 || mb_strlen($fname) > 20) {
        $fname = 'Please enter valid First Name!';
    }

    if (!(ctype_alpha($lname)) || mb_strlen($lname) <= 2 || mb_strlen($lname) > 20) {
        $lname = 'Please enter valid Last Name!';
    }
    $length = count($lang);
    for ($i = 0; $i < $length; $i++) {
        if (!(ctype_alpha($lang[$i])) || mb_strlen($lang[$i]) <= 2 || mb_strlen($lang[$i]) > 20) {
            $lang[$i] = 'Please enter valid Language!';
        }
    }

    for ($i = 0; $i < $length; $i++) {
        if ($comprLevel[$i]==='-Comprehension-') {
            $comprLevel[$i]='Please select Comprehension!';
        }
    }
    for ($i = 0; $i < $length; $i++) {
        if ($readLevel[$i]==='-Reading-') {
            $readLevel[$i] = 'Please select Reading!';
        }
    }
    for ($i = 0; $i < $length; $i++) {
        if ($writeLevel[$i]==='-Writing-') {
            $writeLevel[$i] = 'Please select Writing!';
        }
    }

    $length2 = count($pcLang);
    for ($i = 0; $i<$length2;$i++) {
        if (!(ctype_alpha($pcLang[$i])) || mb_strlen($pcLang[$i]) <= 2 || mb_strlen($pcLang[$i]) > 20) {
            $pcLang[$i] = 'Please enter valid Programming Language!';
        }
    }

    if (!(ctype_alnum($company)) || mb_strlen($company) <= 2 || mb_strlen($company) > 20) {
        $company = 'Please enter valid Company Name!';
    }

    if (preg_match('/^[0-9 \' \'+-]+$/', $phone) !== 1) {
        $phone = 'Please enter valid Phone Number!';
    }

    if (filter_var($mail, FILTER_VALIDATE_EMAIL) === false) {
        $mail = 'Please enter valid Email!';
    }
}
?>
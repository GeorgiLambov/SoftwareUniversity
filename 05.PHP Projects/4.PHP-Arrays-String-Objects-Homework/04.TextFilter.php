<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>Text Filter</title>
</head>
<body>
<form action="04.TextFilter.php" method="post">
    Enter text:<br/>
    <textarea name="text"></textarea><br/>
    Enter of banned words:<br/>
    <textarea name="bannedWords"></textarea><br/>
    <input type="submit" value="Submit"/><br/>
</form>
<?php
If (isset($_POST['text']) && !empty($_POST['text']) && isset($_POST['bannedWords']) && !empty($_POST['bannedWords'])):
    $text = $_POST['text'];
    $banlist = explode(', ', $_POST['bannedWords']);

    foreach ($banlist as $key => $value) {
        $asterisks = '';
        for ($i = 0; $i < strlen($value); $i++) {
            $asterisks = $asterisks . "*";
        };
        $text = str_replace($value, $asterisks, $text);
    }
    echo "<p>$text;</p>";
endif; ?>
</body>
</html>
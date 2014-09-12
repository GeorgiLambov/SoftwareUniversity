<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Coloring Texts</title>
    <style>
        .red {
            color: red;
        }

        .blue {
            color: blue;
        }
    </style>
</head>
<body>
<form method="post" action="02.TextColorer.php">
    <textarea name="text"></textarea><br/>
    <input type="submit" value="Color text"/><br/>
</form>
<?php
If (isset($_POST['text']) && !empty($_POST['text'])):
    $inputString = $_POST['text'];
    $inputString = str_split($inputString, 1);

    for ($i = 0; $i < count($inputString); $i++) {
        if ($inputString[$i] != '') {
            if (ord($inputString[$i]) % 2 == 0) {
                echo "<span class='red'>$inputString[$i] </span>";
            } else {
                echo "<span class='blue'>$inputString[$i] </span>";
            }
        }
    }
endif; ?>
</body>
</html>


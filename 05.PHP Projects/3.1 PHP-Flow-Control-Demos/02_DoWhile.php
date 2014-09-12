<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
</head>
<body>
<?php
$n = 10;
$factorial = 1;

do {
    $factorial *= $n;
    $n--;
} while ($n > 0);

echo $factorial;
?>
</body>
</html>


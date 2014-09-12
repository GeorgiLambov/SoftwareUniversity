<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
</head>
<body>
<?php
$a = 1;
$b = 2;

function Sum()
{
    //try to comment
    global $a, $b;

    $b = $a + $b;
}

Sum();
echo $b;
?>
</body>
</html>

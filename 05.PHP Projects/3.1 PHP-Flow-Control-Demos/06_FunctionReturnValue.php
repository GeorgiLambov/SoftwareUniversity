<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
</head>
<body>
<?php
function powGivenNumber($num, $powNum)
{
    $result = 1;
    for ($i = 0; $i < $powNum; $i += 1) {
        $result *= $num;
    }
    return $result;
}
echo powGivenNumber(2, 8);
// outputs '256'.
?>
</body>
</html>


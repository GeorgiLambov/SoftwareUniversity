<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Find Primes in Range</title>
</head>
<body>
<form method="post" action="04.PrimesInRange.php">
    Start Index:
    <input type="text" name="startNum"/>
    End:
    <input type="text" name="endNum"/>
    <input type="submit" value="Submit"/>
</form>

<?php
function isPrime($number)
{
    if ($number <= 1) {
        return false;
    } elseif ($number == 2) {
        return true;
    } else if ($number % 2 == 0) {
        return false;
    } else {
        for ($i = 3; $i <= ceil(sqrt($number)); $i += 2) {
            if ($number % $i == 0) {
                return false;
            }
        }
        return true;
    }
}

If (isset($_POST['startNum']) && !empty($_POST['startNum']) && isset($_POST['endNum']) && !empty($_POST['endNum'])):
    $startNum = intval($_POST['startNum']);
    $endNum = intval($_POST['endNum']);
    $result = array();
    for ($number = $startNum; $number <= $endNum; $number++) {
        $result[] = isPrime($number) ? "<b>$number</b>" : $number;
    }
    echo implode(', ', $result);

endif;
?>

</body>
</html>


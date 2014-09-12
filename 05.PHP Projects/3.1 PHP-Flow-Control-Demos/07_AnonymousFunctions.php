<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
</head>
<body>
<?php
$array = array("Team building: 6-7 September 2014, Pirin", "Nakov", "studying programming", "SoftUni");

usort($array, function($a, $b) {
    return strlen($a) - strlen($b);
});
print_r($array);
?>
</body>
</html>
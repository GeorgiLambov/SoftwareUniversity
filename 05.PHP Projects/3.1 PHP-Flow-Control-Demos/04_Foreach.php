<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
</head>
<body>
<?php
$colors = array("red","green","blue","yellow");

foreach ($colors as $value) {
    echo "$value <br>";
}
  
$colorMap = array("red" => "#FF0000", "green" => "#00FF00","blue" => "#000FF");

foreach ($colorMap as $key => $value) {
    echo "<p>$key -> $value</p>";
}
?>
</body>
</html>
<!DOKTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>PrintTags</title>
</head>
<body>
<div>Enter tags:</div>
<form action="01.PrintTags.php" method="get">
    <input type="text" name="tags"/>
    <input type="submit"/>
</form>
<?php
if (isset($_GET['tags'])) {
    $tags = explode(", ", $_GET['tags']); // make str in arr

    for ($i = 0; $i < sizeof($tags); $i++) {
        echo "$i : $tags[$i] <br />";
    }
}
?>
</body>
</html>
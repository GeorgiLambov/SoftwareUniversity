<!DOKTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>MostFrequentTag</title>
</head>
<body>
<div>Enter tags:</div>
<form action="02.MostFrequentTag.php" method="get">
    <input type="text" name="tags"/>
    <input type="submit"/>
</form>
<?php
if (isset($_GET['tags'])) {
    $tags = explode(", ", $_GET['tags']); // make str in arr
    $c = array_count_values($tags); // return arr with key -> count
    $val = array_search(max($c), $c);
    arsort($c);
    foreach ($c as $key => $value) {
        echo "$key : $value times <br />";
    }
    echo "<p>Most Frequent Tag is: $val</p>";
}
?>
</body>
</html>
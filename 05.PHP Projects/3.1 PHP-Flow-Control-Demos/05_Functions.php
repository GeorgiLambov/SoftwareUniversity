<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
</head>
<body>
<?php
function displayFirstAndLastName($first = 'Svetlin', $last = 'Nakov')
{
    echo "<p>My first name is <strong>$first</strong>" .
        " and my last name is <strong>$last</strong></p>";
}

displayFirstAndLastName("Vlado", "Georgiev");
displayFirstAndLastName();
?>
</body>
</html>


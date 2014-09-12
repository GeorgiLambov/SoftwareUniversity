<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Rich People’s Problems</title>
    <style>
        th, td {
            border: 1px solid;
            padding: 5px;
        }

        table {
            border-collapse: collapse;
        }
    </style>
</head>
<body>
<form method="post" action="02.CarRandomizer.php">
    Enter cars:
    <input type="text" name="cars"/>
    <input type="submit" value="Show Result"/>
</form>
<table>
    <?php
    If (isset($_POST['cars']) && !empty($_POST['cars'])):
        $cars = explode(", ", $_POST['cars']);
        $colors = ['red', 'yellow', 'blue', 'black', 'orange', 'silver', 'green'];
        ?>
        <tr>
            <th>Car</th>
            <th>Color</th>
            <th>Count</th>
        </tr>
        <?php
        for ($i = 0;
             $i < count($cars);
             $i++):
            $color = array_rand($colors);
            $quantity = rand(1, 5);
            ?>
            <tr>
                <td><?= $cars[$i] ?></td>
                <td><?= $colors[$color] ?></td>
                <td><?= $quantity ?></td>
            </tr>
        <?php endfor; ?>
    <?php endif; ?>
</table>
</body>
</html>


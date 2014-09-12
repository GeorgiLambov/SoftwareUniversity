<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Sum of Digits</title>
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
<form method="post" action="05.SumOfDigits.php">
    Input string:
    <input type="text" name="numbersStr"/>
    <input type="submit" value="Submit"/>
</form>
<table>
    <?php
    If (isset($_POST['numbersStr']) && !empty($_POST['numbersStr'])):
        $numbersStr = explode(", ", $_POST['numbersStr']);
        ?>
        <tr>
            <th>Number</th>
            <th>Sum of digits</th>
        </tr>
        <?php
        for ($i = 0;
             $i < count($numbersStr);
             $i++) :
            if (is_numeric($numbersStr[$i])) {
                $number = (int)$numbersStr[$i];
                $result = 0;
                do {
                    $result += $number % 10;
                } while ($number = (int)$number / 10);
            } else {

                $result = "I cannot sum that.";
            }
            ?>
            <tr>
                <td><?= $numbersStr[$i] ?></td>
                <td><?= $result ?></td>

            </tr>
        <?php endfor; ?>
    <?php endif; ?>
</table>
</body>
</html>

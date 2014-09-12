<!DOCTYPE html>
<html>
<head>
    <link rel=" stylesheet" href="01.SquareRootSum.css">
    <meta charset="UTF-8">
    <title>Square Root Sum</title>
</head>
<body>
<table>
    <tr>
        <th>Number</th>
        <th>Square root</th>
    </tr>
    <?php $sum = 0;
    for ($i = 0;
         $i <= 100;
         $i += 2):
        $sqrt = sqrt($i);
        $sum += $sqrt;
        $sqrtRound = round($sqrt, 2);
        ?>
        <tr>
            <td><?= $i ?></td>
            <td><?= $sqrtRound ?></td>
        </tr>
    <?php endfor; ?>
    <tr>
        <td><b>Total:</b></td>
        <td><?= round($sum, 2) ?></td>
    </tr>
</table>
</body>
</html>


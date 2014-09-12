<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Show Annual Expenses</title>
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
<form method="post" action="03.AnnualExpenses.php">
    Enter numbers of years:
    <input type="text" name="num"/>
    <input type="submit" value="Show costs"/>
</form>
<table>
    <?php
    If (isset($_POST['num']) && !empty($_POST['num'])):
        $num = $_POST['num'];
        ?>
        <tr>
            <th>Year</th>
            <th>January</th>
            <th>February</th>
            <th>March</th>
            <th>April</th>
            <th>May</th>
            <th>June</th>
            <th>July</th>
            <th>August</th>
            <th>September</th>
            <th>October</th>
            <th>November</th>
            <th>December</th>
            <th>Total:</th>
        </tr>
        <?php
        $year = date("Y");
        for ($i = 0; $i < $num; $i++) {
            $sum = 0;
            echo "<tr><td> $year </td>";
            for ($m = 0; $m < 12; $m++) {
                $costs = rand(0, 999);
                $sum += $costs;
                echo "<td> $costs</td>";
            }
            echo "<td> $sum </td></tr>";
            $year = $year - 1;
        }
        ?>
    <?php endif; ?>
</table>
</body>
</html>


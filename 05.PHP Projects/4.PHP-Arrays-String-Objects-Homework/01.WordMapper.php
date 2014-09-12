<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Word Mapping</title>
    <style>
        td {
            border: 1px solid;
            padding: 5px;
        }

        table {
            border-collapse: collapse;
        }
    </style>
</head>
<body>
<form method="post" action="01.WordMapper.php">
    <textarea name="words"></textarea><br/>
    <input type="submit" value="Count Words"/><br/>
</form>
<table>
    <?php
    If (isset($_POST['words']) && !empty($_POST['words'])):
        $inputString = $_POST['words'];
        $inputString = strtolower($inputString);
        $pattern = "/([A-Za-z])\w*/";
        preg_match_all($pattern, $inputString, $matches);
        $resultArr = array_count_values($matches[0]);

        foreach ($resultArr as $key => $value) {
            echo "<tr>
                <td> $key  </td>
                <td>$value </td>
            </tr>";
        }
        ?>
    <?php endif; ?>
</table>
</body>
</html>


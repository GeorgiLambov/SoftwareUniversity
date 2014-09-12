<!DOKTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>InfoTable</title>
    <link href="InformationTableStyles.css" rel="stylesheet">
</head>
<body>
<?php
$name = "Gosho";
$phone = "0882-321-423";
$age = "24";
$address = "Hadji Dimitar";
?>
<table>
    <tr>
        <td>Name</td>
        <td>
            <?php
            echo $name;
            ?>
        </td>
    </tr>
    <tr>
        <td>Phone number</td>
        <td>
            <?php
            echo $phone;
            ?>
        </td>
    </tr>
    <tr>
        <td>Age</td>
        <td>
            <?php
            echo $age;
            ?>
        </td>
    </tr>
    <tr>
        <td>Address</td>
        <td>
            <?php
            echo $address;
            ?>
        </td>
    </tr>
</table>
</body>
</html>
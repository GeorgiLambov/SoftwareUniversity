<!DOKTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>FormData</title>
    <link href=".css" rel="stylesheet">
</head>
<body>
<form action="07.GetFormData.php" method="get">
    <div><input type="text" name='name' placeholder="Name.."></div>
    <div><input type="text" name='age' placeholder="Age.."></div>
    <div><input type="radio" name='gender' id="male" value="male"><label for="male">Male</label></div>
    <div><input type="radio" name='gender' id="female" value="female"><label for="female">Female</label></div>
    <input type="submit" value="Send" name="formData">
</form>
<?php
if (isset($_GET["formData"])) {
    echo "My name is {$_GET['name']}. I am {$_GET['age']} years old.I am {$_GET['gender']}.";
}
?>
</body>
</html>




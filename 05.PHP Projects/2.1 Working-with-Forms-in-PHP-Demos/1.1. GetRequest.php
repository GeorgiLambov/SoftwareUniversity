<!DOCTYPE html>
<html>
<head>
	<title>GET Request</title>
</head>
<body>
	<form action="<?php $_PHP_SELF ?>" method="GET">
		Name: <input type="text" name="name" />
		Age: <input type="text" name="age" />
		<input type="submit" name="submit" />
	</form>	

	<?php
	//check if keys "name" or "age" exist (you may get warning )
	if( isset($_GET['submit']) )
	{
		$name = $_GET['name'];
		$age = $_GET['age'];
	    echo "Welcome $name!<br />";
	    echo "You are $age years old.";
	}
	?>
</body>
</html>

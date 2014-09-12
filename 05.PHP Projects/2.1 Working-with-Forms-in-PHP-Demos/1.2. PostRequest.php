<?php
//check if keys "name" or "age" exist (you may get warning )
if ( isset($_POST['submit']) ) {
	if( $_POST["name"] || $_POST["age"] )
	{
	    echo "Welcome ". $_POST['name']. "<br />";
	    echo "You are ". $_POST['age']. " years old." . "<br />";
	    exit();
	}
}
?>
<html>
<body>
	<form action="<?php $_PHP_SELF ?>" method="POST">
		Name: <input type="text" name="name" />
		Age: <input type="text" name="age" />
		<input type="submit" name="submit" />
	</form>
</body>
</html>
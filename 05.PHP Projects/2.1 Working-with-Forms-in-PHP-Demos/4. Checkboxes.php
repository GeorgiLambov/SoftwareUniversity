<html>
<body>
	<p>Which is your favourite Programming Language? (You may select more then one.)</p>
	<form action="<?php $_PHP_SELF ?>" method="POST">

		<input id = "csharp" type="checkbox" name="lang[]" value="csharp"/>
		<label for="csharp">CSharp</label>

		<input id = "java" type="checkbox" name="lang[]" value="java"/>
		<label for="java">Java</label>

		<input id = "js" type="checkbox" name="lang[]" value="js"/>
		<label for="js">JavaScript</label>

		<input id = "php" type="checkbox" name="lang[]" value="php"/>
		<label for="php">PHP</label>

		<input id = "python" type="checkbox" name="lang[]" value="python"/>
		<label for="python">Python</label>

		<input id = "ruby" type="checkbox" name="lang[]" value="ruby"/>
		<label for="ruby">Ruby</label>

		<input id = "html" type="checkbox" name="lang[]" value="html"/>
		<label for="html">HTML</label>

		<input id ="cpp" type="checkbox" name="lang[]" value="cpp"/>
		<label for="cpp">C++</label>
		
		<input type="submit" />
	</form>
</body>
</html>

<?php
    // all information is in array lang that come in arr $_POST
    echo "<pre>" , print_r ($_POST, true) , "</pre>";
?>
<!DOCTYPE html>
<html>
<head>
	<title>Select Multiple</title>
</head>
<body>
	<h3> Select Trainers for PHP Course:</h3>

	<form method="POST" action="<?php $_PHP_SELF ?>">
	   <select style="width:300px;"multiple="yes" name="gentlemen[]">
		   <option value="V.K."> Vlado.K.</option>
		   <option value="V.G."> Vlado.G. </option>
		   <option value="Nakov"> Nakov </option>
		   <option value="T.Kurtev"> T.Kurtev </option>
		   <option value="D.Dachev"> D.Dachev </option>
		   <option value="A.Rusenov"> A.Rusenov </option>
	   </select>

	   <input type="submit" name="submit" value="Enter Your Choice"/>
	</form>

	<h4>
		<?php
			if (isset($_POST['submit'])) {
				  $selected_gentlemen = $_POST['gentlemen'];
				  echo implode(", ", $selected_gentlemen);
				}
		?>
	</h4>
</body>
</html>
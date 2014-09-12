<html>
<head>
<title>Certificate 1-3</title>
</head>
	<body>
	<?php
	// this starts the session
	session_start();
	?>
	<p>Fill Out Your Data:</p> 
		<form action="index2.php" name="firstSubmit" method="POST">
			<table border="0" cellspacing="10">
				<tr>
					<td>Full Name: </td>
					<td><input name="fullname" id="name" type="text" size="20" maxlength="80"></td>
				</tr>
				<tr>
					<td>Title:</td>
					<td><input name="title" id="title" type="text" size="20" maxlength="80"></td>
				</tr>
				<tr>
					<td>Company:</td>
					<td><input name="company" id="company" type="text" size="20" maxlength="80"></td>
				</tr>
				<tr>
					<td>Course:</td>
					<td>PHP Basics</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td><input type="submit" name="submit" value="Proceed &gt; &gt;"></td>
				</tr>
			</table>
		</form>
	</body>
</html>
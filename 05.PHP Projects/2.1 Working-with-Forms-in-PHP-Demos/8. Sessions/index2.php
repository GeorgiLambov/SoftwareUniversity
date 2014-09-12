<html>	
<head>
<title>Certificate 2-3</title>
</head>
	<body>
		<?php
		// this starts the session
		session_start();
		// this pulls input variables from the session form 
		$_SESSION['fullname']= $_POST['fullname'];
		$_SESSION['title']= $_POST['title'];
		$_SESSION['company']= $_POST['company'];
		?>
		<p>Here we have simple output.Go to next page for Certificate-like view.</p>
		<form action="certificate.php" name="certificateSubmit" method="POST">
			<table border="0" cellspacing="10">
				<tr>
					<td>Full Name: </td>
					<td><?php echo  $_SESSION['fullname']; ?></td>
				</tr>
				<tr>
					<td>Title:</td>
					<td><?php echo  $_SESSION['title']; ?></td>
				</tr>
				<tr>
					<td>Company:</td>
					<td><?php echo  $_SESSION['company']; ?></td>
				</tr>
				<tr>
					<td>Course:</td>
					<td>PHP Basics</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td><input type="Submit" name="submit" value="Generate Certificate &gt; &gt;"></td>
				</tr>
			</table>
			<!-- make sure we send our variables through this form page to the next one -->
			<input type="hidden" name="fullname" value="<?php echo  $_SESSION['fullname']; ?>">
			<input type="hidden" name="title" value="<?php echo  $_SESSION['title']; ?>">
			<input type="hidden" name="company" value="<?php echo  $_SESSION['company']; ?>">
		</form>
	</body>
</html>
<html>
	<head>
		<title>Certificate 3-3</title>
	</head>
	<body>	
	<?php
	// this starts the session
	require './includes/now.fn';
	session_start();
	// this pulls input variables from the session form 
	$_SESSION['fullname']		= $_POST['fullname'];
	$_SESSION['title'] 			= $_POST['title'];
	$_SESSION['company'] 		= $_POST['company'];
	?>
		<div>
			<table border="0" cellspacing="10" cellpadding="2" background="images/certificate_border.png">
				<tr>
					<td align="center">
						<img src="images/spacer.gif" width="415" height="3"><br />
						<h1><?php echo  $_SESSION['company']; ?></h1>
						<p><?php echo 'Date: '.$now.'<br/>'; ?>					
						In recognition of successfully completing the course:</p>
						<p><strong>PHP Basics</strong></p>				
						<h2>
							<?php echo  $_SESSION['fullname']; ?><br />
							<?php echo  $_SESSION['title']; ?>	
						</h2>						
						<p>is hereby awarded this</p>					
						<h3>Certificate of Completion</h3><br />

						<img src="images/spacer.gif" width="415" height="20">
					</td>
				</tr>
			</table>
		</div>
	</body>
</html>
<?php
mb_internal_encoding('UTF-8');
$pageTitle = 'Form';
include 'includes/header.php';

if($_POST){
	//normalisation the data
    $username=trim($_POST['username']);
	//if user put '!' then we must replace it with ''
    $username=  str_replace('!', '', $username);
    $phone=trim($_POST['phone']);
    $phone=  str_replace('!', '', $phone);
	//ensure that the var is in correct format
    $selectedGroup=(int)$_POST['group'];
    $error=false;
	//data validation
    if(mb_strlen($username)<4){
        echo '<p>The name is too short!</p>';
        $error=true;
    }   
    if(mb_strlen($phone)<6 || mb_strlen($phone)>12){
        echo '<p>Invalid phone number!</p>';
        $error=true;
    }    
    if(!array_key_exists($selectedGroup, $groups)){
        echo '<p>Invalid group!</p>';
        $error=true;
    }   
    if(!$error){
		// put information in file and print message
        $result=$username.'!'.$phone.'!'.$selectedGroup."\n";
        if(file_put_contents('data.txt', $result,FILE_APPEND))
        {
            echo 'The submission is successful'."\n";
        }
    }
}

?>
<a href="2.2.Normalization-AddressBook.php">Go to the Address Book</a>
<form method="POST">
    <div>Name:<input type="text" name="username" /></div>
    <div>Phone:<input type="text" name="phone" /></div>
    <div>
        <select name="group">
            <?php
            foreach ($groups as $key=>$value) {
                echo '<option value="'.$key.'">'. $value .'</option>';
            }
            ?>
        </select>           
    </div>        
    <div><input type="submit" value="Add New Contact" /></div>
</form>
<?php
include 'includes/footer.php';
?>
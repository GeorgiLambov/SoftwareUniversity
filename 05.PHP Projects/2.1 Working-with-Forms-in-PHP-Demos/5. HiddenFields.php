<form name="myWebForm" action="<?php $_PHP_SELF ?>" method="post">
    First Name: <input title="Please Enter Your First Name" id="first" name="firstName" type="text" size="12" maxlength="12" /><br/>
    Last Name: <input title="Please Enter Your Last Name" id="last" name="lastName" type="text" size="18" maxlength="24" /><br />
    Password: <input type="password" title="Please Enter Your Password" size="8" maxlength="8" /><br /><br />
    <input type="hidden" name="orderNumber" id="orderNumber" value="0024" /><br />
    <input type="submit" value="Submit" />
    <input type="reset" value="Reset" />
</form>

<?php
//In array exist key "orderNumber" that comes from hidden input
echo "<p> The array \$_POST exist the following information </p>";
echo "<pre>" , print_r ($_POST, true) , "</pre>";
?>
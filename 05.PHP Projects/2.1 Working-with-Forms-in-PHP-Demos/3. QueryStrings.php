<form action="<?php $_PHP_SELF ?>" method="GET">
    <div>
        <label for="name">Name:</label>
        <input type="text" id="name" name="user_name" />
    </div>
    <div>
        <label for="mail">E-mail:</label>
        <input type="email" id="mail" name="user_email" />
    </div>
    <div>
        <label for="msg">Message:</label>
        <textarea id="msg" name="user_message"></textarea>
    </div>

    <div class="button">
        <button type="submit">Send Your Message</button>
    </div>
</form>
<h3>Get the value of element with key "QUERY_STRING" :
<?php
echo '<pre>'.$_SERVER["QUERY_STRING"].'</pre>';
?>
</h3>
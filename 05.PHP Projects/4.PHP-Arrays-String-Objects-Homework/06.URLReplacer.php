<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>URL Replacer</title>
</head>
<body>
<form action="06.URLReplacer.php" method="post">
    Enter text:<br/>
    <textarea name="text"></textarea><br/>
    <input type="submit" value="Submit"/><br/>
</form>
<?php
If (isset($_POST['text']) && !empty($_POST['text'])):
    $text = trim($_POST['text']);
    $text = str_replace('</a>', '[/URL]', $text);
    $text = preg_replace('/<a href="(.*?)">/', '[URL=\1]', $text);
    echo htmlentities($text);

endif; ?>
</body>
</html>
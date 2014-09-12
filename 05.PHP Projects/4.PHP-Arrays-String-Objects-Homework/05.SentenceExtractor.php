<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>Sentence Extractor</title>
</head>
<body>
<form action="05.SentenceExtractor.php" method="post">
    Enter text:<br/>
    <textarea name="text"></textarea><br/>
    Enter of word:<br/>
    <textarea name="word"></textarea><br/>
    <input type="submit" value="Submit"/><br/>
</form>
<?php
If (isset($_POST['text']) && !empty($_POST['text']) && isset($_POST['word']) && !empty($_POST['word'])):
    $text = trim($_POST['text']);
    $word = trim($_POST['word']);
    $patternSentence = '/(\S.+?[.!?])(?=\s+|$)/';  // extract sentences
    $wordPattern = '/\b([a-zA-Z]+)\b/';       // extract word
    $allSentence = [];
    preg_match_all($patternSentence, $text, $allSentence);
    for ($i = 0; $i < count($allSentence[0]); $i++) {
        $sentence = $allSentence[0][$i];
        $words = [];
        preg_match_all($wordPattern, $sentence, $words);
        foreach ($words[0] as $key => $value) {
            if ($value == $word) {
                echo "<p>$sentence</p>";
                break;
            }
        }
    }
endif; ?>
</body>
</html>
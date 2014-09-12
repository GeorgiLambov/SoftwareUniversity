<?php
date_default_timezone_set("Europe/Sofia");
$input = $_GET['text'];

preg_match_all("/[^\r\n]+/", $input, $match, PREG_SPLIT_NO_EMPTY);
$messagesArr = $match[0];
$resultArr = [];
for ($i = 0; $i < count($messagesArr); $i++) {
    $messageInfo = preg_split("/\s*\;\s*/", $messagesArr[$i], -1, PREG_SPLIT_NO_EMPTY);

    $current = new stdClass();

    $current->autor = trim($messageInfo[0]);
    $currentDate = trim($messageInfo[1]);
    $currentDate = strtotime($currentDate);
    $current->date = $currentDate;
    $current->post = trim($messageInfo[2]);
    $current->likes = trim($messageInfo[3]);

    if (isset($messageInfo[4])) {
        $comments = preg_split("/\s*\/\s*/", trim($messageInfo[4]), -1, PREG_SPLIT_NO_EMPTY);
        $current->coments = $comments;
    }
    $resultArr[] = $current;
}
if (count($resultArr) > 1) {
    usort($resultArr, function ($A, $B) {
        if (($A->date == $B->date)) {
            return 0;
        }
        return ($A->date > $B->date) ? -1 : 1;
    });
}
$result = '';
foreach ($resultArr as $current) {
    $date = date("j F Y", $current->date);
    $result .= "<article>";
    $result .= "<header><span>" . htmlspecialchars($current->autor) . "</span><time>" . $date . "</time></header>";
    $result .= "<main><p>" . htmlspecialchars($current->post) . "</p></main>";
    $result .= "<footer><div class=\"likes\">$current->likes people like this</div>";

    if (isset($current->coments)) {
        $result .= "<div class=\"comments\">";

        foreach ($current->coments as $comment) {
            $comment = htmlspecialchars($comment);
            $result .= "<p>$comment</p>";
        }
        $result .= "</div>";

    }
    $result .= "</footer></article>";
}
echo $result;



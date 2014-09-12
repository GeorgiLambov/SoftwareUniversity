<?php
$inputString = $_GET['text'];
$onlyArtist = $_GET['artist'];
$property = $_GET['property'];
$order = $_GET['order'];

preg_match_all("/[^\r\n]+/", $inputString, $match, PREG_SPLIT_NO_EMPTY);
$inputArr = $match[0];
$songList = [];
for ($i = 0; $i < count($inputArr); $i++) {
    $singleLine = preg_split("/\s*\|\s*/", $inputArr[$i], -1, PREG_SPLIT_NO_EMPTY);

    $currentSong = new stdClass();
    $currentSong->name = trim($singleLine[0]);
    $currentSong->genre = trim($singleLine[1]);
    $artists = $singleLine[2];
    $artists = explode(", ", $artists);
    sort($artists);
    $currentSong->artists = $artists;
    $currentSong->downloads = intval($singleLine[3]);
    $currentSong->rating = floatval($singleLine[4]);

    if (in_array($onlyArtist, $artists)) {
        $songList[] = $currentSong;
    }
}
usort($songList, function ($s1, $s2) use ($order, $property) {
    if ($s1->$property == $s2->$property) {
        return strcmp($s1->name, $s2->name);
    }
    return ($order == "ascending" ^ $s1->$property < $s2->$property) ? 1 : -1;
});
echo "<table>\n<tr><th>Name</th><th>Genre</th><th>Artists</th><th>Downloads</th><th>Rating</th></tr>\n";
foreach ($songList as $song) {
    echo "<tr>";
    $artists = htmlspecialchars(implode(", ", $song->artists));
    $song->name = htmlspecialchars($song->name);
    $song->genre = htmlspecialchars($song->genre);
    echo "<td>$song->name</td><td>$song->genre</td><td>$artists</td><td>$song->downloads</td><td>$song->rating</td>";
    echo "</tr>\n";
}
echo "</table>";
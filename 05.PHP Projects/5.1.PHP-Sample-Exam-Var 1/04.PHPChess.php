<?php
$input = $_GET['board'];

$lines = preg_split('/\//', $input, -1, PREG_SPLIT_NO_EMPTY);
// Validate the chessboard
isValidChessBoard($lines);

$board = [];
for ($row = 0, $startIndex = 0; $startIndex < strlen($input); $row++, $startIndex += 17) {
    $board[] = preg_split("/-/", $lines[$row], -1, PREG_SPLIT_NO_EMPTY);
}
$pieces = array();
echo "<table>";
for ($row = 0; $row < count($board); $row++) {
    echo "<tr>";
    for ($col = 0; $col < count($board[$row]); $col++) {
        $piece = getPiece($row, $col, $board);
        if ($piece != 'empty') {
            if (!isset($pieces[$piece])) {
                $pieces[$piece] = 1;
            } else {
                $pieces[$piece]++;
            }
        }
        echo "<td>" . $board[$row][$col] . "</td>";
    }
    echo "</tr>";
}
echo "</table>";
ksort($pieces);
echo json_encode($pieces);


function isValidChessBoard($boardLines)
{
    if (count($boardLines) != 8) {
        die("<h1>Invalid chess board</h1>");
    }
    foreach ($boardLines as $line) {
        if (strlen($line) != 15) {
            die("<h1>Invalid chess board</h1>");
        }
        for ($row = 0; $row <= strlen($line); $row += 2) {
            if (!isEmptyOrPiece($line[$row])) {
                die("<h1>Invalid chess board</h1>");
            }
        }
    }
}

function isEmptyOrPiece($letter)
{
    return $letter == 'R' || $letter == 'B' || $letter == 'H' || $letter == 'Q' || $letter == 'K' || $letter == 'P' || $letter == " ";
}

function getPiece($row, $col, $board)
{
    switch ($board[$row][$col]) {
        case "R":
            return "Rook";
            break;
        case "H":
            return "Horseman";
            break;
        case "B":
            return "Bishop";
            break;
        case "K":
            return "King";
            break;
        case "Q":
            return "Queen";
            break;
        case "P":
            return "Pawn";
            break;
        default:
            return "empty";
    }
}

?>
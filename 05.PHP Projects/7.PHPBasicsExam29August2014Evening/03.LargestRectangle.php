<?php
$jsonTable = $_GET['jsonTable'];
$matrix = json_decode($jsonTable);
list($minRow, $minCol, $maxRow, $maxCol) = findLargestRectangularArea($matrix);

printTable($matrix, $minRow, $minCol, $maxRow, $maxCol);

function findLargestRectangularArea($matrix)
{
    $maxArea = 0;
    $result = false;
    for ($minRow = 0; $minRow < count($matrix); $minRow++) {
        for ($maxRow = $minRow; $maxRow < count($matrix); $maxRow++) {
            for ($minCol = 0; $minCol < count($matrix[$minRow]); $minCol++) {
                for ($maxCol = $minCol; $maxCol < count($matrix[$minRow]); $maxCol++) {
                    if (isRectangle($matrix, $minRow, $minCol, $maxRow, $maxCol)) {
                        $area = ($maxRow - $minRow + 1) * ($maxCol - $minCol + 1);
                        if ($area > $maxArea) {
                            $maxArea = $area;
                            $result = [$minRow, $minCol, $maxRow, $maxCol];
                        }
                    }
                }
            }
        }
    }
    return $result;
}

function isRectangle($input, $minRow, $minCol, $maxRow, $maxCol)
{
    $value = $input[$minRow][$minCol];
    for ($col = $minCol; $col <= $maxCol; $col++) {
        if ($input[$minRow][$col] != $value) {
            return false;
        }
        if ($input[$maxRow][$col] != $value) {
            return false;
        }
    }
    for ($row = $minRow + 1; $row < $maxRow; $row++) {
        if ($input[$row][$minCol] != $value) {
            return false;
        }
        if ($input[$row][$maxCol] != $value) {
            return false;
        }
    }
    return true;
}

function printTable($input, $minRow, $minCol, $maxRow, $maxCol) {
    echo "<table border='1' cellpadding='5'>";
    for ($row = 0; $row < count($input); $row++) {
        echo "<tr>";
        for ($col = 0; $col < count($input[$row]); $col++) {
            $topBorder = ($row == $minRow) && ($col >= $minCol && $col <= $maxCol);
            $rightBorder = ($col == $maxCol) && ($row >= $minRow && $row <= $maxRow);
            $downBorder = ($row == $maxRow) && ($col >= $minCol && $col <= $maxCol);
            $leftBorder = ($col == $minCol) && ($row >= $minRow && $row <= $maxRow);
            if ($topBorder || $rightBorder || $downBorder || $leftBorder) {
                echo "<td style='background:#CCC'>";
            } else {
                echo "<td>";
            }
            echo htmlspecialchars($input[$row][$col]);
            echo "</td>";
        }
        echo "</tr>";
    }
    echo "</table>";
}
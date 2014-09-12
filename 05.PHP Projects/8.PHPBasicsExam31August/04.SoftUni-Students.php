<?php
$inputString = $_GET['students'];
$property = $_GET['column'];   //filter
$order = $_GET['order'];

$id = 1;

preg_match_all("/[^\r\n]+/", $inputString, $match, PREG_SPLIT_NO_EMPTY);
$inputArr = $match[0];
$students = [];
for ($i = 0; $i < count($inputArr); $i++) {
    $singleLine = preg_split("/\s*,\s*/", $inputArr[$i], -1, PREG_SPLIT_NO_EMPTY);

    $currentStudent = new stdClass();
    $currentStudent->id = $id;
    $currentStudent->username = trim($singleLine[0]);
    $currentStudent->email = trim($singleLine[1]);
    $currentStudent->type = trim($singleLine[2]);
    $currentStudent->result = intval(trim($singleLine[3]));
    $students[] = $currentStudent;
    $id++;
}
usort($students, function ($A, $B) use ($order, $property) {
    if ($A->$property == $B->$property) {
        return ($order == "ascending" ^ $A->id < $B->id) ? 1 : -1;
    }
    return ($order == "ascending" ^ $A->$property < $B->$property) ? 1 : -1;
});
echo "<table><thead><tr><th>Id</th><th>Username</th><th>Email</th><th>Type</th><th>Result</th></tr></thead>";
foreach ($students as $student) {
    echo "<tr>";
    $student->username = htmlspecialchars($student->username);
    $student->email = htmlspecialchars($student->email);
    $student->type = htmlspecialchars($student->type);
    echo "<td>$student->id</td><td>$student->username</td><td>$student->email</td><td>$student->type</td><td>$student->result</td>";
    echo "</tr>";
}
echo "</table>";
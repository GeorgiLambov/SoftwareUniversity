<?php
include('data.php');
?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Result</title>
    <style>
        table,table td{
    border:1px solid black;
    text-align: center;
    }
    table{
    margin-top: 10px;
    }
    </style>
</head>
<body>
<b>CV</b>
<table>
    <tbody>
    <tr>
        <td colspan="2">Personal Information</td>
    </tr>
    <tr>
        <td>First Name</td>
        <td><?= $fname ?></td>
    </tr>
    <tr>
        <td>Last Name</td>
        <td><?= $lname ?></td>
    </tr>
    <tr>
        <td>Email</td>
        <td><?= $mail ?></td>
    </tr>
    <tr>
        <td>Phone Number</td>
        <td><?= $phone ?></td>
    </tr>
    <tr>
        <td>Gender</td>
        <td><?= $gender ?></td>
    </tr>
    <tr>
        <td>Birth Date</td>
        <td><?= $bdate ?></td>
    </tr>
    <tr>
        <td>Nationality</td>
        <td><?= $nation ?></td>
    </tr>
    </tbody>
</table>
<table>
    <tbody>
    <tr>
        <td colspan="2">Last Work Position</td>
    </tr>
    <tr>
        <td>Company Name</td>
        <td><?= $company ?></td>
    </tr>
    <tr>
        <td>From</td>
        <td><?= $from ?></td>
    </tr>
    <tr>
        <td>To</td>
        <td><?= $to ?></td>
    </tr>
    </tbody>
</table>
<table>
    <tbody>
    <tr>
        <td colspan="3">Computer Skills</td>
    </tr>
    <tr>
        <td>Programming Languages</td>
        <td>
            <table>
                <tbody>
                <tr>
                    <td>Language</td>
                    <td>Skill Level</td>
                    <?php
                    $length = count($pcLang);
                    for ($i = 0; $i < $length; $i++) {
                        echo '<tr></tr>';
                        echo "<td>$pcLang[$i]</td>";
                        for ($j = $i; $j < $length; $j++) {
                            echo "<td>$pcLevel[$j]</td>";
                            break;
                        }
                    }
                    ?>
                </tr>
                </tbody>
            </table>
        </td>
    </tr>
    </tbody>
</table>
<table>
    <tbody>
    <tr>
        <td colspan="5">Other Skills</td>
    </tr>
    <tr>
        <td>Languages</td>
        <td>
            <table>
                <tbody>
                <tr>
                    <td>Language</td>
                    <td>Comprehension</td>
                    <td>Reading</td>
                    <td>Writing</td>
                    <?php
                    $length2 = count($lang);

                    for ($i = 0; $i < $length2; $i++) {
                        echo '<tr></tr>';
                        echo "<td>$lang[$i]</td>";
                        for ($j = $i; $j < $length2; $j++) {
                            echo "<td>$comprLevel[$j]</td>";
                            for ($k = $j; $k < $length2; $k++) {
                                echo"<td>$readLevel[$k]</td>";
                                for ($p = $k; $p < $length2; $p++) {
                                    echo "<td>$writeLevel[$p]</td>";
                                    break;
                                }
                                break;
                            }
                            break;
                        }
                    }
                    ?>
                </tr>

                </tbody>
            </table>
        </td>
    </tr>
    <tr>
        <td>Driver's License</td>
        <td><?= implode(', ', $category); ?></td>
    </tr>
    </tbody>
</table>
</body>
</html>
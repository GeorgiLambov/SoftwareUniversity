<?php
$pageTitle='Address Book';
include 'includes/header.php';
?>
<a href="2.1.Normalization-AddressBookForm.php">Add New Contact</a>
<table border="1">
    <tr>
        <td>Name</td>
        <td>Phone</td>
        <td>Group</td>
    </tr>
    <?php
    if(file_exists('data.txt')){
        $result=  file('data.txt');
        foreach ($result as $value) {
            $columns=  explode('!', $value);            
            echo '<tr>
                <td>'.$columns[0].'</td>
                <td>'.$columns[1].'</td>
                <td>'.$groups[trim($columns[2])].'</td>
                </tr>';
        }
    }
    ?> 
</table>
<?php
include 'includes/footer.php';
?>

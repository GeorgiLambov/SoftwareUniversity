<!DOCTYPE html>
<html>
<head>
    <title>Add / Remove Input Fields Dynamically</title>
</head>
<body>

<script>
    var nextId = 0;

    function addInput() {
        nextId++;
        var inputDiv = document.createElement("div");
        inputDiv.setAttribute("id", "num" + nextId);
        inputDiv.innerHTML =
            "<input type='text' name='nums[]' /> " +
            "<a href=\"javascript:removeElement('num" + nextId + "')\">[Remove]</a>" + "<br/>";
        document.getElementById('parent').appendChild(inputDiv);
    }

    function removeElement(id) {
        var inputDiv = document.getElementById(id);
        document.getElementById('parent').removeChild(inputDiv);
    }
</script>

<form method="post">
    <div id="parent">
        <!-- We shall add inputs here with JavaScript -->
    </div>
    <script>addInput();</script>
    <a href="javascript:addInput()">[Add]</a>
    <br />
    <input type="submit" value="Submit" />
</form>

<?php
if (isset($_POST['nums'])) {
    $nums = $_POST['nums'];
    $sum = 0;
    foreach ($nums as $item) {
        $sum += $item;
    }
    echo "The sum is: $sum";
}
?>

</body>
</html>

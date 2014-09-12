<?php
$inputArray = array(
    "hello",
    15,
    1.234,
    array(1, 2, 3, 4),
    (object)[2, 34]
);
foreach ($inputArray as $element) {
    if (is_numeric($element)) {
        echo var_dump($element), "\n";
    } else {
        echo gettype($element), "\n";
    }
}
?>
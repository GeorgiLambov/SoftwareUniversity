<?php
$inputString = $_GET['list'];
$minPrice = $_GET['minPrice'];
$maxPrice = $_GET['maxPrice'];
$filter = $_GET['filter'];
$order = $_GET['order'];

$id = 1;
preg_match_all("/[^\r\n]+/", $inputString, $match, PREG_SPLIT_NO_EMPTY);
$inputArr = $match[0];
$products = [];

for ($i = 0; $i < count($inputArr); $i++) {
    $singleLine = preg_split("/\s*\|\s*/", $inputArr[$i], -1, PREG_SPLIT_NO_EMPTY);

    $currentProduct = new stdClass();

    $currentProduct->id = $id;
    $currentProduct->name = trim($singleLine[0]);
    $currentProduct->type = trim($singleLine[1]);
    $components = preg_split("/\s*\,\s*/", trim($singleLine[2]), -1, PREG_SPLIT_NO_EMPTY);
    $currentProduct->component = $components;
    $currentProduct->price = floatval($singleLine[3]);

    if (($currentProduct->type == $filter || $filter == "all") && ($currentProduct->price >= $minPrice && $currentProduct->price <= $maxPrice)) {
        $products[] = $currentProduct;
    }
    $id++;
}
usort($products, function ($A, $B) use ($order) {
    if ($A->price == $B->price) {
        return ($A->id < $B->id) ? -1 : 1;
    }
    return ($order == "ascending" ^ $A->price < $B->price) ? 1 : -1;
});
//var_dump($products);
foreach ($products as $product) {
    $currentName = htmlspecialchars($product->name);
    echo "<div class=\"product\" id=\"product" . $product->id . "\"><h2>" . $currentName . "</h2>";
    echo "<ul>";
    foreach ($product->component as $component) {
        $component = htmlspecialchars($component);
        echo "<li class=\"component\">" . $component . "</li>";

    }
    $number = number_format($product->price, 2, '.', '');
    echo "</ul><span class=\"price\">$number</span></div>";
}

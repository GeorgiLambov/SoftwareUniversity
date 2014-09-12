<?php
$inputStr = $_GET['priceList'];
$rowArr = preg_split("/<\/tr>/", $inputStr, -1, PREG_SPLIT_NO_EMPTY);
$resultByCategory = [];
for ($i = 1; $i < count($rowArr) - 1; $i++) {
    $line = $rowArr[$i];
    preg_match_all("/<td>\s*(.*?)\s*<\/td>/", $line, $match);

    $category = html_entity_decode($match[1][1]);

    $item = new stdClass();

    $item->product = html_entity_decode($match[1][0]);
    $item->price = html_entity_decode($match[1][2]);
    $item->currency = html_entity_decode($match[1][3]);

    $resultByCategory[$category][] = $item;
}
ksort($resultByCategory);

foreach ($resultByCategory as $category => $products) {

    usort($products, function ($s1, $s2) {
        return strcmp($s1->product, $s2->product); //strcmp — Двоично сигурно сравняване на низове
    }); //Връща < 0 ако str1 е по-малък от str2 ; > 0 ако str1 е по-голям от str2 , и 0 ако са равни.
    $resultByCategory[$category] = $products;
}

echo json_encode($resultByCategory);



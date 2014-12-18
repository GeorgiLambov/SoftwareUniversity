<?php

use Shapes\Data\Circle;
use Shapes\Data\Rectangle;

function __autoload($className) {
    $fileName = str_replace('\\', '/', $className);
    require_once("./" . $fileName . ".class.php");
}

$circle = new Circle(5.5, 10, 20);
echo $circle . "\r\n";

$rect = new Rectangle(-5, 20, 20, 30);
$rect->move(4, 5);
echo $rect . "\r\n";

$arr = [$circle, $rect];
foreach ($arr as $shape) {
    echo $shape . " -> area = " . $shape->calcArea() . "\r\n";
}

echo "Circle as JSON: " . $circle->toJSON() . "\r\n\r\n";

require_once("Shapes/Data/Functions.php");

use \Shapes\Data as d;

d\printMyName();

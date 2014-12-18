<?php

namespace Shapes\Data;

class Rectangle extends Shape
{
    private $width;
    private $height;

    function __construct($x, $y, $width, $height)
    {
        parent::__construct($x, $y);
        $this->width = $width;
        $this->height = $height;
    }

    function __toString()
    {
        return "Rect($this->x, $this->y, size: $this->width x $this->height)";
    }

    function calcArea()
    {
        return $this->width * $this->height;
    }

    final function example() {
        echo "I am not virtual";
    }
}

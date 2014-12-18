<?php

namespace Shapes\Data;

class Circle extends Shape
{
    private $radius;

    function __construct($x, $y, $radius)
    {
        parent::__construct($x, $y);
        $this->radius = $radius;
    }

    function __toString()
    {
        return "Circle($this->x, $this->y, r=$this->radius)";
    }

    function calcArea()
    {
        return $this->radius * $this->radius * M_PI;
    }
}

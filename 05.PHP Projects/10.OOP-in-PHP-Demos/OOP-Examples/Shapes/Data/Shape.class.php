<?php

namespace Shapes\Data;

/* @method toJSON
 * @method toXml
 */
abstract class Shape implements iMovable, iAreaCalculatable
{
    protected $x;
    protected $y;

    function __construct($x, $y)
    {
        $this->x = $x;
        $this->y = $y;
    }

    public function setX($x)
    {
        $this->x = $x;
    }

    public function getX()
    {
        return $this->x;
    }

    public function setY($y)
    {
        $this->y = $y;
    }

    public function getY()
    {
        return $this->y;
    }

    function move($deltaX, $deltaY)
    {
        $this->x += $deltaX;
        $this->y += $deltaY;
    }

    use \Shapes\Traits\JsonXmlTrait;
}

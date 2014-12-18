<?php

interface iMovable {
    function move($deltaX, $deltaY);
}

class GameObject implements iMovable  {
    private $id;
    private $x;
    private $y;

    function __construct($id, $x, $y) {
        $this->setId($id);
        $this->setX($x);
        $this->setY($y);
    }

    public function getId() {
        return $this->id;
    }

    public function setId($id) {
        $this->id = $id;
    }

    public function getX() {
        return $this->x;
    }

    public function setX($x) {
        $this->x = $x;
    }

    public function getY() {
        return $this->y;
    }

    public function setY($y) {
        $this->y = $y;
    }

    function move($deltaX, $deltaY)
    {
        $this->x += $deltaX;
        $this->y += $deltaY;
    }
}

class Player extends GameObject {
    private $name;

    function __construct($id, $x, $y, $name) {
        parent::__construct($id, $x, $y);
        $this->setName($name);
    }

    public function getName() {
        return $this->name;
    }

    public function setName($name) {
        $this->name = $name;
    }

    function __toString()
    {
        return "Player(" . $this->getName() . ", " . $this->getX() . ", " . $this->getY() . ")";
    }
}

$player = new Player(4, 20, 30, "Tanio");
echo "$player\r\n";
$player->move(100, 200);
echo "$player\r\n";

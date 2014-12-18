<?php

class Laptop {
    private $model;
    private $price;

    public function __construct($model, $price) {
        $this->setModel($model);
        $this->setPrice($price);
    }

    public function getModel() {
        return $this->model;
    }

    public function setModel($model) {
        $this->model = $model;
    }

    public function getPrice() {
        return $this->price;
    }

    public function setPrice($price) {
        $this->price = $price;
    }

    public function  __toString() {
        return $this->model . " - " . $this->price . "lv.";
    }
}

$laptop = new Laptop("Thinkpad T60", 320);
echo $laptop;

<?php

$numbers = array(4, 2, 1, 245, 39, 23, 0, 1);

$evenNums = array_filter($numbers, function($n) {
    //return $n % 2 == 0;
    return !($n & 1);
});

print_r($evenNums);

class Person {
    private $name;
    private $age;
    private $money;

    function __construct($name, $age, $money) {
        $this->name = $name;
        $this->age = $age;
        $this->money = $money;
    }

    public function getName() {
        return $this->name;
    }

    public function getAge() {
        return $this->age;
    }

    public function getMoney() {
        return $this->money;
    }
}

$people = array
(
    new Person("Misho", 22, 3600),
    new Person("Nacho", 40, 1200.50),
    new Person("Bai Lilcho", 80, 30)
);

$elderPeople =
    array_map(function($p) { return $p->getName(); },
        array_filter($people,
            function($p) { return $p->getAge() > 60; }
        )
    );

print_r($elderPeople);

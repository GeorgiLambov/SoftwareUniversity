<?php

namespace SoftUni;

function getBestStudent() {
    return "Pesho";
}

class Person {
    private $name;
    private $age;

    function __construct($name, $age)
    {
        $this->name = $name;
        $this->age = $age;
    }

    /**
     * @param integer $age
     */
    public function setAge($age)
    {
        $this->age = $age;
    }

    /**
     * @return integer
     */
    public function getAge()
    {
        return $this->age;
    }

    /**
     * @param string $name
     */
    public function setName($name)
    {
        $this->name = $name;
    }

    /**
     * @return string
     */
    public function getName()
    {
        return $this->name;
    }
}
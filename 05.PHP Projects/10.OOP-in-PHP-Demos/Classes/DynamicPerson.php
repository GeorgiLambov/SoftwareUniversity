<?php

class DynamicPerson
{
    private $props = ['name', 'age'];
    private $members = [];

    function __get($name)
    {
        if (in_array($name, $this->props)) {
            return $this->members[$name];
        } else {
            trigger_error("Invalid property: " . $name);
            return false;
        }
    }

    function __set($name, $value)
    {
        if (in_array($name, $this->props)) {
            $this->members[$name] = $value;
        } else {
            trigger_error("Invalid property: " . $name);
            return false;
        }
    }
}

$p = new DynamicPerson();
$p->name = "Nakov";
$p->age = 25;

var_dump($p);
<?php

class Person
{
    protected $name;
    protected $age;

    protected $errors = [];

    function __construct($name, $age)
    {
        $this->setName($name);
        $this->setAge($age);
    }

    public function setAge($age)
    {
        if ($age < 0 || $age > 120) {
            $this->errors["age"] = "Invalid age!";
            return false;

            // throw new InvalidArgumentException("Invalid age!");

            // trigger_error("Invalid age!", E_ERROR);
            // return false;

            // die("Invalid age!");
        }
        $this->age = $age;
    }

    function hasErrors()
    {
        return count($this->errors) > 0;
    }

    function getErrors()
    {
        return $this->errors;
    }

    public function getAge()
    {
        return $this->age;
    }

    public function setName($name)
    {
        $this->name = $name;
    }

    public function getName()
    {
        return $this->name;
    }

    function __toString()
    {
        return "Person($this->name, $this->age)";
    }
}

class Student extends Person
{
    private $grades;

    function __construct($name, $age, array $grades = [])
    {
        parent::__construct($name, $age);
        $this->grades = $grades;
    }

    function __toString()
    {
        $gradesStr = "[" . implode(", ", $this->grades) . "]";
        return "Student($this->name, $this->age, $gradesStr)";
    }

    function addGrade($grade)
    {
        $this->grades[] = $grade;
    }
}


$nakov = new Student("Nakov", -25);
$nakov->addGrade(6.00);
$nakov->addGrade(5.50);
echo "$nakov\r\n";

var_dump($nakov);

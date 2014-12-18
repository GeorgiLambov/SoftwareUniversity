<?php

namespace NASA;

require_once("Softuni.php");
use SoftUni as s;
use SoftUni\Person;

$bestStudent = s\getBestStudent();
echo $bestStudent;

$p = new Person("Peter", 22);
var_dump($p);


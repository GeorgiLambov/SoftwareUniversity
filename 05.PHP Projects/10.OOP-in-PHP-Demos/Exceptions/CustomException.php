<?php

class ENullArgumentException extends Exception {
    public function __construct($paramName) {
        parent::__construct("Argument cannot be null: $paramName", 101);
    }
}

class Customer {
    private $name;

    function getName() {
        return $this->name;
    }

    function setName($name) {
        if ($name == null)
            throw new ENullArgumentException('$name');
        else $this->name = $name;
    }
}

try {
    $customer = new Customer();
    $customer->setName(null);
} catch (ENullArgumentException $e) {
    echo $e->getMessage() . " (code: " . $e->getCode() . ")";
}

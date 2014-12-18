<?php

class AccountHolder {
    private $firstName;
    private $lastName;

    function __construct($firstName, $lastName) {
        $this->setFirstName($firstName);
        $this->setLastName($lastName);
    }

    public function getFirstName() {
        return $this->firstName;
    }

    public function setFirstName($firstName) {
        $this->firstName = $firstName;
    }

    public function getLastName() {
        return $this->lastName;
    }

    public function setLastName($lastName) {
        $this->lastName = $lastName;
    }
}

class Account {
    private $accountHolder;
    private $balance;

    function __construct($accountHolder, $balance) {
        $this->setAccountHolder($accountHolder);
        $this->setBalance($balance);
    }

    public function getAccountHolder() {
        return $this->accountHolder;
    }

    public function setAccountHolder($accountHolder) {
        $this->accountHolder = $accountHolder;
    }

    public function getBalance() {
        return $this->balance;
    }

    public function setBalance($balance) {
        $this->balance = $balance;
    }

    protected function accrueInterest($percent) {
        $balance = $this->getBalance();
        $newBalance = $balance + ($balance * $percent);
        $this->setBalance($newBalance);
    }
}

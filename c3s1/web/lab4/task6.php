<?php
    class User {
        protected $name;
        protected $age;

        public function setName($newName) {
            $this->name = $newName;
        }

        function __construct($name, $age) {
            $this->name = $name;
            $this->age = $age;
        }

        public function setAge($newName) {
            if ($this->_checkAge($newName)) {
                $this->age = $newName;
            }
        }

        public function getName() {
            return $this->name;
        }

        public function getAge() {
            return $this->age;
        }

        private function _checkAge($newAge) {
            return $newAge > 0 && $newAge < 100;
        }
    }

    class Worker extends User {
        private $salary;

        public function setSalary($newName) {
            $this->salary = $newName;
        }

        public function getSalary() {
            return $this->salary;
        }
    }

    enum Suit
    {
        case A;
        case B;
        case C;
    }

    class Driver extends Worker {
        private $expirience;
        private Suit $drive;

        public function setExpirience($newName) {
            $this->expirience = $newName;
        }

        public function getExpirience() {
            return $this->expirience;
        }

        public function setDrive(Suit $newName) {
            $this->drive = $newName;
        }

        public function getDrive() {
            return $this->drive;
        }
    }

    $w1 = new Worker("Иван", 25);
    $w1->setSalary(1000); 

    $w2 = new Worker("Вася", 26);
    $w2->setSalary(2000); 

    echo $w1->getSalary() + $w2->getSalary() . PHP_EOL;
?>
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

    class Student extends User {
        private $stipendia;
        private $course;

        public function setCousre($newName) {
            $this->course = $newName;
        }

        public function getCourse() {
            return $this->course;
        }

        public function setStipendia($newName) {
            $this->stipendia = $newName;
        }

        public function getStipendia() {
            return $this->stipendia;
        }
    }

    $w1 = new Worker("Иван", 25);
    $w1->setSalary(1000); 

    $w2 = new Worker("Вася", 26);
    $w2->setSalary(2000); 

    echo $w1->getSalary() + $w2->getSalary() . PHP_EOL;
?>
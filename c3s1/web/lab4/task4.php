<?php
    class Worker {
        private $name;
        private $age;
        private $salary;

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

        public function setSalary($newName) {
            $this->salary = $newName;
        }

        public function getName() {
            return $this->name;
        }

        public function getAge() {
            return $this->age;
        }

        public function getSalary() {
            return $this->salary;
        }

        private function _checkAge($newAge) {
            return $newAge > 0 && $newAge < 100;
        }
    }

    $w1 = new Worker("Иван", 25);
    $w1->setSalary(1000); 

    echo $w1->getAge() * $w1->getSalary() . PHP_EOL;
?>
<?php
    class Worker {
        private $name;
        private $age;
        private $salary;

        public function setName($newName) {
            $this->name = $newName;
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

    $w1 = new Worker();
    $w1->setName("Иван");
    $w1->SetAge(25);
    $w1->setSalary(1000); 
    
    $w2 = new Worker();
    $w2->setName("Вася");
    $w2->setAge(26);
    $w2->setSalary(2000);

    // 3 TASKSKSKSKK
    $w2->setAge(260);

    echo $w1->getAge() + $w2->getAge(). PHP_EOL;
    echo $w1->getSalary() + $w2->getSalary() . PHP_EOL;
?>
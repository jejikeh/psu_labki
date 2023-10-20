<?php

    class Worker {
        public $name;
        public $age;
        public $salary;
    }

    $w1 = new Worker();
    $w1->name = "Иван";
    $w1->age = 25;
    $w1->salary = 1000; 
    
    echo $w1->name . PHP_EOL;
    echo $w1->age . PHP_EOL;
    echo $w1->salary . PHP_EOL;

    $w2 = new Worker();
    $w2->name = "Вася";
    $w2->age = 26;
    $w2->salary = 2000;

    echo $w2->name . PHP_EOL;
    echo $w2->age . PHP_EOL;
    echo $w2->salary . PHP_EOL;
?>
<html>
    <?php 

        // 1
        echo "<h1>1</h1>";

        $sum = 0;
        for ($i = 1; $i <= 25; $i++) {
            $sum += $i;
        }
        
        echo "Сумма чисел от 1 до 25 (с использованием цикла for): $sum"."<br>";

        
        $sum = 0;
        $i = 1;

        while ($i <= 25) {
            $sum += $i;
            $i++;
        }

        echo "Сумма чисел от 1 до 25 (с использованием цикла while): $sum"."<br>";

        // 2
        // Ланцев Евгений
        // 11.10.2023


        // 3
        echo "<h1>3</h1>";

        $firstVariable = 3;
        $secondVariable = 5;
        $thirdVariable = 8;

        echo "Значение первой переменной: " . $firstVariable . "<br>";
        echo "Значение второй переменной: " . $secondVariable . "<br>";
        echo "Значение третьей переменной: " . $thirdVariable . "<br>";


        // 4
        echo "<h1>4</h1>";

        define("CONSTANT1", 41);
        define("CONSTANT2", 33);

        $sum = CONSTANT1 + CONSTANT2;

        echo "Сумма констант: " . $sum;

        // 5
        echo "<h1>5</h1>";

        $firstArray = array(1, 2, 3, 4, 5);
        $firstArray["element"] = 6;

        $secondArray = array(10, 20, 30, 40, 50);
        unset($secondArray[0]);

        // Выводим элементы под индексом 2 из первого и второго массива
        echo "Элемент с индексом 2 в первом массиве: " . $firstArray[2] . "<br>";
        echo "Элемент с индексом 2 во втором массиве: " . $secondArray[2] . "<br>";

        // Выводим содержимое массивов полностью
        echo "Содержимое первого массива: ";
        print_r($firstArray);
        echo "<br>";

        echo "Содержимое второго массива: ";
        print_r($secondArray);
        echo "<br>";

        echo "Количество элементов в первом массиве: " . count($firstArray) . "<br>";
        echo "Количество элементов во втором массиве: " . count($secondArray) . "<br>";


        // 6
        echo "<h1>6</h1>";

        $greeting = "Доброе утро";
        $ladies = "дамы";
        $andGentlemen = "и господа";
        $message = $greeting . ", " . $ladies . " " . $andGentlemen;

        echo $message;

    ?>
</html>
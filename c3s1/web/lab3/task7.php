<!DOCTYPE html>
<html>
<head>
    <title>Фильтр чисел</title>
</head>
<body>
    <h1>Фильтр чисел</h1>
    <form method="post">
        <label for="operation">Выберите операцию:</label>
        <select name="operation" id="operation">
            <option value="even">Четные</option>
            <option value="odd">Нечетные</option>
            <option value="prime">Простые</option>
            <option value="composite">Составные</option>
        </select>
        <br>
        <label for="n">Введите значение N:</label>
        <input type="number" name="n" id="n" required>
        <br>
        <input type="submit" value="Показать числа">
    </form>

    <?php
    if ($_SERVER["REQUEST_METHOD"] === "POST") {
        $operation = $_POST["operation"];
        $n = (int)$_POST["n"];

        for ($i = 1; $i <= $n; $i++) {
            if ($operation === "even" && $i % 2 == 0) {
                echo "$i ";
            } elseif ($operation === "odd" && $i % 2 != 0) {
                echo "$i ";
            } elseif ($operation === "prime" && isPrime($i)) {
                echo "$i ";
            } elseif ($operation === "composite" && !isPrime($i)) {
                echo "$i ";
            }
        }
    }

    function isPrime($number) {
        if ($number <= 1) {
            return false;
        }
        if ($number <= 3) {
            return true;
        }
        if ($number % 2 == 0 || $number % 3 == 0) {
            return false;
        }
        for ($i = 5; $i * $i <= $number; $i += 6) {
            if ($number % $i == 0 || $number % ($i + 2) == 0) {
                return false;
            }
        }
        return true;
    }
    ?>
</body>
</html>

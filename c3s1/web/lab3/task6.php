<!DOCTYPE html>
<html>
<head>
    <title>Проверка логина</title>
</head>
<body>
    <h1>Проверка логина</h1>
    <form method="post">
        <label for="login">Введите ваш логин: </label>
        <input type="text" name="login" id="login" required>
        <input type="submit" value="Проверить">
    </form>

    <?php
        $registeredLogins = array("user1", "user2", "user3", "user4");

        if ($_SERVER["REQUEST_METHOD"] === "POST") {
            $userLogin = isset($_POST["login"]) ? $_POST["login"] : "";

            if (in_array($userLogin, $registeredLogins)) {
                echo "Привет, $userLogin!";
            } else {
                echo "Логин $userLogin не найден. Попробуйте другой логин.";
            }
        }
    ?>
</body>
</html>

<!DOCTYPE html>
<html>
<head>
    <title>Форма авторизации</title>
</head>
<body>
    <?php
        $expectedLogin = "admin";
        $expectedPassword = "admin";
        
        $enteredLogin = "";
        $enteredPassword = "";
        
        $errorMessage = "";
        
        if ($_SERVER["REQUEST_METHOD"] == "POST") {
            $enteredLogin = $_POST["login"];
            $enteredPassword = $_POST["password"];
            
            if ($enteredLogin != $expectedLogin) {
                $errorMessage = "Введите логин admin";
            }

            if ($enteredPassword == $expectedPassword) {
                echo "Авторизация успешна. Добро пожаловать!";
            } else {
                $errorMessage = "Неверный логин или пароль. Попробуйте ещё раз.";
            }
        }
    ?>
    
    <h2>Форма авторизации</h2>
    <form method="post">
        <div>
            <label for="login">Логин:</label>
            <input type="text" name="login" id="login" value="<?php echo $enteredLogin; ?>">
        </div>
        <div>
            <label for="password">Пароль:</label>
            <input type="password" name="password" id="password">
        </div>
        <div>
            <input type="submit" value="Войти">
        </div>
    </form>
    
    <?php
        if (!empty($errorMessage)) {
            echo "<p style='color: red;'>$errorMessage</p>";
        }
    ?>
</body>
</html>

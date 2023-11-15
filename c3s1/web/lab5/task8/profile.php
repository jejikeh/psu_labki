<?php
session_start();

// Получение email из сессии
$userEmail = isset($_SESSION['user_email']) ? $_SESSION['user_email'] : '';

// Инициализация других данных профиля (имя, фамилия, пароль)
$firstName = 'John';
$lastName = 'Doe';
$password = '********'; // Здесь должно быть ваше безопасное хранение пароля
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>User Profile</title>
</head>
<body>
<h2>User Profile</h2>

<!-- Форма с автоматически заполненным полем email -->
<form>
    <label for="firstName">Имя:</label>
    <input type="text" id="firstName" name="firstName" value="<?php echo $firstName; ?>">
    <br>
    <label for="lastName">Фамилия:</label>
    <input type="text" id="lastName" name="lastName" value="<?php echo $lastName; ?>">
    <br>
    <label for="password">Пароль:</label>
    <input type="password" id="password" name="password" value="<?php echo $password; ?>">
    <br>
    <label for="email">Email:</label>
    <input type="email" id="email" name="email" value="<?php echo $userEmail; ?>" disabled>
</form>
</body>
</html>

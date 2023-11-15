<?php
session_start();

// Получение страны из сессии (если она была записана)
$userCountry = isset($_SESSION['user_country']) ? $_SESSION['user_country'] : 'Страна не выбрана';
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Test Page</title>
</head>
<body>
    <h2>Test Page</h2>
    <p>Страна пользователя: <?php echo $userCountry; ?></p>
    <p><a href="index.php">Вернуться на главную страницу</a></p>
</body>
</html>

<?php
session_start();

// Записываем время захода пользователя в сессию при первом посещении
if (!isset($_SESSION['login_time'])) {
    $_SESSION['login_time'] = time();
}

// Вычисляем разницу во времени
$secondsAgo = time() - $_SESSION['login_time'];
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Index Page</title>
</head>
<body>
<h2>Index Page</h2>

<p>Вы зашли на сайт <?php echo $secondsAgo; ?> секунд назад.</p>

<p><a href="index.php">Обновить страницу</a></p>
</body>
</html>

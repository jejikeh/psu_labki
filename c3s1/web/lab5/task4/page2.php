<?php
session_start();

// Получение сообщения из сессии
$userMessage = isset($_SESSION['user_message']) ? $_SESSION['user_message'] : 'Сообщение отсутствует';
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Page 2</title>
</head>
<body>
<h2>Page 2</h2>
<p>Ваше сообщение: <?php echo $userMessage; ?></p>
<p><a href="page1.php">Вернуться на страницу 1</a></p>
</body>
</html>

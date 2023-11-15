<?php
session_start();

// Обработка формы: если форма отправлена, сохраняем сообщение в сессии
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $userMessage = isset($_POST['user_message']) ? $_POST['user_message'] : '';
    $_SESSION['user_message'] = $userMessage;
    header('Location: page2.php');
    exit();
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Page 1</title>
</head>
<body>
<h2>Page 1</h2>
<form method="post">
    <label for="user_message">Введите ваше сообщение:</label>
    <input type="text" id="user_message" name="user_message" required>
    <button type="submit">Отправить</button>
</form>
</body>
</html>

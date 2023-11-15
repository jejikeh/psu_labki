<?php
session_start();

// Обработка формы на index.php
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $email = isset($_POST['email']) ? $_POST['email'] : '';

    // Проверка, что email был введен
    if (!empty($email)) {
        $_SESSION['user_email'] = $email;
        header('Location: profile.php');
        exit();
    }
}
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

<!-- Форма для ввода email -->
<form method="post">
    <label for="email">Введите ваш email:</label>
    <input type="email" id="email" name="email" required>
    <button type="submit">Отправить</button>
</form>
</body>
</html>

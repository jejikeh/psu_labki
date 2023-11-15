<?php
session_start();

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $email = isset($_POST['email']) ? $_POST['email'] : '';

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

<form method="post">
    <label for="email">Введите ваш email:</label>
    <input type="email" id="email" name="email" required>
    <button type="submit">Отправить</button>
</form>
</body>
</html>

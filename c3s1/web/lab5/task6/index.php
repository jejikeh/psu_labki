<?php
session_start();

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $country = isset($_POST['country']) ? $_POST['country'] : '';

    if (!empty($country)) {
        $_SESSION['user_country'] = $country;
    }
}

$userCountry = isset($_SESSION['user_country']) ? $_SESSION['user_country'] : '';
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

    <?php if (empty($userCountry)): ?>
        <form method="post">
            <label for="country">Введите вашу страну:</label>
            <input type="text" id="country" name="country" required>
            <button type="submit">Отправить</button>
        </form>
    <?php else: ?>
        <p>Вы выбрали страну: <?php echo $userCountry; ?></p>
        <p><a href="test.php">Перейти на страницу Test</a></p>
    <?php endif; ?>
</body>
</html>

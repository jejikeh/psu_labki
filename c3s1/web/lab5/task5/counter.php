<?php
session_start();

if (!isset($_SESSION['page_refresh_count'])) {
    $_SESSION['page_refresh_count'] = 0;
}

$_SESSION['page_refresh_count']++;

$pageRefreshCount = $_SESSION['page_refresh_count'];
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Page Refresh Counter</title>
</head>
<body>
    <h2>Page Refresh Counter</h2>
    <?php if ($pageRefreshCount == 1): ?>
        <p>Вы еще не обновляли страницу.</p>
    <?php else: ?>
        <p>Вы обновили страницу <?php echo $pageRefreshCount-1; ?> раз(а).</p>
    <?php endif; ?>
</body>
</html>

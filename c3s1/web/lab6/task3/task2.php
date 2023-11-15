<?php
$folderPath = 'test';

$files = glob($folderPath . '/*.*');

foreach ($files as $file) {
    $fileSize = filesize($file);

    if ($fileSize > 1024 * 1024) {
        unlink($file);
        echo "Файл $file удален, так как его размер больше 1 МБ<br>";
    }
}
?>

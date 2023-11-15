<?php
$folderPath = 'test';

// Получаем список файлов в папке
$files = glob($folderPath . '/*.*');

foreach ($files as $file) {
    // Получаем размер файла в байтах
    $fileSize = filesize($file);

    // Если размер файла больше 1 МБ (в байтах)
    if ($fileSize > 1024 * 1024) {
        unlink($file);
        echo "Файл $file удален, так как его размер больше 1 МБ<br>";
    }
}
?>

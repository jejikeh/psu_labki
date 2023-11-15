<?php
$folderPath = 'test';

// Получаем список файлов в папке
$files = glob($folderPath . '/*.html');

foreach ($files as $file) {
    // Читаем содержимое файла
    $content = file_get_contents($file);

    // Ищем тег h1 и его текст
    preg_match('/<h1>(.*?)<\/h1>/', $content, $matches);

    // Если тег h1 найден, переименовываем файл
    if (!empty($matches[1])) {
        $newFileName = $folderPath . '/' . $matches[1] . '.html';
        rename($file, $newFileName);
        echo "Файл $file переименован в $newFileName<br>";
    }
}

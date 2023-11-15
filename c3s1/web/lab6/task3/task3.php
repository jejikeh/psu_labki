<?php
$folderPath = './test';

// Получаем размер папки в байтах
$folderSize = folderSize($folderPath);

echo "Размер папки $folderPath: " . formatSize($folderSize) . "<br>";

// Функция для рекурсивного подсчета размера папки
function folderSize($dir)
{
    $size = 0;
    foreach (glob(rtrim($dir, '/') . '/*', GLOB_NOSORT) as $each) {
        $size += is_file($each) ? filesize($each) : folderSize($each);
    }
    return $size;
}

// Функция для форматирования размера в более читаемый вид
function formatSize($size)
{
    $units = ['B', 'KB', 'MB', 'GB', 'TB'];
    for ($i = 0; $size >= 1024 && $i < 4; $i++) {
        $size /= 1024;
    }
    return round($size, 2) . ' ' . $units[$i];
}
?>

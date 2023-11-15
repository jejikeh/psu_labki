<?php
$folderPath = 'test';

$files = glob($folderPath . '/*.html');

foreach ($files as $file) {
    $content = file_get_contents($file);

    preg_match('/<h1>(.*?)<\/h1>/', $content, $matches);

    if (!empty($matches[1])) {
        $newFileName = $folderPath . '/' . $matches[1] . '.html';
        rename($file, $newFileName);
        echo "Файл $file переименован в $newFileName<br>";
    }
}

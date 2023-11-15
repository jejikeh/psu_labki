<?php
try {
    $filename = 'example.txt';

    if (file_exists($filename)) {
        unlink($filename);
        echo "Файл $filename был успешно удален.";
    } else {
        throw new Exception("Файл $filename не существует.");
    }
} catch (Exception $e) {
    echo 'Произошла ошибка: ' . $e->getMessage();
}
<?php

if ($_SERVER["REQUEST_METHOD"] === "POST") {
    // Получаем введенное пользователем название файла
    $fileName = $_POST["fileName"];

    // Проверяем, что введено название файла
    if (empty($fileName)) {
        die("Please enter a filename.");
    }

    // Составляем путь к файлу
    $filePath = __DIR__ . "/{$fileName}.php";

    // Проверяем существование файла
    if (!file_exists($filePath)) {
        die("File does not exist.");
    }

    // Используем include или require в зависимости от вашего случая
    require_once $filePath;

}

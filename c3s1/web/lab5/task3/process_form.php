<?php

if ($_SERVER["REQUEST_METHOD"] === "POST") {
    $fileName = $_POST["fileName"];

    if (empty($fileName)) {
        die("Please enter a filename.");
    }

    $filePath = __DIR__ . "/{$fileName}.php";

    if (!file_exists($filePath)) {
        die("File does not exist.");
    }

    require_once $filePath;

}

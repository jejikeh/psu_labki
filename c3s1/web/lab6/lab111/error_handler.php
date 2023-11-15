<?php

require_once 'vendor/autoload.php';

$whoops = new \Whoops\Run();
$handler = new \Whoops\Handler\PrettyPageHandler();

// Включение подсветки синтаксиса
$handler->setEditor(function ($file, $line) {
    return 'phpstorm://open?file=' . $file . '&line=' . $line;
});

$whoops->pushHandler($handler);

// Включение Whoops для обработки ошибок и исключений
$whoops->register();

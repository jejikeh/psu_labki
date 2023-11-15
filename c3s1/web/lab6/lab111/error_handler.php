<?php

require_once 'vendor/autoload.php';

$whoops = new \Whoops\Run();
$handler = new \Whoops\Handler\PrettyPageHandler();

$handler->setEditor(function ($file, $line) {
    return 'phpstorm://open?file=' . $file . '&line=' . $line;
});

$whoops->pushHandler($handler);

$whoops->register();

<?php

$environment = getenv('PROJECT_PHP_SERVER');

if (empty($environment) || !in_array($environment, ['development', 'production'])) {
    $environment = 'default';
}

$configPath = __DIR__ . "/config/{$environment}/";

$config = [];

function loadConfigFiles($path, &$config)
{
    $files = glob($path . '*.php');

    foreach ($files as $file) {
        $configChunk = include $file;

        $config = array_merge($config, $configChunk);
    }
}

loadConfigFiles(__DIR__ . '/config/default/', $config);

loadConfigFiles($configPath, $config);

?>
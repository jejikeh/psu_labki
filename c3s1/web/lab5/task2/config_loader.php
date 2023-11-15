<?php

// Определение окружения на основе переменной PROJECT_PHP_SERVER
$environment = getenv('PROJECT_PHP_SERVER');

// Если переменная не установлена или установлена неверно, используем "default"
if (empty($environment) || !in_array($environment, ['development', 'production'])) {
    $environment = 'default';
}

// Путь к папке с конфигурацией
$configPath = __DIR__ . "/config/{$environment}/";

// Массив для хранения конфигурации
$config = [];

// Функция для загрузки конфигурационных файлов из папки
function loadConfigFiles($path, &$config)
{
    $files = glob($path . '*.php');

    foreach ($files as $file) {
        $configChunk = include $file;

        // Перетираем соответствующие пункты в $config
        $config = array_merge($config, $configChunk);
    }
}

// Загрузка файлов из папки default
loadConfigFiles(__DIR__ . '/config/default/', $config);

// Загрузка файлов из папки окружения (development или production)
loadConfigFiles($configPath, $config);

// Теперь $config содержит собранную конфигурацию
//var_dump($config);

?>
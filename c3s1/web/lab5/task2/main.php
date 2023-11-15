<?php
global $config;
putenv('PROJECT_PHP_SERVER=development');

require_once 'config_loader.php';

// Пример использования конфигурационных данных
echo "<p>Database Host: " . $config['db_host'] . "</p>\n";
echo "<p>Database Username: " . $config['db_username'] . "</p>\n";
echo "<p>Database Password: " . $config['db_password'] . "</p>\n";
echo "<p>Database Name: " . $config['db_name'] . "</p>\n";
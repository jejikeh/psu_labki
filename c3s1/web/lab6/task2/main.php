<?php
// Получение номера удаляемой строки из параметров запроса
$lineToDelete = isset($_GET['line']) ? (int)$_GET['line'] : 0;

// Вывод номера удаляемой строки
echo "Удаляем строку номер $lineToDelete<br>";

// Пути к исходному и новому файлам
$sourceFile = 'source.txt';
$newFile = 'newfile.txt';

// Открытие исходного файла в режиме чтения
$sourceHandle = fopen($sourceFile, 'r');

if ($sourceHandle) {
    // Открытие нового файла в режиме дозаписи
    $newHandle = fopen($newFile, 'a');

    if ($newHandle) {
        // Чтение исходного файла построчно
        $currentLine = 0;
        while (($buffer = fgets($sourceHandle)) !== false) {
            $currentLine++;

            // Если номер текущей строки не совпадает с номером удаляемой строки, записываем ее в новый файл
            if ($currentLine !== $lineToDelete) {
                fwrite($newHandle, $buffer);
            }
        }

        // Закрытие файлов
        fclose($sourceHandle);
        fclose($newHandle);

        // Удаление исходного файла
        unlink($sourceFile);

        // Переименование нового файла в имя исходного файла
        rename($newFile, $sourceFile);

        // Открытие нового файла в режиме чтения и вывод его содержимого
        $newHandle = fopen($sourceFile, 'r');
        if ($newHandle) {
            echo "Содержимое нового файла после удаления строки:<br>";
            while (($buffer = fgets($newHandle)) !== false) {
                echo $buffer;
            }
            fclose($newHandle);
        } else {
            echo "Не удалось открыть новый файл для чтения.";
        }
    } else {
        echo "Не удалось открыть новый файл для записи.";
    }
} else {
    echo "Не удалось открыть исходный файл для чтения.";
}
?>

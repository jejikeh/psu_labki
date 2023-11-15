<?php
$lineToDelete = isset($_GET['line']) ? (int)$_GET['line'] : 0;

echo "Удаляем строку номер $lineToDelete<br>";

$sourceFile = 'source.txt';
$newFile = 'newfile.txt';

$sourceHandle = fopen($sourceFile, 'r');

if ($sourceHandle) {
    $newHandle = fopen($newFile, 'a');

    if ($newHandle) {
        $currentLine = 0;
        while (($buffer = fgets($sourceHandle)) !== false) {
            $currentLine++;

            if ($currentLine !== $lineToDelete) {
                fwrite($newHandle, $buffer);
            }
        }

        fclose($sourceHandle);
        fclose($newHandle);

        unlink($sourceFile);

        rename($newFile, $sourceFile);

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

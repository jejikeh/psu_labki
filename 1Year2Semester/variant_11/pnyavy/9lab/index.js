const readline = require("readline");

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

const array1 = [];
const array3 = [];
const array2 = [];

function getRandomInt(min, max) {
  return Math.floor(Math.random() * (max - min) + min);
}

for (let i = 0; i < 20; i++) {
  array1.push(getRandomInt(-10, 10));
  array2.push(getRandomInt(-10, 10));
  array3.push(getRandomInt(-10, 10));
}

function getAverage(array) {
  let sum = 0;
  for (let i = 0; i < 20; i++) {
    sum += array[i];
  }
  return sum / 20;
}
// 5 3 1 8 -5 -1
// 8 5 3 1 -1 -5

function swap(array, x, y) {
  let temp = array[y];
  array[y] = array[x];
  array[x] = temp;
}

function sortArray(array) {
  for (let i = 0; i < 20; i++) {
    for (let k = 0; k < 20; k++) {
      if (array[i] > array[k]) {
        swap(array, i, k);
      }
    }
  }
  return array;
}

let averageArray1 = getAverage(array1);
let averageArray2 = getAverage(array2);
let averageArray3 = getAverage(array3);

if (averageArray1 > averageArray2 && averageArray1 > averageArray3) {
  console.log(
    `Задание 1 -> Массив у которого среднее арифметическое значение максимально это 1 массив, и максимальное среднее арифмитеческое равно ${averageArray1}`
  );
} else if (averageArray2 > averageArray1 && averageArray2 > averageArray3) {
  console.log(
    `Задание 1 -> Массив у которого среднее арифметическое значение максимально это 2 массив, и максимальное среднее арифмитеческое равно ${averageArray2}`
  );
} else {
  console.log(
    `Задание 1 -> Массив у которого среднее арифметическое значение максимально это 3 массив, и максимальное среднее арифмитеческое равно ${averageArray3}`
  );
}

function task() {
  rl.question("\nЗадание 2 -> \nКакой массив отсортировать : ", (x) => {
    if (x == 1) {
      console.log(`Массив до сортировки : ${array1}`);
      console.log(`Массив после сортировки : ${sortArray(array1)}`);
      task();
    }
    if (x == 2) {
      console.log(`Массив до сортировки : ${array2}`);
      console.log(`Массив после сортировки : ${sortArray(array2)}`);
      task();
    }
    if (x == 3) {
      console.log(`Массив до сортировки : ${array3}`);
      console.log(`Массив после сортировки : ${sortArray(array3)}`);
      task();
    } else {
      task();
    }
  });
}
task();

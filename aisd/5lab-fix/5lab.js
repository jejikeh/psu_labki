const readline = require("readline");
//
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

let x = 0;
function tasks() {}

class Node {
  // узел бинарного дерева
  constructor(data) {
    this.data = data;
    this.children = [];
  }
}
class Tree {
  // класс дерева
  constructor(data) {
    this.root = new Node(data); // корневой узел
  }
  add(data, currentNode) {
    // произвольное заполнение
    if (currentNode.children.length == 0) {
      console.log(`Добавление узла ${data} к узлу ${currentNode.data}`);
      currentNode.children.push(new Node(data, currentNode));
      tasks();
    } else if (currentNode.children.length == 1) {
      rl.question(
        `Выберете к какому элементу добавить узел, к ${currentNode.children[0].data} ( 0 - ребенок ) или ${currentNode.data} ( 1 - к самому себе) : `,
        (index) => {
          if (index == 0) {
            this.add(data, currentNode.children[index]);
          } else if (index == 1) {
            currentNode.children.push(new Node(data, currentNode));
            tasks();
          } else {
            tasks();
          }
        }
      );
    } else if (currentNode.children.length == 2) {
      rl.question(
        `Выберете к какому элементу добавить узел, к ${currentNode.children[0].data} ( 0 - левый ) или ${currentNode.children[1].data} ( 1 - правый) : `,
        (index) => {
          if (index < 2) {
            this.add(data, currentNode.children[index]);
          } else {
            tasks();
          }
        }
      );
    }
  }
  display(currentNode) {
    console.log("-------");
    console.log("Корень : " + currentNode.data);
    for (let i = 0; i < currentNode.children.length; i++) {
      console.log("Ребенок : " + currentNode.children[i].data);
    }
    for (let i = 0; i < currentNode.children.length; i++) {
      this.display(currentNode.children[i]);
    }
  }

  find(data, currentNode) {
    if (currentNode.data != data) {
      for (let i = 0; i < currentNode.children.length; i++) {
        this.find(data, currentNode.children[i]);
      }
    } else {
      for (let i = 0; i < currentNode.children.length; i++) {
        this.find(data, currentNode.children[i]);
      }
      console.log(currentNode);
    }
    //console.log(currentNode.data);
  }
  delete(data, currentNode) {
    if (currentNode != null) {
    }
  }
}
let task = 0;
let trees;

let allTreeElements = []; // Все элементы массива
let allUniqueTreeElements = []; // Все элементы массива по одному экземпляру. Елси, к примеру, в дереве присуствует два раза ( 1 ), то в данном массиве ( 1 ) будет только одна
function tasks() {
  task = 0;
  if (trees == null) {
    rl.question("\nИнициализировать дерево : ", (data) => {
      trees = new Tree(data);
      allTreeElements.push(data); // Представление всех элементов дерева как массив
      allUniqueTreeElements.push(data); // Представление всех элементов дерева максимум в одном экземпляре   как массив
      tasks();
    });
  }
  rl.question(
    "\n1-Добавить узел\n2-Вывести дерево\n3-Найти узел\n4-Найти повторяющиеся элементы\n5-Удалить элемент\nВыберите задание : ",
    (task) => {
      if (task == 1) {
        rl.question("\nДобавить узел : ", (data) => {
          trees.add(data, trees.root);
          allTreeElements.push(data);
          if (allUniqueTreeElements.indexOf(data) == -1) {
            // если нет в массиве, то добавляем в уникальные элементы
            allUniqueTreeElements.push(data); // Представление всех уникальных элементов дерева как массив
          }
          tasks();
        });
      } else if (task == 2) {
        trees.display(trees.root);
        tasks();
      } else if (task == 3) {
        // Инициализировать массив который будет добовлять уже проверенные элементы, и если они там есть то просто их не проверять
        rl.question("\nВведите элемент который нужно найти : ", (data) => {
          trees.find(data, trees.root);
          x = 0;
          tasks();
        });
      } else if (task == 4) {
        for (let i = 0; i < allUniqueTreeElements.length; i++) {
          let repeated_times = 0;
          // каждый уникальный элемент проверяем на повторения
          for (let k = 0; k < allTreeElements.length; k++) {
            if (allTreeElements[k] == allUniqueTreeElements[i]) {
              repeated_times++;
            }
          }
          if (repeated_times > 1) {
            console.log(
              `Элемент ${allUniqueTreeElements[i]} встречается в дереве ${repeated_times} раз`
            );
          }
        }

        tasks();
      } else if (task == 5) {
        // Инициализировать массив который будет добовлять уже проверенные элементы, и если они там есть то просто их не проверять
        rl.question("\nВведите элемент который нужно удалить : ", (data) => {
          trees.delete(data, trees.root);
          x = 0;
          tasks();
        });
      } else {
        tasks();
      }
    }
  );
}

tasks();

/* eslint-disable no-use-before-define */
/* eslint-disable eqeqeq */
/* eslint-disable no-param-reassign */
/* eslint-disable max-classes-per-file */
const readline = require("readline");

const rl = readline.createInterface({
  // конструктор ввода\вывода
  input: process.stdin,
  output: process.stdout,
});

function tasks() {} // объявление функции выбора задания

class Node {
  // узел бинарного дерева
  constructor(data, left, right, parent) {
    this.data = data; // атрибуты
    this.left = left;
    this.right = right;
    this.parent = parent;
  }
}
// fix guthub
let trees = null;
class Tree {
  constructor(data) {
    this.root = new Node(data, null, null, null);
  }

  add(data, currentNode) {
    // выбор к какому прибавить, идем от корня
    rl.question("\nLEFT OR RIGHT : ", (next) => {
      if (next == "right") {
        // если выбор (справа)
        if (currentNode.right != null) {
          // если  есть узел то идем дальше
          console.log(`\n CURRENT NODE : ${currentNode.right.data}`);
          this.add(data, currentNode.right);
        } else {
          // если нет справа то создаем
          const newNode = new Node(data, null, null, currentNode);
          currentNode.right = newNode;
          tasks();
        }
      } else if (next == "left") {
        if (currentNode.left != null) {
          // если  есть узел то идем дальше
          console.log(`\n CURRENT NODE : + ${currentNode.left.data}`);
          this.add(data, currentNode.left);
        } else {
          const newNode = new Node(data, null, null, currentNode);
          currentNode.left = newNode;
          tasks();
        }
      } else {
        console.log("\nleft or right");
        this.add(data, currentNode);
      }
      return 0;
    });
  }

  display(currentNode) {
    if (currentNode.right != null && currentNode.left != null) {
      console.log(
        `\n${currentNode.left.data} <- ${currentNode.data} -> ${currentNode.right.data}`
      );
      rl.question("\nCHOOSE WAY : ", (way) => {
        if (way == "right" || way == currentNode.right.data) {
          this.display(currentNode.right);
        } else if (way == "left" || way == currentNode.left.data) {
          this.display(currentNode.left);
        } else if (way == currentNode.data && currentNode.parent != null) {
          console.log(`\nBACK TO NODE : ${currentNode.parent.data}`);
          this.display(currentNode.parent);
        } else if (way == -1) {
          tasks();
        } else {
          this.display(currentNode);
        }
        return 0;
      });
    } else if (currentNode.right == null && currentNode.left != null) {
      console.log(`\n${currentNode.left.data} <- ${currentNode.data} -> NULL`);
      rl.question("\nCHOOSE WAY : ", (way) => {
        if (way == "right") {
          console.log("\nright is empty");
          this.display(currentNode);
        } else if (way == "left" || way == currentNode.left.data) {
          this.display(currentNode.left);
        } else if (way == currentNode.data && currentNode.parent != null) {
          console.log(`\nBACK TO NODE : ${currentNode.parent.data}`);
          this.display(currentNode.parent);
        } else if (way == -1) {
          tasks();
        } else {
          this.display(currentNode);
        }
        return 0;
      });
    } else if (currentNode.right != null && currentNode.left == null) {
      console.log(`\nNULL <- ${currentNode.data} -> ${currentNode.right.data}`);
      rl.question("\n : ", (way) => {
        if (way == "right" || way == currentNode.right.data) {
          this.display(currentNode.right);
        } else if (way == "left") {
          console.log("\nleft is empty");
          this.display(currentNode);
        } else if (way == currentNode.data && currentNode.parent != null) {
          console.log(`\nBACK TO NODE : ${currentNode.parent.data}`);
          this.display(currentNode.parent);
        } else if (way == -1) {
          tasks();
        } else {
          this.display(currentNode);
        }
        return 0;
      });
    } else if (currentNode.right == null && currentNode.left == null) {
      console.log("\nКонец дерева....");
      if (currentNode.parent == null) {
        console.log(`NULL <- ${currentNode.data} -> NULL`);
      } else {
        this.display(currentNode.parent);
      }
    }
    return 0;
  }

  min(node) {
    if (node.left == null) return node;
    return this.findMin(node.left);
  }

  deleteRES(currentNode, index) {
    if (currentNode != null && currentNode.left != null) {
      this.deleteRES(currentNode.left, index);
    } else if (currentNode != null && currentNode.data == index) {
      console.log("Найдено!!");
      console.log(currentNode.parent.data);
      currentNode.parent.left = null;
      currentNode = null;
      tasks();
    } else {
      console.log("\nНе найдено");
    }
    if (currentNode != null && currentNode.right != null) {
      this.deleteRES(currentNode.right, index);
    } else if (currentNode != null && currentNode.data == index) {
      console.log("Найдено!!");
      console.log(currentNode.parent.data);
      currentNode.parent.right = null;
      currentNode.data = "NULL";
      tasks();
    } else {
      console.log("\nНе найдено");
    }
    if (currentNode != null) {
      if (currentNode.left == null && currentNode.right) {
        console.log("\nУзел не существует");
      }
    }
  }
}

let allTreeElements = []; // Все элементы массива
let allUniqueTreeElements = []; // Все элементы массива по одному экземпляру. Елси, к примеру, в дереве присуствует два раза ( 1 ), то в данном массиве ( 1 ) будет только одна

/* eslint-disable-next-line */
function tasks() {
  if (trees == null) {
    rl.question("\nADD ROOT : ", (data) => {
      trees = new Tree(data);
      allTreeElements.push(data); // Представление всех элементов дерева как массив
      allUniqueTreeElements.push(data); // Представление всех элементов дерева максимум в одном экземпляре   как массив
      tasks();
    });
  }
  rl.question(
    "\n1-Добавить узел\n2-Вывод дерева\n3-Удалить элемент\n4-Найти повторяющиеся элементы\nВыберите задание : ",
    (task) => {
      if (task == 1) {
        rl.question("Добавить узел : ", (data) => {
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
        rl.question("\nУдалить : ", (x) => {
          const index = allTreeElements.indexOf(x);
          const uniqueIndex = allUniqueTreeElements.indexOf(x);
          if (index > -1) {
            allTreeElements.splice(index, 1);
            allUniqueTreeElements.splice(uniqueIndex, 1);
          }
          trees.deleteRES(trees.root, x);
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
      } else {
        tasks();
      }
    }
  );
}
tasks();

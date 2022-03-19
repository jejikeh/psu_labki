const readline = require("readline");

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

function tasks() {}

class Node {
  constructor(data, parent) {
    this.data = data;
    this.parent = parent;
    this.children = [];
  }
}

class Tree {
  constructor(data) {
    this.root = new Node(data, null);
  }
  add(data, currentNode, index) {
    if (index == null) {
      rl.question("\nCHOOSE ROOT ELEMENT -> ", (index) => {
        if (index != currentNode.data) {
          for (let i = 0; i < currentNode.children.length; i++) {
            this.add(data, currentNode.children[i], index);
          }
        } else {
          currentNode.children.push(new Node(data, currentNode));
          tasks();
        }
      });
    } else {
      if (index != currentNode.data) {
        for (let i = 0; i < currentNode.children.length; i++) {
          this.add(data, currentNode.children[i], index);
        }
      } else {
        currentNode.children.push(new Node(data, currentNode));
        tasks();
      }
    }
  }
  display(currentNode) {
    console.log("-------");
    console.log("ROOT : " + currentNode.data);
    for (let i = 0; i < currentNode.children.length; i++) {
      console.log("CHILDREN : " + currentNode.children[i].data);
    }
    for (let i = 0; i < currentNode.children.length; i++) {
      this.display(currentNode.children[i]);
    }
  }
}
let task = 0;
let trees;

function tasks() {
  task = 0;
  if (trees == null) {
    rl.question("\nADD ROOT : ", (data) => {
      trees = new Tree(data);
      tasks();
    });
  }
  rl.question("\n1-ADD NODE\n2-LIST TREE\nCHOOSE TASK : ", (task) => {
    if (task == 1) {
      rl.question("\nADD NODE : ", (data) => {
        trees.add(data, trees.root);
        tasks();
      });
    } else if (task == 2) {
      trees.display(trees.root);
      tasks();
    } else {
      tasks();
    }
  });
}

tasks();

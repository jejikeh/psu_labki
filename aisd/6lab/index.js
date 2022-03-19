/* eslint-disable no-use-before-define */
/* eslint-disable eqeqeq */
/* eslint-disable no-param-reassign */
/* eslint-disable max-classes-per-file */
const readline = require('readline');

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
});

function tasks() {}

class Node {
    constructor(data, left, right, parent) {
        this.data = data;
        this.left = left;
        this.right = right;
        this.parent = parent;
        this.checked = false;
    }
}

let trees = null;
class Tree {
    constructor(data) {
        this.root = new Node(data, null, null, null);
    }

    add(data, currentNode) {
        rl.question('\nLEFT OR RIGHT : ', (next) => {
            if (next == 'right') {
                if (currentNode.right != null) {
                    // если справа есть то идем дальше
                    console.log(`\n CURRENT NODE : ${currentNode.right.data}`);
                    this.add(data, currentNode.right);
                } else {
                    // если нет справа то создаем
                    const newNode = new Node(data, null, null, currentNode);
                    currentNode.right = newNode;
                    tasks();
                }
            } else if (next == 'left') {
                if (currentNode.left != null) {
                    console.log(`\n CURRENT NODE : + ${currentNode.left.data}`);
                    this.add(data, currentNode.left);
                } else {
                    const newNode = new Node(data, null, null, currentNode);
                    currentNode.left = newNode;
                    tasks();
                }
            } else {
                console.log('\nleft or right');
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
            rl.question('\nCHOOSE WAY : ', (way) => {
                if (way == 'right' || way == currentNode.right.data) {
                    this.display(currentNode.right);
                } else if (way == 'left' || way == currentNode.left.data) {
                    this.display(currentNode.left);
                } else if (
                    way == currentNode.data &&
                    currentNode.parent != null
                ) {
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
            console.log(
                `\n${currentNode.left.data} <- ${currentNode.data} -> NULL`
            );
            rl.question('\nCHOOSE WAY : ', (way) => {
                if (way == 'right') {
                    console.log('\nright is empty');
                    this.display(currentNode);
                } else if (way == 'left' || way == currentNode.left.data) {
                    this.display(currentNode.left);
                } else if (
                    way == currentNode.data &&
                    currentNode.parent != null
                ) {
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
            console.log(
                `\nNULL <- ${currentNode.data} -> ${currentNode.right.data}`
            );
            rl.question('\nCHOOSE WAY : ', (way) => {
                if (way == 'right' || way == currentNode.right.data) {
                    this.display(currentNode.right);
                } else if (way == 'left') {
                    console.log('\nleft is empty');
                    this.display(currentNode);
                } else if (
                    way == currentNode.data &&
                    currentNode.parent != null
                ) {
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
            console.log('\nTHIS IS THE END OF TREE....');
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
            console.log('FIND!!');
            console.log(currentNode.parent.data);
            currentNode.parent.right = null;
            currentNode = null;

            tasks();
        } else {
            console.log('\nNOT FIND');
        }
        if (currentNode != null && currentNode.right != null) {
            this.deleteRES(currentNode.right, index);
        } else if (currentNode != null && currentNode.data == index) {
            console.log('FIND!!');
            console.log(currentNode.parent.data);
            currentNode.parent.left = null;
            tasks();
        } else {
            console.log('\nNOT FIND');
        }
        if (currentNode != null) {
            if (currentNode.left == null && currentNode.right) {
                console.log('\nITEM DOES NOT EXIST');
            }
        }
    }
}

/* eslint-disable-next-line */
function tasks() {
    if (trees == null) {
        rl.question('\nADD ROOT : ', (data) => {
            trees = new Tree(data);
            tasks();
        });
    }
    rl.question(
        '\n1-ADD NODE\n2-LIST TREE\n3-REMOVE ELEMENT\nCHOOSE TASK : ',
        (task) => {
            if (task == 1) {
                rl.question('\nADD NODE : ', (data) => {
                    trees.add(data, trees.root);
                    tasks();
                });
            } else if (task == 2) {
                trees.display(trees.root);
                tasks();
            } else if (task == 3) {
                rl.question('\nREMOVE : ', (x) => {
                    trees.deleteRES(trees.root, x);
                    tasks();
                });
            } else {
                tasks();
            }
        }
    );
}

tasks();

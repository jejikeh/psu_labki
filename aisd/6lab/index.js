/* eslint-disable no-use-before-define */
/* eslint-disable eqeqeq */
/* eslint-disable no-param-reassign */
/* eslint-disable max-classes-per-file */
const readline = require('readline');

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
});

class Node {
    constructor(data) {
        this.data = data;
        this.height = 1;
        this.left = 0;
        this.right = 0;
    }
}

function Height(node) {
    if (node) return node.height;
    else return 0;
}

function BF(node) {
    return Height(node.right) - Height(node.left);
}

function OverHeight(node) {
    height_left = Height(node.left);
    height_right = Height(node.right);
    node.height = hleft > height_right ? hleft : height_right;
}

function RightRotation(node) {
    y = node.left;
    y.left = x.right;
    y.right = node;
    OverHeight(node);
    OverHeight(y);
    return y;
}

function LeftRotation(node) {
    y = node.right;
    y.right = x.left;
    y.left = node;
    OverHeight(node);
    OverHeight(y);
    return y;
}

function Balance(node) {
    OverHeight(node);
    if (BF(node) == 2) {
        if (BF(node.right) < 0) {
            node.right = RightRotation(node.right);
        }
        return LeftRotation(node);
    }
    if (BF(node) == -2) {
        if (BF(node.left) > 0) {
            node.left = LeftRotation(node.left);
        }
        return RightRotation(node);
    }
    return node;
}

function Insert(node, data) {
    if (!node) return Node(data);
    if (data < node.data) {
        node.left = Insert(node.left, data);
    } else {
        node.right = Insert(node.right, data);
    }
    return Balance(node);
}

function SearchMin(node) {
    return node.left ? SearchMin(node.left) : node;
}

function DeleteMin(node) {
    if (node.left == 0) return node.right;
    node.left = DeleteMin(node.left);
    return Balance(node);
}

function Delete(node, data) {
    if (!node) return 0;
    if (data < node.data) {
        data.left = Delete(data.left, data);
    } else if (data > node.data) {
        data.right = Delete(x.right, data);
    } else {
        y = node.left;
        z = node.right;
        delete node;
        if (!z) return y;
        min = SearchMin(z);
        min.right = DeleteMin(z);
        min.left = y;
        return Balance(min);
    }
    return Balance(data);
}

root = new Node(2);
console.log(Height(root));
console.log(BF(root));

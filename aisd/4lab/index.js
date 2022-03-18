const readline = require('readline')

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

function tasks(){}

class Node{
    constructor(data,left,right){
        this.data  = data;
        this.left  = left;
        this.right = right;
    }
}

class Tree {
    constructor (data){
        this.root = new Node(data,null,null);
    }
    add(data,currentNode){
        rl.question("\nLEFT OR RIGHT : ", next => {
            if(next == "right"){
                if(currentNode.right != null){
                    console.log("\n CURRENT NODE : " + currentNode.right.data);
                    this.add(data,currentNode.right);
                }else {
                    let newNode = new Node(data,null,null);
                    currentNode.right = newNode;
                    tasks();
                }
            } else if (next == "left"){
                if(currentNode.left != null){
                    console.log("\n CURRENT NODE : " + currentNode.left.data);
                    this.add(data,currentNode.left);
                }else {
                    let newNode = new Node(data,null,null);
                    currentNode.left = newNode;
                    tasks();
                }
            }else {
                console.log("\nleft or right");
                this.add(data,currentNode);
            }
        })
    }
    display(currentNode){
        if(currentNode.right != null && currentNode.left != null){
            console.log("\n" + currentNode.left.data + " <- " + currentNode.data + " -> " + currentNode.right.data);
            rl.question("\nCHOOSE WAY : ", way => {
                if(way == "right" || way == currentNode.right.data){
                    this.display(currentNode.right);
                }else if (way == "left" || way == currentNode.left.data){
                    this.display(currentNode.left);
                }else {
                    console.log("\nleft or right");
                    this.display(currentNode);
                }
            })
        }else if(currentNode.right == null && currentNode.left != null){
            console.log("\n" + currentNode.left.data + " <- " + currentNode.data + " -> NULL" );
            rl.question("\nCHOOSE WAY : ", way => {
                if(way == "right"){
                    console.log("\nright is empty");
                    this.display(currentNode);
                }else if (way == "left" || way == currentNode.left.data){
                    this.display(currentNode.left);
                }else {
                    console.log("\nleft or right");
                    this.display(currentNode);
                }
            })
            
        }else if(currentNode.left == null && currentNode.right != null){
            console.log("\n" + "NULL <- " + currentNode.data + " -> " + currentNode.right.data);
            rl.question("\nCHOOSE WAY : ", way => {
                if(way == "right" || way == currentNode.right.data){
                    this.display(currentNode.right);
                }else if (way == "left"){
                    console.log("\nleft is empty");
                    this.display(currentNode);
                }else {
                    console.log("\nleft or right");
                    this.display(currentNode);
                }
            })
        }else if (currentNode.right == null && currentNode.left == null){
            console.log("\n This is the end of tree.");
            tasks();
        }
        
    }
}
let task = 0;
let trees

function tasks(){
    task = 0;
    if(trees == null){
        rl.question("\nADD ROOT : ", data => {
            trees = new Tree(data);
            tasks();
          })
    }
    rl.question("\n1-ADD NODE\n2-LIST TREE\nCHOOSE TASK : ", task => {
        if(task ==1){
            rl.question("\nADD NODE : ", data => {
                trees.add(data,trees.root);
                tasks();
            })
        }else if (task == 2){
            trees.display(trees.root);
            tasks();
        }else {
            tasks();
        }
    })
}

tasks();
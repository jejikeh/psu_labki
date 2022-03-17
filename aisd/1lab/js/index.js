const readline = require('readline')

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
})

function tasks(){}

class Node {
  constructor (data, previous, next){
    this.data = data;
    this.previous = previous;
    this.next = next;
  }
}

class LinkedList {
  constructor (data) {
    this.header = new Node(data,null,null); // корневой
  }

  find(data){
    let currentNode = this.header; // корень
    while(currentNode.data != data){
      currentNode = currentNode.next; // пока не совпадёт с data
    }
    return currentNode;
  }

  getLast(){
    let currentNode = this.header;
    while(currentNode.next !== null){
      currentNode = currentNode.next;
    }
    return currentNode;
  }

  add(data){
    let lastNode = this.getLast();
    let newNode = new Node(data,lastNode,null);
    lastNode.next = newNode;
  }

  remove(data){
    let currentNode = this.find(data);
    if(currentNode.next != null && currentNode.previous != null){
      currentNode.previous.next = currentNode.next;
      currentNode.next.previous = currentNode.previous;
      currentNode = null;
    }else if(currentNode.next == null){
      currentNode.previous.next = null;
      currentNode = null;
    }else if(currentNode.prev == null){ // удалить корневой
      currentNode.next.previous = null;
      this.header = currentNode.next;
    }
  }

  rS(){
    let currentNode = this.header;
    let nextNode = this.header;
    let x = 0;
    while(currentNode != null){
      nextNode = this.header;
      while(nextNode != null){
        if(nextNode != currentNode && nextNode.data == currentNode.data){
          this.remove(nextNode.data);
        }
        nextNode = nextNode.next;
      }
      currentNode = currentNode.next;
    }
  }

  removeSame(){
    let currentNode = this.header;
    let nextNode = currentNode.next;
    while(currentNode != null){
      while(nextNode != null){
        while(currentNode.data == nextNode.data){
          console.log(currentNode.data + " compared to " + nextNode.data);
          if(nextNode == this.getLast()){
            let x = this.find(nextNode.data);
            this.remove(nextNode.data);
            break;
          }else {
            this.remove(nextNode.data);
            nextNode = nextNode.next;
            break;
          }
        }
        nextNode = nextNode.next;
      }
      currentNode = currentNode.next;
      if (currentNode == this.getLast()){
        break;
      }else {
        //console.log(this.getLast().data);
        //nextNode = currentNode.next;
        if(nextNode == null) {
          nextNode = currentNode.next;
        }
      }
    }
  }

  display(){
    let currentNode = this.header;
    while(currentNode != null){
      console.log(currentNode.data);
      currentNode = currentNode.next;
    }
  }
}


let task = 0;
let numbers;
function tasks(){
  task = 0;
  if(numbers == null){
    rl.question("\nADD ELEMENT : ", data => {
      numbers = new LinkedList(data);
      tasks();
    })
  }
  rl.question("\n1-ADD NODE\n2-DISPLAY ALL NODES\n3-DELETE ODE BY NAME\n4-DELETE SAME NODES\n0-EXIT\nCHOOSE TASK : ", task => {
    if(task == 1){
      rl.question("\nADD ELEMENT : ", data => {
        numbers.add(data);
        tasks();
        //numbers.display();
        //rl.close();
      })
    }else if (task == 2){
      console.log("\nDISPLAY : \n");
      numbers.display();
      tasks(); 
    }else if (task == 3){
      rl.question("\nREMOVE ELEMENT : ", data => {
        numbers.remove(data);
        tasks();
        //numbers.display();
        //rl.close();
      })
    }else if (task == 4){
      console.log("\nREMOVAL.....");
      numbers.rS();
      tasks();
    }
    else {
      tasks();
    }
  }) 
}

tasks();
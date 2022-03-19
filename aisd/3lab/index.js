const readline = require("readline");

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

let stack = [];
let x = 0;
let task = 0;
function tasks() {
  task = 0;
  rl.question(
    "\n1-ADD NODE\n2-DISPLAY ALL NODES\n3-REMOVE FIRST AND LAST\nCHOOSE TASK : ",
    (task) => {
      if (task == 1) {
        // занесение в ояередь с учётом преоритета
        rl.question("\nADD ELEMENT : ", (dataElement) => {
          rl.question("\nELEMENT PRIORITET: ", (index) => {
            stack[index] = dataElement;
            tasks();
          });
        });
      } else if (task == 2) {
        console.log("\nDISPLAY : \n");
        console.log(stack);
        tasks();
      } else if (task == 3) {
        stack.shift();
        stack.pop();
        tasks();
      } else {
        let stackwitho = stack.filter((el) => {
          return el != null && el != "";
        });
        console.log(stackwitho);
        tasks();
      }
    }
  );
}

tasks();

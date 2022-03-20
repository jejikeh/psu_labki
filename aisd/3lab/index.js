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
    "\n1-ADD NODE\n2-DISPLAY ALL NODES\n3-REMOVE FIRST AND LAST\n4-REMOVE SPECIFIC ELEMENT\nCHOOSE TASK : ",
    (task) => {
      if (task == 1) {
        // занесение в ояередь с учётом преоритета
        rl.question("\nADD ELEMENT : ", (dataElement) => {
          rl.question("\nELEMENT PRIORITET: ", (index) => {
            stack.splice(index, 0, dataElement);
            stack = stack.filter((el) => {
              return el != null && el != "";
            });
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
      } else if (task == 4) {
        rl.question("\n REMOVE ELEMENT : ", (dataElement) => {
          for (let i = 0; i < stack.length; i++) {
            console.log(stack.length);
            if (stack[i] === dataElement) {
              stack.splice(i, 1);
            }
          }
        });
        tasks();
      } else {
        tasks();
      }
    }
  );
}

tasks();

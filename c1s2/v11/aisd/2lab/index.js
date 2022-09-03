const readline = require("readline");

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

const stack = [];
let x = 0;
let task = 0;
function tasks() {
  task = 0;
  rl.question(
    "\n1-ADD NODE\n2-DISPLAY ALL NODES\n3-CALCULATE SUM\nCHOOSE TASK : ",
    (task) => {
      if (task == 1) {
        rl.question("\nADD ELEMENT : ", (data) => {
          stack.push(data);
          tasks();
        });
      } else if (task == 2) {
        console.log("\nDISPLAY : \n");
        console.log(stack);
        tasks();
      } else if (task == 3) {
        x = 0;
        for (let i = 0; i < stack.length; i++) {
          x += parseInt(stack[i]) / 2;
        }
        console.log("DELETE......" + x);
        tasks();
      } else {
        for (let i = 0; i < stack.length; i++) {
          if (parseInt(stack[i]) < x) {
            stack.splice(i, 1); // удаление из стека елси меньше
          }
        }
        tasks();
      }
    }
  );
}

tasks();

const readline = require('readline')

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});


let stack = [];
let x = 0;
let task = 0;
function tasks(){
  task = 0;
    rl.question("\n1-ADD NODE\n2-DISPLAY ALL NODES\n3-REMOVE FIRST AND LAST\nCHOOSE TASK : ", task => {
        if(task == 1){
            rl.question("\nADD ELEMENT : ", dataElement => {
                rl.question("\nELEMENT PRIORITET: ", index => {
                        if(stack[index] == null){
                            stack[index] = dataElement;
                        }else {
                            while(stack[index] != null){
                                index += 1;
                            }
                            stack[index] = dataElement;
                        }
                        tasks();
                })
        })
        }else if (task == 2){
        console.log("\nDISPLAY : \n");
        stack = stack.filter(el => {
            return el != null && el != '';
        });
        console.log(stack);
        tasks(); 
        }else if (task == 3){
            stack.shift();
            stack.pop();
            tasks();
        }
        else {
            tasks();
        }
  }) 
}

tasks();
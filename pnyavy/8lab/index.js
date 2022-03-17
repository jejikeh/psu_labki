const { waitForDebugger } = require('inspector');
const readline = require('readline')

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

function fib(data){
    return data <= 1 ? data : fib(data-1) + fib(data - 2); 
}

function fact(data){
    return data ? data * fact( data - 1 ) : 1;
}

function calc_func3(data){
    return data > 1 ? data - calc_func3(calc_func3(data - 1)) : 1;
}

function calc_func4(x,y){
    if ( x < y ) return calc_func4(y,x);
    if (!y) return x;
    return calc_func4(y, x % y);
}

function polinom_lejandra(x,n){
   //((2*n - 1) * polinom_lejandra(x,n-1) - (n - 1) * polinom_lejandra(x,n-2))/n
   return n > 1 ? ((2*n - 1) * polinom_lejandra(x, n - 1))/n- ((n - 1) * polinom_lejandra(x, n - 2))/n : x;
}   

function rasnostnie_yravnenie(data){
    return data > 2 ? rasnostnie_yravnenie(data % 2 ) + rasnostnie_yravnenie(data % 3) : data;
}

function akkerman(x,y){
    if ( x == 0 && y != 0){
        return y + 1;
    }else if ( y == 0 && x != 0 ){
        return akkerman(x - 1,1);
    }else {
        console.log(x);
        return akkerman(x - 1,akkerman(x,y-1))
    }
}


function tasks(){
    task = 0;
      rl.question("\n1-ФИБОНАЧИ\n2-ФАКТОРИАЛ\n3-ПОСЛЕДОВАТЕЛЬНОСТЬ\n4-НАИБОЛЬШИЙ ОБЩИЙ ДЕЛИТЕЛЬ\n5-ПОЛИНОМ ЛЕЖАНДРА\n6-РАЗНОСТНЫЕ УРАВНЕНИЯ\n7-АККРЕМАНА\nCHOOSE TASK : ", task => {
          if(task == 1){
              rl.question("\nELEMENT : ", dataElement => {
                console.log(fib(dataElement));
                tasks();
          })
          }else if (task == 2){
            rl.question("\nELEMENT : ", dataElement => {
                console.log(fact(dataElement));
                tasks();
          })
          }else if (task == 3){
            rl.question("\nELEMENT : ", dataElement => {
                console.log(calc_func3(dataElement));
                tasks();
          })
          }else if (task == 4 ){
            rl.question("\nELEMENT X : ", x => {
                rl.question("\nELEMENT Y : ", y => {
                    console.log(calc_func4(x,y));
                    tasks();
              })
          })
          }else if (task == 5){
            rl.question("\nELEMENT X : ", x => {
                rl.question("\nELEMENT N : ", n => {
                    console.log(polinom_lejandra(x,n));
                    tasks();
              })
          })
          }else if (task == 6){
            rl.question("\nELEMENT X : ", x => {
                console.log(rasnostnie_yravnenie(x));
                tasks();
          })
          }else if (task == 7){
            rl.question("\nELEMENT X : ", x => {
                rl.question("\nELEMENT X : ", y => {
                    console.log(akkerman(x,y));
                    tasks();
              })
          })
          }
          else {
              tasks();
          }
    }) 
  }
  
  tasks();
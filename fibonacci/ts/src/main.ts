import { exit } from "process";
import {fibo} from "./fibo";

let arg = process.argv;
if (arg.length != 3) {
  console.log("You need to provide a number");
  exit();
}

let num: number = parseInt(arg[2], 10);

const startTime = performance.now()
    
console.log(`Fibonacci of ${num} is ${fibo(num)}`);

const endTime = performance.now()

console.log(`Fibonacci took ${endTime - startTime} milliseconds`)
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const process_1 = require("process");
const fibo_1 = require("./fibo");
let arg = process.argv;
if (arg.length != 3) {
    console.log("You need to provide a number");
    (0, process_1.exit)();
}
let num = parseInt(arg[2], 10);
const startTime = performance.now();
console.log(`Fibonacci of ${num} is ${(0, fibo_1.fibo)(num)}`);
const endTime = performance.now();
console.log(`Fibonacci took ${endTime - startTime} milliseconds`);

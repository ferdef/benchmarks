"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const fibo_1 = require("./fibo");
function greet(text) {
    return `Hello, ${text}!`;
}
console.log(greet("Fernando"));
let num = 45;
const startTime = performance.now();
console.log(`Fibonacci of ${num} is ${(0, fibo_1.fibo)(num)}`);
const endTime = performance.now();
console.log(`Call to doSomething took ${endTime - startTime} milliseconds`);

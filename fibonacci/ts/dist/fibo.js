"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.fibo = fibo;
function fibo(num) {
    if (num < 2) {
        return 1;
    }
    return fibo(num - 2) + fibo(num - 1);
}

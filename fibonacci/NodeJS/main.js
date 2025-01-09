function fibo(num) {
  if (num < 2) {
    return num;
  }

  return fibo(num-1) + fibo(num-2);
}

const num = 50;
var result = fibo(num);

console.log("Fibo of %d is %d", num, result);
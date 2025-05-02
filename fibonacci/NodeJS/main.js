function fibo(num) {
  if (num < 2) {
    return 1;
  }

  return fibo(num-1) + fibo(num-2);
}

const num = 45;

const startTime = performance.now();

var result = fibo(num);

const endTime = performance.now();

console.log("Fibo of %d is %d", num, result);
console.log(`Took ${endTime - startTime} ms`);

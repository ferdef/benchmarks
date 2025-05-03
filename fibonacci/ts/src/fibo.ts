export function fibo(num: number): number {
  if (num < 2) {
    return 1;
  }

  return fibo(num-2) + fibo(num-1);
}
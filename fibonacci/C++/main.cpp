#include <iostream>
#include <chrono>

using namespace std;

unsigned long fibo(unsigned long number) {
  if (number <= 2) return number;

  return fibo(number-1) + fibo(number-2);
}

int main(void) {
  chrono::time_point<chrono::steady_clock> start = chrono::steady_clock::now();

  unsigned long number = 50;
  unsigned long result = fibo(number);

  chrono::time_point<chrono::steady_clock> stop = chrono::steady_clock::now();
 	chrono::duration<double, std::milli> elapsed = stop - start;

  cout << "Fibonacci of " << number << " is " << result << " (" << elapsed.count() << " ms)\n";
  return 0;
}
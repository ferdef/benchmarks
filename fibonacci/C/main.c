#include <stdio.h>
#include <time.h>
#include "types.h"
#include "fibo.h"
#include "fibo_iter.h"

clock_t start, end;
double cpu_time_used;

void measureFn(char* ftype, fnType fn, int pos) {
    bigint value;

    start = clock();
    value = fn(pos);
    end = clock();
    cpu_time_used = (((double) (end - start)) / CLOCKS_PER_SEC) * 1000;
    printf("%s: Fibonacci of %d is %llu (%f s elapsed)\n", ftype, pos, value, cpu_time_used / 1000);
}

int main(void) {
    int pos = 45;
   

    printf("Calculating fibonacci number in pos %d\n", pos);
    measureFn("Iterative", &fibo_iter, pos);
    measureFn("Recursive", &fibo, pos);
    
    return 0;
}

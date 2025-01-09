#include "fibo_iter.h"

bigint fibo_iter(int number) {
    bigint a = 1;
    bigint b = 1;
    bigint value;
    if (number < 2) 
        return number;
    for (int i = 2; i < number; i++) {
        value = a + b;
        a = b;
        b = value;
    }
    return value;
}
package main

import (
	"fmt"
	"time"
)

func measure_fn(ftype string, fn func(uint64) uint64, number uint64) {
	start := time.Now()
	value := fn(number)
	elapsed := time.Since(start)
	fmt.Printf("%s: Fibonacci of %d is %d (%s elapsed)\n", ftype, number, value, elapsed)
}

func main() {
	var number uint64 = 50
	fmt.Printf("Calculating fibonacci number in pos %d\n", number)
	measure_fn("Iterative", fibo_iter, number)
	measure_fn("Recursive", fibo, number)
	measure_fn("Cached Rec", fibo_cache, number)
}

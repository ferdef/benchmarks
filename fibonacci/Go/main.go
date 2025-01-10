package main

import (
	"fmt"
	"runtime"
	"time"
)

func measure_fn(ftype string, fn func(uint64) uint64, number uint64) {
	var memStart, memEnd runtime.MemStats
	runtime.ReadMemStats(&memStart)
	start := time.Now()

	value := fn(number)

	elapsed := time.Since(start)
	runtime.ReadMemStats(&memEnd)
	memoryUsed := memEnd.Alloc - memStart.Alloc

	fmt.Printf("%s: Fibonacci of %d is %d\n", ftype, number, value)
	fmt.Printf("Time Elapsed: %s\tMemory Consumed: %d bytes\n\n", elapsed, memoryUsed)
}

func measure_fn2(ftype string, fn func(uint64, uint64, uint64) uint64, number uint64, a uint64, b uint64) {
	var memStart, memEnd runtime.MemStats
	runtime.ReadMemStats(&memStart)
	start := time.Now()

	value := fn(number, a, b)

	elapsed := time.Since(start)
	runtime.ReadMemStats(&memEnd)
	memoryUsed := memEnd.Alloc - memStart.Alloc

	fmt.Printf("%s: Fibonacci of %d is %d\n", ftype, number, value)
	fmt.Printf("Time Elapsed: %s\tMemory Consumed: %d bytes\n\n", elapsed, memoryUsed)
}

func main() {
	var number uint64 = 50
	fmt.Printf("Calculating fibonacci number in pos %d\n", number)
	measure_fn("Iterative", fibo_iter, number)
	measure_fn("Recursive", fibo, number)
	measure_fn("Cached Rec", fibo_cache, number)
	measure_fn2("Tail Recursion", fibo_tail, number, 0, 1)
}

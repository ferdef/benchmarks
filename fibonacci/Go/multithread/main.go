package main

import (
	"fmt"
	"runtime"
	"time"
)

func measure_fn(ftype string, number uint64, numRoutines int) {
	var memStart, memEnd runtime.MemStats
	runtime.ReadMemStats(&memStart)
	start := time.Now()

	benchmarkParallel(numRoutines, number)

	elapsed := time.Since(start)
	runtime.ReadMemStats(&memEnd)
	memoryUsed := memEnd.Alloc - memStart.Alloc

	fmt.Printf("Time Elapsed: %s\tMemory Consumed: %d bytes\n\n", elapsed, memoryUsed)
}

func main() {
	var number uint64 = 50
	var numRoutines int = 3;
	fmt.Printf("Executing %d goroutines calculating fibo(%d)\n", numRoutines, number)
	measure_fn("Recursive", number, numRoutines)
}

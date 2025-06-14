package main

import (
	"fmt"
	"sync"
)

func fibo(number uint64) uint64 {
	if number < 2 {
		return number
	}
	return fibo(number-1) + fibo(number-2)
}

func benchmarkParallel(numGoroutines int, fiboInput uint64) {
	var wg sync.WaitGroup
	
	for i := 0; i < numGoroutines; i++ {
		wg.Add(1)
		go func(id int) {
			defer wg.Done()
			result := fibo(fiboInput)
			fmt.Printf("Goroutine %d: fibo(%d) = %d\n", id, fiboInput, result)
		}(i)
	}
	
	wg.Wait()
}
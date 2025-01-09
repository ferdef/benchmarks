package main

func fibo(number uint64) uint64 {
	if number < 2 {
		return number
	}
	return fibo(number-1) + fibo(number-2)
}

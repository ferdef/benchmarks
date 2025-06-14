package main

func fibo_tail(number uint64, a uint64, b uint64) uint64 {
	if (number == 0) {
		return a
	}
	if (number == 1) {
		return b
	}
	return fibo_tail(number - 1, b, a + b)
}
package main

func fibo_iter(number uint64) uint64 {
	if number < 2 {
		return number
	}
	var a uint64 = 1
	var b uint64 = 1
	var value uint64 = 0
	for i := 2; i < int(number); i++ {
		value = a + b
		a = b
		b = value
	}
	return value
}
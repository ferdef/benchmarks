package main

var cache map[uint64]uint64 = make(map[uint64]uint64)

func fibo_cache(number uint64) uint64 {
	val, ok := cache[number]
	if ok {
		return val
	}
	cache[number] = _fibo(number)
	return cache[number]
}

func _fibo(number uint64) uint64 {
	if number < 2 {
		return number
	}
	return fibo_cache(number-1) + fibo_cache(number-2)
}

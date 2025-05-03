cache = {}

def fibo_cache(number):
    if number in cache:
        return cache[number]
    cache[number] = _fibo(number)
    return cache[number]

def _fibo(number):
    if number < 2:
        return 1
    return fibo_cache(number-1) + fibo_cache(number-2)
    

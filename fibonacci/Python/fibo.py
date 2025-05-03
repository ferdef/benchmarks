def fibo(number):
    if number < 2:
        return 1
    return fibo(number-1) + fibo(number-2)

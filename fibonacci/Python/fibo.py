def fibo(number):
    if number < 2:
        return number
    return fibo(number-1) + fibo(number-2)
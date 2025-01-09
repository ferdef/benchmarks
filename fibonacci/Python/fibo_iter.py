def fibo_iter(number):
    if number < 2:
        return number
    a = 1
    b = 1
    for iter in range(2, number):
        value = a + b
        a = b
        b = value
    return value
def fibo_tail(n, a, b):
    if n == 0: return a
    if n == 1: return b
    return fibo_tail(n - 1, b, a + b)
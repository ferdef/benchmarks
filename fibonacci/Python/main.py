import sys
from time import process_time
from fibo import fibo
from fibo_iter import fibo_iter
from fibo_cache import fibo_cache
from fibo_tail import fibo_tail

def measure_fn(type, fn, pos):
    time_start = process_time()
    value = fn(pos)
    time_end = process_time()
    time_duration = time_end - time_start
    print(f'{type}: Fibonacci of {pos} is {value} ({time_duration:.3f} s elapsed)')

def measure_fn2(type, fn, pos):
    time_start = process_time()
    value = fn(pos, 1, 1)
    time_end = process_time()
    time_duration = time_end - time_start
    print(f'{type}: Fibonacci of {pos} is {value} ({time_duration:.3f} s elapsed)')

if __name__ == "__main__":
    n = len(sys.argv)
    if n != 2:
        print("You have to provide a number");
        exit();

    pos = int(sys.argv[1]);

    print(f'Calculating fibonacci number in pos {pos}')
    measure_fn('Iterative', fibo_iter, pos)
    measure_fn('Recursive', fibo, pos)
    measure_fn('Cached Rec', fibo_cache, pos)
    measure_fn2('Tail Rec', fibo_tail, pos)

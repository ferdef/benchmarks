import time
import numpy as np
from numba import jit

@jit(nopython=True)
def quicksort(arr):
    if len(arr) <= 1:
        return arr
    pivot = arr[len(arr) // 2]
    left = [x for x in arr if x < pivot]
    middle = [x for x in arr if x == pivot]
    right = [x for x in arr if x > pivot]
    return quicksort(left) + middle + quicksort(right)

arr = np.random.randint(0, 1000000, 1000000)
start_time = time.time()
sorted_arr = quicksort(arr)
end_time = time.time()
print("Python with Numba:", end_time - start_time, "seconds")

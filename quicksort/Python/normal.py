import time
import random

def quicksort(arr):
    if len(arr) <= 1:
        return arr
    pivot = arr[len(arr) // 2]
    left = [x for x in arr if x < pivot]
    middle = [x for x in arr if x == pivot]
    right = [x for x in arr if x > pivot]
    return quicksort(left) + middle + quicksort(right)

arr = [random.randint(0, 1000000) for _ in range(1000000)]

start_time = time.time()
sorted_arr = quicksort(arr)
end_time = time.time()
print("Python:", end_time - start_time, "seconds")

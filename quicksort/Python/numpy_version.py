import time
import numpy as np

arr = np.random.randint(0, 1000000, 1000000)

start_time = time.time()
sorted_arr = np.sort(arr)
end_time = time.time()

print("Python with NumPy (vectorized):", end_time - start_time, "seconds")

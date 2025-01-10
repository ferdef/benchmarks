const std = @import("std");

// Swap function to exchange two elements in an array
fn swap(array: []u64, i: usize, j: usize) void {
    const temp = array[i];
    array[i] = array[j];
    array[j] = temp;
}

// Partition function for QuickSort
fn partition(array: []u64, low: usize, high: usize) usize {
    const pivot = array[high];
    var i: usize = low;

    for (low..high) |j| {
        if (array[j] < pivot) {
            swap(array, i, j);
            i += 1;
        }
    }

    swap(array, i, high);
    return i;
}

// Recursive QuickSort implementation
fn quicksort(array: []u64, low: usize, high: usize) void {
    if (low < high) {
        const pivot_index = partition(array, low, high);

        if (pivot_index > 0) {
            quicksort(array, low, pivot_index - 1);
        }
        quicksort(array, pivot_index + 1, high);
    }
}

pub fn main() !void {
    const allocator = std.heap.page_allocator;
    const array_size = 10_000_000;

    // Allocate and initialize the array with random numbers
    const array = try allocator.alloc(u64, array_size);
    defer allocator.free(array);

    const seed: u64 = @as(u64, @intCast(std.time.nanoTimestamp()));
    var rng = std.rand.DefaultPrng.init(seed);

    for (array) |*item| {
        item.* = rng.next() % 1_000_000;
    }

    // Measure the time it takes to sort the array
    const start_time = std.time.milliTimestamp();
    quicksort(array, 0, array.len - 1);
    const end_time = std.time.milliTimestamp();

    const elapsed_time = end_time - start_time;

    std.debug.print("Quicksort of {d} elements took {d} ms.\n", .{ array_size, elapsed_time });
}

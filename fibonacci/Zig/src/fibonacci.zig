const std = @import("std");

fn fibo_recursive(num: u64) u64 {
    if (num < 2) {
        return num;
    }
    return fibo_recursive(num - 1) + fibo_recursive(num - 2);
}

fn fibo_tail_recursive(n: u64, a: u64, b: u64) u64 {
    if (n == 0) return a;
    if (n == 1) return b;
    return fibo_tail_recursive(n - 1, b, a + b);
}

fn measure_time(func: fn (u64) u64, arg: u64) u64 {
    const start = std.time.milliTimestamp();
    const result = func(arg);
    const end = std.time.milliTimestamp();
    const elapsed = end - start;
    std.debug.print("Function executed in {d} ms\n", .{elapsed});
    return result;
}

fn measure_tail_rec_time(func: fn (u64, u64, u64) u64, arg: u64, a: u64, b: u64) u64 {
    const start = std.time.nanoTimestamp();
    const result = func(arg, a, b);
    const end = std.time.nanoTimestamp();
    const elapsed = end - start;
    std.debug.print("Function executed in {d} ns\n", .{elapsed});
    return result;
}

pub fn main() void {
    const num = 50;

    const result_rec = measure_time(fibo_recursive, num);
    std.debug.print("Fibo recursive of {d} is {d}\n", .{ num, result_rec });

    const result_tail_rec = measure_tail_rec_time(fibo_tail_recursive, num, 0, 1);
    std.debug.print("Fibo tail recursive of {d} is {d}\n", .{ num, result_tail_rec });
}

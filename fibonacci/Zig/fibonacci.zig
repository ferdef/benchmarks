const std = @import("std");

fn fibo(num: u64) u64 {
    if (num < 2) {
        return num;
    }
    return fibo(num - 1) + fibo(num - 2);
}

pub fn main() void {
    const num = 50;

    const result = fibo(num);
    std.debug.print("Fibo of {d} is {d} \n", .{ num, result });
}

const std = @import("std");
//const png = @import("std").image.png;

pub fn main() !void {
    const allocator = std.heap.page_allocator;

    const args = try std.process.argsAlloc(allocator);
    defer std.process.argsFree(allocator, args);

    if (args.len < 7) {
        std.debug.print("Uso: {s} ancho alto minX minY maxX maxY\n", .{args[0]});
        return;
    }

    const width = try std.fmt.parseInt(u32, args[1], 10);
    const height = try std.fmt.parseInt(u32, args[2], 10);

    const min_x = try std.fmt.parseFloat(f64, args[3]);
    const min_y = try std.fmt.parseFloat(f64, args[4]);
    const max_x = try std.fmt.parseFloat(f64, args[5]);
    const max_y = try std.fmt.parseFloat(f64, args[6]);

    const max_iterations: u32 = 255;

    var pixels = try allocator.alloc(u8, width * height * 4);
    defer allocator.free(pixels);

    var row: u32 = 0;
    while (row < height) {
        var col: u32 = 0;
        while (col < width) {
            const c_re = min_x + (@as(f64, @floatFromInt(col)) * (max_x - min_x) / @as(f64, @floatFromInt(width)));
            const c_im = min_y + (@as(f64, @floatFromInt(row)) * (max_y - min_y) / @as(f64, @floatFromInt(height)));
            var zx = c_re;
            var zy = c_im;

            var iteration: u32 = 0;
            while (zx * zx + zy * zy <= 4.0 and iteration < max_iterations) {
                const temp = zx * zx - zy * zy + c_re;
                zy = 2.0 * zx * zy + c_im;
                zx = temp;
                iteration += 1;
            }

            var color: u8 = 0;
            if (iteration != max_iterations) {
                color = @truncate((iteration * 255) / max_iterations);
            }

            const idx = (row * width + col) * 4;
            pixels[idx] = color;
            pixels[idx + 1] = color;
            pixels[idx + 2] = color;
            pixels[idx + 3] = 255; // Alpha

            col += 1;
        }
        row += 1;
    }

    const file = try std.fs.cwd().createFile("mandelbrot.png", .{});
    defer file.close();

    // var writer = file.writer();
    // try png.writeRgba8(allocator, &writer, width, height, pixels);

    std.debug.print("Fractal Mandelbrot guardado en mandelbrot.png\n", .{});
}

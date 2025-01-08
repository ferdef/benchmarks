import time

import numpy as np
import matplotlib.pyplot as plt
import argparse

def mandelbrot(c, max_iter):
    z = np.zeros(c.shape, dtype=complex)
    div_time = max_iter + np.zeros(c.shape, dtype=int)

    for i in range(max_iter):
        z = z*z + c
        diverge = np.abs(z) > 2
        div_time[diverge & (div_time == max_iter)] = i
        z[diverge] = 2  # Evita seguir iterando

    return div_time

def create_fractal(width, height, x_min, x_max, y_min, y_max, max_iter, filename):
    x = np.linspace(x_min, x_max, width)
    y = np.linspace(y_min, y_max, height)
    X, Y = np.meshgrid(x, y)
    C = X + 1j * Y

    mandelbrot_set = mandelbrot(C, max_iter)

    fig, ax = plt.subplots(figsize=(width / 100, height / 100), dpi=100)
    ax.imshow(mandelbrot_set, extent=[x_min, x_max, y_min, y_max], cmap='twilight_shifted', origin='lower')
    ax.set_xlim([x_min, x_max])
    ax.set_ylim([y_min, y_max])
    plt.colorbar(ax.imshow(mandelbrot_set, extent=[x_min, x_max, y_min, y_max], cmap='twilight_shifted', origin='lower'), ax=ax)
    plt.savefig(filename, dpi=100)
    plt.close()

def main():
    parser = argparse.ArgumentParser(description="Generate Mandelbrot fractal and save as PNG.")
    parser.add_argument('--width', type=int, default=800, help='Width of the image in pixels')
    parser.add_argument('--height', type=int, default=600, help='Height of the image in pixels')
    parser.add_argument('--x_min', type=float, default=-2.0, help='Minimum x-axis value')
    parser.add_argument('--x_max', type=float, default=1.0, help='Maximum x-axis value')
    parser.add_argument('--y_min', type=float, default=-1.5, help='Minimum y-axis value')
    parser.add_argument('--y_max', type=float, default=1.5, help='Maximum y-axis value')
    parser.add_argument('--max_iter', type=int, default=256, help='Maximum number of iterations')
    parser.add_argument('--filename', type=str, default='mandelbrot.png', help='Output filename')

    args = parser.parse_args()

    create_fractal(args.width, args.height, args.x_min, args.x_max, args.y_min, args.y_max, args.max_iter, args.filename)

if __name__ == "__main__":
    start_time = time.time()
    main()
    end_time = time.time()
    print("Python:", end_time - start_time, "seconds")

import time
import numpy as np
import matplotlib.pyplot as plt
import argparse

def mandelbrot(c, max_iter):
    z = c
    for n in range(max_iter):
        if abs(z) > 2:
            return n
        z = z*z + c
    return max_iter

def create_fractal(width, height, x_min, x_max, y_min, y_max, max_iter, filename):
    image = np.zeros((height, width))
    x_range = np.linspace(x_min, x_max, width)
    y_range = np.linspace(y_min, y_max, height)
    for i, x in enumerate(x_range):
        for j, y in enumerate(y_range):
            c = complex(x, y)
            color = mandelbrot(c, max_iter)
            image[j, i] = color

    plt.imshow(image, extent=[x_min, x_max, y_min, y_max], cmap='twilight_shifted')
    plt.colorbar()
    plt.savefig(filename, dpi=300)
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
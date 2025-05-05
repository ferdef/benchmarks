import { writeFileSync } from "fs";
import { PNG } from "pngjs";

export function writeImage(fileName: string, pixels: number[], bounds: [number, number]): boolean {
  const [width, height] = bounds;
  const png = new PNG({
    width,
    height,
    colorType: 0,
    bitDepth: 8,
    inputColorType: 0,
    inputHasAlpha: false
  });

  for (let y = 0; y < height; y++) {
    for (let x = 0; x < width; x++) {
      const idx = (y * width + x);
      const idxPng = (y * width + x) * 4;

      png.data[idxPng + 0] = pixels[idx];
      png.data[idxPng + 1] = pixels[idx];
      png.data[idxPng + 2] = pixels[idx];
      png.data[idxPng + 3] = 255;
    }
  }
  const buffer = PNG.sync.write(png);

  writeFileSync(fileName, buffer);

  return true;
}
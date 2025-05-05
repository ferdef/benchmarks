import { exit } from "process";
import { Complex } from "./complex";

export function render(
  pixels: number[],
  bounds: [number, number],
  upperLeft: Complex,
  lowerRight: Complex) {

  if (pixels.length !== bounds[0] * bounds[1]) {
    console.log("Wrong size of pixels array");
    exit(1);
  }

  for(let row = 0; row < bounds[1]; row++) {
    for(let column = 0; column < bounds[0]; column++) {
      let point = pixelToPoint(bounds, [column, row], upperLeft, lowerRight);
      let et = escapeTime(point, 255);
      pixels[row * bounds[0] + column] = (et === null) ? 0 : 255 +- et;
    }
  }
}

function escapeTime(c: Complex, limit: number): number | null {
  let z = new Complex(0.0, 0.0);
  for(let it = 0; it < limit; it++) {
    if (z.normSqr() > 4.0) {
      return it;
    }

    z = z.multiply(z).add(c);
  }

  return null;
}

function pixelToPoint(
  bounds: [number, number],
  pixel: [number, number],
  upperLeft: Complex,
  lowerRight: Complex): Complex {
  let [width, height] = [lowerRight.re - upperLeft.re, upperLeft.im - lowerRight.im];
  return new Complex(
    upperLeft.re + pixel[0] * width / bounds[0],
    upperLeft.im - pixel[1] * height / bounds[1]
  );
}
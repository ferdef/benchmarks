import { exit } from "process";
import { Complex } from "./parsers";

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
  return null;
}

function pixelToPoint(
  bounds: [number, number], 
  pixel: [number, number], 
  upperLeft: Complex, 
  lowerRight: Complex): Complex {
  
  return new Complex(0, 0);
}
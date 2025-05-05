import { exit } from "process";
import { parseComplex, parseNumber, parsePair } from "./parsers";
import { render } from "./renderer";

function main(): boolean {
  let args = process.argv;

  if (args.length != 6) {
    console.log("Args: FILE PIXELS UPPERLEFT LOWERRIGHT");
    return false;
  }

  let bounds = parsePair(args[3], 'x', parseNumber);
  let upperLeft = parseComplex(args[4]);
  let lowerRight = parseComplex(args[5]);

  if (bounds === null || upperLeft === null || lowerRight === null) {
    console.log("Error parsing arguments");
    return false;
  }

  let pixels: number[] = new Array(bounds[0] * bounds[1]).fill(0);

  render(pixels, bounds, upperLeft, lowerRight);

  return true;
}

const startTime = performance.now()

if (!main()) {
  exit(1);
}

const endTime = performance.now()
const duration = endTime - startTime;

console.log(`Time elapsed ${duration} ms`);
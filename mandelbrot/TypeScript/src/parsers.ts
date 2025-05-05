export class Complex {
  constructor(public re: number, public im: number) {}

  toString(): string {
    return `${this.re}${this.im >= 0 ? '+' : ''}${this.im}i`;
  }
}

export function parsePair<T>(
  s: string, 
  separator: string, 
  parser: (str: string) => T | null
): [T, T] | null {
  const index = s.indexOf(separator);

  if (index === -1) {
    return null;
  }

  const leftStr = s.substring(0, index);
  const rightStr = s.substring(index + separator.length);

  const left = parser(leftStr);
  const right = parser(rightStr);

  if (left !== null && right !== null) {
    return [left, right];
  }

  return null;
}

export function parseNumber(s: string): number | null {
  const num = Number(s.trim());
  return (!isNaN(num) && isFinite(num)) ? num : null;
}

export function parseComplex(s: string) {
  const result = parsePair(s, ",", parseNumber);

  if (result !== null) {
    const [re, im] = result;
    return new Complex(re, im);
  }

  return null;
}
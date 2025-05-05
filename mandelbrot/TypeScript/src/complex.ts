export class Complex {
  constructor(public re: number, public im: number) {}

  normSqr(): number {
    return this.re * this.re + this.im * this.im;
  }

  norm(): number {
    return Math.sqrt(this.normSqr());
  }

  multiply(other: Complex): Complex {
    return new Complex(
      this.re * other.re - this.im * other.im,
      this.re * other.im + this.im * other.re
    );
  }

  add(other: Complex): Complex {
    return new Complex(
      this.re + other.re,
      this.im + other.im
    );
  }

  toString(): string {
    return `${this.re}${this.im >= 0 ? '+' : ''}${this.im}i`;
  }
}
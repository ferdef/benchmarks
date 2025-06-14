using System.Numerics;

public static class Renderer
{
  static Complex z = new(0.0, 0.0);

  public static void Render(byte[] pixels, (int, int) bounds, Complex upper_left, Complex lower_right)
  {
    if (pixels.Length != bounds.Item1 * bounds.Item2)
    {
      return;
    }

    for (int row = 0; row < bounds.Item2; row++)
    {
      for (int column = 0; column < bounds.Item1; column++)
      {
        var point = PixelToPoint(bounds, (column, row), upper_left, lower_right);
        var escapeTime = EscapeTime(point, 255);
        switch(escapeTime) {
          case 0:
            pixels[row * bounds.Item1 + column] = 0;
            break;
          default:
            pixels[row * bounds.Item1 + column] = (byte)(255 - escapeTime);
            break;
        }
      }
    }
  }

  private static Complex PixelToPoint((int, int) bounds, (int, int) pixel, Complex upperLeft, Complex lowerRight)
  {
    var (width, height) = (lowerRight.Real - upperLeft.Real, upperLeft.Imaginary - lowerRight.Imaginary);

    return new Complex(
      upperLeft.Real + pixel.Item1 * width / bounds.Item1,
      upperLeft.Imaginary - pixel.Item2 * height / bounds.Item2
    );
  }

  private static double NormSqr(Complex complex) {
    return (complex.Real * complex.Real) + (complex.Imaginary + complex.Imaginary);
  }

  private static byte EscapeTime(Complex c, int limit)
  { 
    z = 0.0;

    for(byte i = 0; i < limit; i++) {
      if (NormSqr(z) > 4.0) {
        return i;
      }
      z = z * z + c;
    }
    return 0;
  } 
}
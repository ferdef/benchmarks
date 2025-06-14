using System.IO.Compression;
using System.Numerics;

namespace MandelSharp;

public class Renderer
{
  private const int MaxIterations = 255;
  private const double EscapeRadius = 2.0;

  public static void Render(MandelbrotConfig config, int[] pixels)
  {
    var (pixelsWidth, pixelsHeight) = config.Pixels;

    double width = config.LowerRight.Real - config.UpperLeft.Real;
    double height = config.UpperLeft.Imaginary - config.LowerRight.Imaginary;

    for (int row = 0; row < pixelsHeight; row++)
    {
      for (int column = 0; column < pixelsWidth; column++)
      {
        var re = config.UpperLeft.Real + column * width / pixelsWidth;
        var im = config.UpperLeft.Imaginary - row * height / pixelsHeight;
        var point = new Complex(re, im);

        var et = EscapeTime(point);
        pixels[row * pixelsWidth + column] = (!et.HasValue) ? 0 : 255 - et.Value;
      }
    }
  }

  static int? EscapeTime(Complex c)
  {
    var zr = 0.0;
    var zi = 0.0;

    for (int it = 0; it < MaxIterations; it++)
    {
      var zr2 = zr * zr;
      var zi2 = zi * zi;

      if (zr2 + zi2 > (EscapeRadius * EscapeRadius))
      {
        return it;
      }

      var temp = zr2 - zi2 + c.Real;
      zi = EscapeRadius * zr * zi + c.Imaginary;
      zr = temp;
    }
    return null;
  }
}
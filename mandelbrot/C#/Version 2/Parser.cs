using System.Globalization;
using System.Numerics;

namespace MandelSharp;

public record MandelbrotConfig(
  string Filename,
  (int width, int height) Pixels,
  Complex UpperLeft,
  Complex LowerRight
);

public class Parser
{
  public static MandelbrotConfig Parse(string[] args)
  {
    if (args.Length != 4) throw new ArgumentException("Args: FILE PIXELS UPPERLEFT LOWERRIGHT");

    return new MandelbrotConfig(
      args[0],
      Parse<(int, int)>(args[1], 'x'),
      Parse<Complex>(args[2], ','),
      Parse<Complex>(args[3], ',')
    );
  }

  static T Parse<T>(string input, char separator)
  {
    var parts = input.Split(separator);

    if (parts.Length != 2) throw new ArgumentException("Format is not valid");

    return typeof(T) switch
    {
      Type t when t == typeof((int, int)) =>
        (T)(object)(int.Parse(parts[0]), int.Parse(parts[1])),

      Type t when t == typeof(Complex) =>
        (T)(object)new Complex(
          double.Parse(parts[0], CultureInfo.InvariantCulture),
          double.Parse(parts[1], CultureInfo.InvariantCulture)),

      _ => throw new NotSupportedException($"Type {typeof(T)} not Supported")
    };
  }
}
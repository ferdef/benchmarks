using System.Globalization;
using System.Numerics;

public static class Parser {
  public static (T, T)? ParsePair<T>(string s, char separator)
  {
    var elements = s.Split(separator);
    if (elements.Length != 2)
    {
      return null;
    }
    return(
      (T)Convert.ChangeType(elements[0], typeof(T), CultureInfo.InvariantCulture),
      (T)Convert.ChangeType(elements[1], typeof(T), CultureInfo.InvariantCulture));
  }

  public static Complex? ParseComplex(string s) 
  {
    (double, double)? complex = ParsePair<double>(s, ',');
    if (!complex.HasValue)
    {
      return null;
    }

    return new Complex(complex.Value.Item1, complex.Value.Item2);
  }
} 
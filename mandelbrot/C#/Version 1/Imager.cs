using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

public static class Imager {
  public static void WriteImage(string filename, byte[] pixels, (int, int) bounds) {
    var img = Image.LoadPixelData<L8>(pixels, bounds.Item1, bounds.Item2);
    img.SaveAsPng(filename);
  }
}
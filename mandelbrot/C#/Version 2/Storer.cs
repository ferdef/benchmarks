using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MandelSharp;

class Storer
{
  public static void SaveAsPng(int[] pixels, int width, int height, string filePath)
  {
    using var image = new Image<Rgb24>(width, height);

    for (int y = 0; y < height; y++)
    {
      for (int x = 0; x < width; x++)
      {
        int pixelValue = pixels[y * width + x];

        byte gray = (byte)Math.Clamp(pixelValue, 0, 255);

        image[x, y] = new Rgb24(gray, gray, gray);
      }
    }

    image.Save(filePath);
  }
}

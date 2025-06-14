namespace MandelSharp;

class Program
{
  static void Main(string[] args)
  {
    var config = Parser.Parse(args);

    var (pixelsWidth, pixelsHeight) = config.Pixels;
    int[] pixels = new int[pixelsWidth * pixelsHeight];
    Array.Fill(pixels, 0);

    Renderer.Render(config, pixels);
  }
}
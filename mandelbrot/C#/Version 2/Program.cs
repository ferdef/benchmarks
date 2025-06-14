using System.Diagnostics;

namespace MandelSharp;

class Program
{
  static void Main(string[] args)
  {
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();

    var config = Parser.Parse(args);

    var (pixelsWidth, pixelsHeight) = config.Pixels;
    int[] pixels = new int[pixelsWidth * pixelsHeight];
    Array.Fill(pixels, 0);

    Renderer.Render(config, pixels);

    Storer.SaveAsPng(pixels, pixelsWidth, pixelsHeight, config.Filename);

    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;

    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
      ts.Hours, ts.Minutes, ts.Seconds,
      ts.Milliseconds / 10);

    Console.WriteLine($"Mandelbrot took {elapsedTime}");
  }
}
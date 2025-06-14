using System.Diagnostics;

using static Parser;
using static Renderer;
using static Imager;

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

if (args.Length != 4)
{
  var name = System.AppDomain.CurrentDomain.FriendlyName;

  Console.Error.WriteLine($"Usage: {name} FILE PIXELS UPPERLEFT LOWERRIGHT");
  Console.Error.WriteLine($"Example {name} mandel.png 1000x750 -1.20,0.35 -1,0.20");

  System.Environment.Exit(1);  
}

(int, int)? bounds = ParsePair<int>(args[1], 'x');
var upper_left = ParseComplex(args[2]);
var lower_right = ParseComplex(args[3]);

if (!bounds.HasValue || !upper_left.HasValue || !lower_right.HasValue)
{
  Console.Error.WriteLine("Invalid values for one or some parameters");
  System.Environment.Exit(1);
}

var pixels = new byte[bounds.Value.Item1 * bounds.Value.Item2];
pixels = Array.ConvertAll(pixels, i => (byte)0);

Console.WriteLine("About to Render...");

Render(pixels, bounds.Value, upper_left.Value, lower_right.Value);

Console.WriteLine("About to Save Image...");

WriteImage(args[0], pixels, bounds.Value);

stopWatch.Stop();
TimeSpan ts = stopWatch.Elapsed;
string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
  ts.Hours, ts.Minutes, ts.Seconds,
  ts.Milliseconds / 10);

Console.WriteLine($"Time Spent: ({elapsedTime})");
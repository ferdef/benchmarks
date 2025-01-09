// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

ulong num = 50;
Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

ulong result = Fibo.recursive(num);

stopWatch.Stop();
TimeSpan ts = stopWatch.Elapsed;

string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
  ts.Hours, ts.Minutes, ts.Seconds,
  ts.Milliseconds / 10);

Console.WriteLine($"Fibo of {num} is {result} ({elapsedTime})");

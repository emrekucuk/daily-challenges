using System;
using System.Diagnostics;
using System.Threading;

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

System.Console.WriteLine($"First Stopwatch: {stopWatch.Elapsed}");
stopWatch.Restart();
System.Console.WriteLine($"Restart Stopwatch: {stopWatch.Elapsed}");
stopWatch.Reset();
System.Console.WriteLine($"Reset Stopwatch: {stopWatch.Elapsed}");
stopWatch.Restart();
System.Console.WriteLine($"Restart Stopwatch 2: {stopWatch.Elapsed}");

Thread.Sleep(1000);

System.Console.WriteLine($"Stopwacht State: {stopWatch.IsRunning}");
System.Console.WriteLine($"Stopwacht Elapsed: {stopWatch.Elapsed}");

stopWatch.Stop();

System.Console.WriteLine($"Stopwacht Milisecond: {stopWatch.ElapsedMilliseconds}");
System.Console.WriteLine($"Stopwacht: {stopWatch.ElapsedTicks}");
System.Console.WriteLine($"Stopwacht State: {stopWatch.IsRunning}");

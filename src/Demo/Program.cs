using System;
using System.Diagnostics;

using Fibonacci;

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

var tasks = await Compute.ExecuteAsync(args);
foreach (var task in tasks) Console.WriteLine($"Fibo result : {task}");

stopwatch.Stop();
Console.WriteLine($"{stopwatch.Elapsed.Seconds}s");

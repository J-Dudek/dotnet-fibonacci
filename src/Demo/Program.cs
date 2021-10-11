using System;
using System.Diagnostics;

using Fibonacci;

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

using var fibonacciDataContext = new FibonacciDataContext();
var compute = new Compute(fibonacciDataContext);
var tasks = await new Compute(fibonacciDataContext).ExecuteAsync(args);
foreach (var task in tasks) Console.WriteLine($"Fibo result : {task}");

stopwatch.Stop();
Console.WriteLine($"{stopwatch.Elapsed.Seconds}s");

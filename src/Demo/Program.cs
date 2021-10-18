using System;
using System.Diagnostics;
using System.IO;
using Fibonacci;
using Microsoft.Extensions.Configuration;




var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
    .Build();


var applicationSection = configuration.GetSection("Application");
var applicationConfig = applicationSection.Get<ApplicationConfig>();

Console.WriteLine($"Application Name : {applicationConfig.Name}");
Console.WriteLine($"Application Message : {applicationConfig.Message}");

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

using var fibonacciDataContext = new FibonacciDataContext();
var compute = new Compute(fibonacciDataContext);
var tasks = await new Compute(fibonacciDataContext).ExecuteAsync(args);
foreach (var task in tasks) Console.WriteLine($"Fibo result : {task}");

stopwatch.Stop();
Console.WriteLine($"{stopwatch.Elapsed.Seconds}s");


public class ApplicationConfig
{
    public string Name { get; set; }
    public string Message { get; set; }
}
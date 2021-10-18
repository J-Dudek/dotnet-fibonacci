using System;
using System.Diagnostics;
using System.IO;
using Fibonacci;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
    .Build();


var applicationSection = configuration.GetSection("Application");
var applicationConfig = applicationSection.Get<ApplicationConfig>();

var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddFilter("Microsoft", LogLevel.Warning)
            .AddFilter("System", LogLevel.Warning)
            .AddFilter("Demo", LogLevel.Debug)
            .AddConsole();
    }
);
var logger = loggerFactory.CreateLogger("Demo.Program");
logger.LogInformation($"Application Name : {applicationConfig.Name}");
logger.LogInformation($"Application Message : {applicationConfig.Message}");

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
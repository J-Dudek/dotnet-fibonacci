using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/Fibonacci", async () => await Fibonacci.Compute.ExecuteAsync(new []{"44", "43"}));
app.MapGet("/Support",()=> "Docs is here : <a https://github.com/guillaume-chervet/course.dotnet/blob/master/documentations/dotnet6.pptx");
app.MapGet("/",()=> "Hello");

app.Run();

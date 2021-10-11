using System;
using Xunit;
using System.Threading.Tasks;
using Fibonacci;
using Microsoft.EntityFrameworkCore;

namespace Fibonacci.Tests

{
public class UnitTest1
{
    [Fact]
    private async Task Test1Local()
    {
        var builder = new DbContextOptionsBuilder<FibonacciDataContext>();
        var dataBaseName = Guid.NewGuid().ToString();
        builder.UseInMemoryDatabase(dataBaseName);
        var options = builder.Options;
        var fibonacciDataContext = new FibonacciDataContext(options);
        await fibonacciDataContext.Database.EnsureCreatedAsync();
        
        var result = await new Fibonacci.Compute(fibonacciDataContext).ExecuteAsync(new[] {"44"});
        Assert.Equal(701408733, result[0]);
    }
}
}

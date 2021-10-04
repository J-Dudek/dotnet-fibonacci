using Xunit;
using System.Threading.Tasks;
using Fibonacci;

namespace Fibonacci.Tests

{
public class UnitTest1
{
    [Fact]
    private async Task Test1Local()
    {
        var result = await Compute.ExecuteAsync(args: new[] {"44"});
        Assert.Equal(701408733, result[0]);
    }
}
}

using NetSdrClientApp.Core;
using Xunit;

namespace NetSdrClientApp.Tests;

public class SignalProcessorTests
{
    [Fact]
    public void Normalize_Empty_ReturnsEmpty()
    {
        var p = new SignalProcessor();
        var result = p.Normalize(Array.Empty<double>());
        Assert.Empty(result);
    }

    [Fact]
    public void Normalize_ScalesToMinusOneToOne()
    {
        var p = new SignalProcessor();
        var input = new[] { -2.0, 0.0, 2.0 };
        var result = p.Normalize(input).ToArray();

        Assert.Equal(-1.0, result[0], 5);
        Assert.Equal(0.0, result[1], 5);
        Assert.Equal(1.0, result[2], 5);
    }

    [Fact]
    public void GetAverage_Works()
    {
        var p = new SignalProcessor();
        var avg = p.GetAverage(new[] { 1.0, 2.0, 3.0 });
        Assert.Equal(2.0, avg, 5);
    }
}

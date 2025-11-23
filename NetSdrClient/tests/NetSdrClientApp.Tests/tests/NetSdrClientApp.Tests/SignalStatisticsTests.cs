using NetSdrClientApp.Core;
using Xunit;

namespace NetSdrClientApp.Tests;

public class SignalStatisticsTests
{
    [Fact]
    public void DefaultValues_AreZero()
    {
        var stats = new SignalStatistics();
        Assert.Equal(0, stats.TotalOperations);
        Assert.Equal(0, stats.LastLength);
    }

    [Fact]
    public void UpdateStatistics_ChangesValues()
    {
        var processor = new SignalProcessor();
        processor.Normalize(new[] { 1.0, 2.0, 3.0 });

        Assert.Equal(1, processor.Statistics.TotalOperations);
        Assert.Equal(3, processor.Statistics.LastLength);
    }

    [Fact]
    public void Normalize_ZeroVector_ReturnsZeros()
    {
        var p = new SignalProcessor();
        var result = p.Normalize(new double[] { 0, 0, 0 });

        Assert.All(result, v => Assert.Equal(0, v));
    }

    [Fact]
    public void Normalize_NegativeAndPositiveValues_NormalizesCorrectly()
    {
        var p = new SignalProcessor();
        var result = p.Normalize(new[] { -3.0, 6.0 }).ToArray();

        Assert.Equal(-0.5, result[0], 5);
        Assert.Equal(1.0, result[1], 5);
    }

    [Fact]
    public void GetAverage_EmptyInput_ReturnsZero()
    {
        var p = new SignalProcessor();
        Assert.Equal(0, p.GetAverage(Array.Empty<double>()));
    }
}

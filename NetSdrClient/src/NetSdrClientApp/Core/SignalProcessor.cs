namespace NetSdrClientApp.Core;

/// <summary>
/// Very small "core" service to have something to test and measure.
/// </summary>
public class SignalProcessor
{
    public SignalStatistics Statistics { get; } = new();

    public IReadOnlyList<double> Normalize(IEnumerable<double> samples)
    {
        var list = samples.ToList();
        Statistics.LastLength = list.Count;
        Statistics.TotalOperations++;

        if (list.Count == 0)
        {
            return Array.Empty<double>();
        }

        var max = list.Select(Math.Abs).Max();
        if (Math.Abs(max) < 1e-9)
        {
            // Avoid division by zero – return zeros
            return list.Select(_ => 0.0).ToArray();
        }

        return list.Select(x => x / max).ToArray();
    }

    public double GetAverage(IEnumerable<double> samples)
    {
        var arr = samples.ToArray();
        if (arr.Length == 0)
        {
            return 0;
        }

        return arr.Average();
    }
}

public class SignalStatistics
{
    public int TotalOperations { get; set; }
    using NetSdrClientApp.Echo;
private EchoServer? _server; // violation

    public int LastLength { get; set; }
}

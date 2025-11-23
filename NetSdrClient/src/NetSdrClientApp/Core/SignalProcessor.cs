namespace NetSdrClientApp.Core;

public class SignalProcessor
{
    private const double ZeroEpsilon = 1e-9;

    public SignalStatistics Statistics { get; } = new();

    public IReadOnlyList<double> Normalize(IEnumerable<double> samples)
    {
        var sampleArray = samples as double[] ?? samples.ToArray();
        UpdateStatistics(sampleArray.Length);

        if (sampleArray.Length == 0)
            return Array.Empty<double>();

        var maxAbsValue = CalculateMaxAbs(sampleArray);
        if (Math.Abs(maxAbsValue) < ZeroEpsilon)
            return CreateZeros(sampleArray.Length);

        return NormalizeValues(sampleArray, maxAbsValue);
    }

    public double GetAverage(IEnumerable<double> samples)
    {
        var sampleArray = samples as double[] ?? samples.ToArray();
        return sampleArray.Length == 0 ? 0 : sampleArray.Average();
    }

    private void UpdateStatistics(int length)
    {
        Statistics.LastLength = length;
        Statistics.TotalOperations++;
    }

    private static double CalculateMaxAbs(double[] arr)
        => arr.Max(v => Math.Abs(v));

    private static double[] CreateZeros(int length)
        => Enumerable.Repeat(0.0, length).ToArray();

    private static double[] NormalizeValues(double[] arr, double max)
        => arr.Select(v => v / max).ToArray();
}

public class SignalStatistics
{
    public int TotalOperations { get; private set; }
    public int LastLength { get; private set; }
}

namespace NetSdrClientApp.Infrastructure;

public interface ISignalSource
{
    IReadOnlyList<double> ReadSamples(int count);
}

/// <summary>
/// Very primitive "infrastructure" implementation that just generates random values.
/// </summary>
public class ConsoleSignalSource : ISignalSource
{
    private readonly Random _random = new();

    public IReadOnlyList<double> ReadSamples(int count)
    {
        if (count <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        var data = new double[count];
        for (var i = 0; i < count; i++)
        {
            // Random value in [-1; 1]
            data[i] = _random.NextDouble() * 2 - 1;
        }

        return data;
    }
}

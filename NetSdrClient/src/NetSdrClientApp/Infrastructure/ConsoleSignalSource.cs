namespace NetSdrClientApp.Infrastructure;

public class ConsoleSignalSource
{
    private const string InputPrompt = "Enter comma-separated numbers:";
    private const string InvalidFormatMessage = "Invalid input. Expected comma-separated numbers.";

    public double[] ReadSamples()
    {
        Console.WriteLine(InputPrompt);
        var? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return Array.Empty<double>();
        }

        var parts = SplitInput(input);
        return ParseParts(parts);
    }

    private static string[] SplitInput(string input)
    {
        return input.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
    }

    private static double[] ParseParts(IEnumerable<string> parts)
    {
        var list = new List<double>();

        foreach (var part in parts)
        {
            if (!double.TryParse(part, out var value))
            {
                Console.WriteLine(InvalidFormatMessage);
                return Array.Empty<double>();
            }

            list.Add(value);
        }

        return list.ToArray();
    }
}

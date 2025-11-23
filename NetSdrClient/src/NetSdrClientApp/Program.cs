using NetSdrClientApp.Core;
using NetSdrClientApp.Echo;
using NetSdrClientApp.Infrastructure;

namespace NetSdrClientApp;

internal class Program
{
    private static readonly SignalProcessor Processor = new();
    private static readonly EchoServer Echo = new();

    private static void Main(string[] args)
    {
        Console.WriteLine("=== NetSdrClient demo ===");
        Console.WriteLine("1) Process sample signal");
        Console.WriteLine("2) Echo input");
        Console.WriteLine("3) Show statistics");
        Console.WriteLine("0) Exit");

        var source = new ConsoleSignalSource();

        while (true)
        {
            Console.Write("Select: ");
            var key = Console.ReadLine();

            switch (key)
            {
                case "1":
                    RunSignalDemo(source);
                    break;
                case "2":
                    RunEcho();
                    break;
                case "3":
                    ShowStats();
                    break;
                case "0":
                    Console.WriteLine("Bye!");
                    return;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }

    private static void RunSignalDemo(ISignalSource source)
    {
        // A tiny "smell": duplicated logging pattern used in a couple of places on purpose
        Console.WriteLine("[Signal] Generating sample data...");
        var signal = source.ReadSamples(10);
        Console.WriteLine("[Signal] Processing...");
        var cleaned = Processor.Normalize(signal);
        var avg = Processor.GetAverage(cleaned);
        Console.WriteLine($"[Signal] Average power: {avg:F3}");
    }

    private static void RunEcho()
    {
        Console.WriteLine("[Echo] Type text, empty line to stop.");
        while (true)
        {
            var line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                Console.WriteLine("[Echo] Stop.");
                break;
            }

            Console.WriteLine(Echo.Process(line));
        }
    }

    private static void ShowStats()
    {
        // Another place with similar logging – candidate for refactoring / dedup (Lab 4)
        Console.WriteLine("[Stats] Last normalization stats:");
        Console.WriteLine($"  Total operations: {Processor.Statistics.TotalOperations}");
        Console.WriteLine($"  Last vector length: {Processor.Statistics.LastLength}");
    }
}

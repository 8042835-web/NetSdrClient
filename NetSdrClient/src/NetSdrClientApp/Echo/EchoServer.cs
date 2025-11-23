namespace NetSdrClientApp.Echo;

public class EchoServer
{
    private const string NullMarker = "[null]";
    private const string EmptyMarker = "[empty]";
    private const string UpperCommand = "/upper";
    private const string RepeatCommand = "/repeat";

    private readonly Dictionary<string, Func<string, string>> _handlers;

    public EchoServer()
    {
        _handlers = new Dictionary<string, Func<string, string>>(StringComparer.OrdinalIgnoreCase)
        {
            { UpperCommand, HandleUpper },
            { RepeatCommand, HandleRepeat }
        };
    }

    public string Process(string? input)
    {
        if (input is null)
            return NullMarker;

        var trimmed = input.Trim();
        if (trimmed.Length == 0)
            return EmptyMarker;

        if (!TryParseCommand(trimmed, out var command, out var argument))
            return trimmed;

        if (_handlers.TryGetValue(command, out var handler))
            return handler(argument);

        return argument;
    }

    private static bool TryParseCommand(string input, out string command, out string argument)
    {
        if (!input.StartsWith("/"))
        {
            command = string.Empty;
            argument = input;
            return false;
        }

        var firstSpaceIndex = input.IndexOf(' ');
        if (firstSpaceIndex < 0)
        {
            command = input;
            argument = string.Empty;
            return true;
        }

        command = input[..firstSpaceIndex];
        argument = input[(firstSpaceIndex + 1)..].Trim();
        return true;
    }

    private static string HandleUpper(string argument)
        => argument.ToUpperInvariant();

    private static string HandleRepeat(string argument)
        => string.IsNullOrWhiteSpace(argument)
            ? EmptyMarker
            : $"{argument} {argument}";
}

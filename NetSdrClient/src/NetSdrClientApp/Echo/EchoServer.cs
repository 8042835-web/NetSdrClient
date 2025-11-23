namespace NetSdrClientApp.Echo;

public class EchoServer
{
    private const string NullMarker = "[null]";
    private const string EmptyMarker = "[empty]";
    private const string UpperCommand = "/upper";
    private const string RepeatCommand = "/repeat";
    
    public string Process(string? input)
    {
        if (input is null)
        {
            return NullMarker;
        }

        var trimmed = input.Trim();
        if (trimmed.Length == 0)
        {
            return EmptyMarker;
        }

        if (!IsCommand(trimmed, out var command, out var argument))
        {
            return trimmed;
        }

        return ExecuteCommand(command, argument);
    }

    private static bool IsCommand(string input, out string command, out string argument)
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

    private static string ExecuteCommand(string command, string argument)
    {
        return command switch
        {
            UpperCommand => argument.ToUpperInvariant(),
            RepeatCommand => string.IsNullOrWhiteSpace(argument)
                ? EmptyMarker
                : $"{argument} {argument}",
            _ => argument
        };
    }
}

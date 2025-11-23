namespace NetSdrClientApp.Echo;

/// <summary>
/// Simple echo service. Has intentionally a couple of rough edges for refactoring labs.
/// </summary>
public class EchoServer
{
    public string Process(string? input)
    {
        if (input == null)
        {
            return "[null]";
        }

        input = input.Trim();

        if (input.Length == 0)
        {
            return "[empty]";
        }

        if (input.StartsWith("/upper ", StringComparison.OrdinalIgnoreCase))
        {
            var payload = input.Substring("/upper ".Length).Trim();
            return payload.ToUpperInvariant();
        }

        if (input.StartsWith("/repeat ", StringComparison.OrdinalIgnoreCase))
        {
            var payload = input.Substring("/repeat ".Length).Trim();
            return $"{payload} {payload}";
        }

        // Default behaviour: just echo back
        return input;
    }
}

using NetSdrClientApp.Echo;
using Xunit;

namespace NetSdrClientApp.Tests;

public class EchoServerExtraTests
{
    [Fact]
    public void UnknownCommand_ReturnsArgument()
    {
        var e = new EchoServer();
        var result = e.Process("/unknown test");
        Assert.Equal("test", result);
    }

    [Fact]
    public void CommandWithoutArgument_ReturnsEmptyMarker()
    {
        var e = new EchoServer();
        var result = e.Process("/repeat   ");
        Assert.Equal("[empty]", result);
    }

    [Fact]
    public void Process_TrimsInput()
    {
        var e = new EchoServer();
        var result = e.Process("   hello   ");
        Assert.Equal("hello", result);
    }
}

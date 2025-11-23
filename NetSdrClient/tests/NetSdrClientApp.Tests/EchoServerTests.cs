using NetSdrClientApp.Echo;
using Xunit;

namespace NetSdrClientApp.Tests;

public class EchoServerTests
{
    [Fact]
    public void NullInput_ReturnsMarker()
    {
        var e = new EchoServer();
        Assert.Equal("[null]", e.Process(null));
    }

    [Fact]
    public void EmptyInput_ReturnsMarker()
    {
        var e = new EchoServer();
        Assert.Equal("[empty]", e.Process("   "));
    }

    [Fact]
    public void UpperCommand_Works()
    {
        var e = new EchoServer();
        var result = e.Process("/upper hello");
        Assert.Equal("HELLO", result);
    }

    [Fact]
    public void RepeatCommand_Works()
    {
        var e = new EchoServer();
        var result = e.Process("/repeat ping");
        Assert.Equal("ping ping", result);
    }

    [Fact]
    public void DefaultEcho_ReturnsInput()
    {
        var e = new EchoServer();
        const string msg = "hello";
        Assert.Equal(msg, e.Process(msg));
    }
}

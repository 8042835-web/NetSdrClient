using NetArchTest.Rules;
using Xunit;

namespace NetSdrClient.ArchTests;

public class ArchitectureTests
{
    private const string CoreNamespace = "NetSdrClientApp.Core";
    private const string EchoNamespace = "NetSdrClientApp.Echo";
    private const string InfrastructureNamespace = "NetSdrClientApp.Infrastructure";

    [Fact]
    public void UI_ShouldNotDependOn_Infrastructure()
    {
        var result = Types
            .InNamespace(EchoNamespace)
            .ShouldNot()
            .HaveDependencyOn(InfrastructureNamespace)
            .GetResult();

        Assert.True(result.IsSuccessful, "Echo layer should not depend on Infrastructure layer");
    }

    [Fact]
    public void Core_ShouldNotDependOn_Echo()
    {
        var result = Types
            .InNamespace(CoreNamespace)
            .ShouldNot()
            .HaveDependencyOn(EchoNamespace)
            .GetResult();

        Assert.True(result.IsSuccessful, "Core should not depend on Echo");
    }

    [Fact]
    public void Infrastructure_ShouldNotDependOn_Echo()
    {
        var result = Types
            .InNamespace(InfrastructureNamespace)
            .ShouldNot()
            .HaveDependencyOn(EchoNamespace)
            .GetResult();

        Assert.True(result.IsSuccessful, "Infrastructure should not depend on Echo");
    }
}

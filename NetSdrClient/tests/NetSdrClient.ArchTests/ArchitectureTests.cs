using NetArchTest.Rules;
using Xunit;

namespace NetSdrClient.ArchTests;

/// <summary>
/// Very small sample of architectural rules for Lab 5.
/// </summary>
public class ArchitectureTests
{
    [Fact]
    public void Core_Should_Not_Depend_On_Infrastructure()
    {
        var result = Types
            .InNamespace("NetSdrClientApp.Core")
            .ShouldNot()
            .HaveDependencyOn("NetSdrClientApp.Infrastructure")
            .GetResult();

        Assert.True(result.IsSuccessful, result.GetFailingTypes());
    }
}

internal static class RuleResultExtensions
{
    public static string GetFailingTypes(this TestResult result)
        => string.Join(", ", result.FailingTypeNames);
}

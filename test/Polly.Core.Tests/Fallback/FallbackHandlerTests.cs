using Polly.Fallback;
namespace Polly.Core.Tests.Fallback;

public class FallbackHandlerTests
{
    [Fact]
    public async Task GenerateAction_Generic_Ok()
    {
        var handler = FallbackHelper.CreateHandler(_ => true, () => Outcome.FromResult("secondary"));
        var context = ResilienceContextPool.Shared.Get();
        var outcome = await handler.GetFallbackOutcomeAsync(new OutcomeArguments<string, FallbackPredicateArguments>(context, Outcome.FromResult("primary"), default))!;

        outcome.Result.Should().Be("secondary");
    }

    [Fact]
    public async Task GenerateAction_NonGeneric_Ok()
    {
        var handler = FallbackHelper.CreateHandler(_ => true, () => Outcome.FromResult((object)"secondary"));
        var context = ResilienceContextPool.Shared.Get();
        var outcome = await handler.GetFallbackOutcomeAsync(new OutcomeArguments<string, FallbackPredicateArguments>(context, Outcome.FromResult("primary"), default))!;

        outcome.Result.Should().Be("secondary");
    }
}

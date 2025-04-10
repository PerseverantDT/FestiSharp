using System.Threading.Tasks;

using FestiSharp.Tokenization;

namespace FestiSharp.UnitTests;

internal sealed class TokenizationTests
{
    [Test]
    public async Task TestEmptyScriptTokenizationAsync()
    {
        var tokenizer = Tokenizer.CreateFromText("");

        await foreach(var token in tokenizer.TokenizeAsync()) {
            _ = token;
            Assert.Fail("An empty script should not generate any tokens.");
        }
    }

    [Test]
    public Task TestEmptyScriptTokenization()
    {
        var tokenizer = Tokenizer.CreateFromText("");

        foreach (var token in tokenizer.Tokenize()) {
            _ = token;
            Assert.Fail("An empty script should not generate any tokens.");
        }

        return Task.CompletedTask;
    }
}

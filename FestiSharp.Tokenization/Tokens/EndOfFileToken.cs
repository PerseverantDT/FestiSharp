using System.Diagnostics.CodeAnalysis;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the end-of-file of the Luau script.
/// </summary>
public class EndOfFileToken
    : Token
{
    /// <summary>
    /// Creates an instance of an end-of-file token.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public EndOfFileToken(Location location)
        : base(location)
    {
    }
}

using System.Diagnostics.CodeAnalysis;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a string literal.
/// </summary>
public class StringLiteralToken
    : Token
{
    /// <summary>
    /// The value of the literal.
    /// </summary>
    public required string Value { get; init; }

    /// <summary>
    /// Creates a new string literal token.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    /// <param name="value">The value of the token.</param>
    [SetsRequiredMembers]
    public StringLiteralToken(Location location, string value)
        : base(location)
    {
        Value = value;
    }
}

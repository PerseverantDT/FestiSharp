using System.Diagnostics.CodeAnalysis;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a numeric literal.
/// </summary>
public class NumberLiteralToken
    : Token
{
    /// <summary>
    /// The value of the numeric literal.
    /// </summary>
    public required double Value { get; init; }

    /// <summary>
    /// Creates a new numeric literal token.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    /// <param name="value">The value of the numeric token.</param>
    [SetsRequiredMembers]
    public NumberLiteralToken(Location location, double value)
        : base(location)
    {
        Value = value;
    }
}

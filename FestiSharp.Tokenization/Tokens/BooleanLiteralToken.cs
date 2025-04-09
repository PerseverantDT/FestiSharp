using System.Diagnostics.CodeAnalysis;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a boolean literal.
/// </summary>
public class BooleanLiteralToken
    : Token
{
    /// <summary>
    /// The value of the boolean literal.
    /// </summary>
    public required bool Value { get; init; }

    /// <summary>
    /// Creates a new boolean literal token.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    /// <param name="value">The value of the literal.</param>
    [SetsRequiredMembers]
    public BooleanLiteralToken(Location location, bool value)
        : base(location)
    {
        Value = value;
    }
}

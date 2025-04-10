using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a numeric literal.
/// </summary>
public class NumberLiteralToken
    : Token
    , IEquatable<NumberLiteralToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<NumberLiteralToken, NumberLiteralToken, bool>
#endif
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

    /// <summary>
    /// Checks if another numeric literal token is equal to this token.
    /// </summary>
    /// <param name="other">The token to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal, <see langword="false"/> otherwise.
    /// </returns>
    public bool Equals(NumberLiteralToken? other)
    {
        if (other is null) {
            return false;
        }

        if (ReferenceEquals(this, other)) {
            return true;
        }

        return Location == other.Location && Value.Equals(other.Value);
    }

    /// <inheritdoc/>
    public override bool Equals(Token? other)
        => Equals(other as NumberLiteralToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as NumberLiteralToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(typeof(NumberLiteralToken), Location, Value);
    
    /// <summary>
    /// Checks two numeric literal tokens for equality.
    /// </summary>
    /// <param name="left">The token at the left of the comparison.</param>
    /// <param name="right">The token at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator ==(NumberLiteralToken? left, NumberLiteralToken? right)
        => left is null ? right is null : left.Equals(right);
    
    /// <summary>
    /// Checks two numeric literal tokens for inequality.
    /// </summary>
    /// <param name="left">The token at the left of the comparison.</param>
    /// <param name="right">The token at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator !=(NumberLiteralToken? left, NumberLiteralToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

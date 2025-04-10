using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a boolean literal.
/// </summary>
public class BooleanLiteralToken
    : Token
    , IEquatable<BooleanLiteralToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<BooleanLiteralToken, BooleanLiteralToken, bool>
#endif
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

    /// <summary>
    /// Checks if another boolean literal token is equal to this token.
    /// </summary>
    /// <param name="other">The token to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal, <see langword="false"/> otherwise.
    /// </returns>
    public bool Equals(BooleanLiteralToken? other)
    {
        if (other is null) {
            return false;
        }

        if (ReferenceEquals(this, other)) {
            return true;
        }

        return Location == other.Location && Value == other.Value;
    }

    /// <inheritdoc/>
    public override bool Equals(Token? other)
        => Equals(other as BooleanLiteralToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as BooleanLiteralToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(typeof(BooleanLiteralToken), Location, Value);

    /// <summary>
    /// Checks two boolean literal tokens for equality.
    /// </summary>
    /// <param name="left">The token at the left of the comparison.</param>
    /// <param name="right">The token at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator ==(BooleanLiteralToken? left, BooleanLiteralToken? right)
        => left is null ? right is null : left.Equals(right);
    
    /// <summary>
    /// Checks two boolean literal tokens for inequality.
    /// </summary>
    /// <param name="left">The token at the left of the comparison.</param>
    /// <param name="right">The token at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator !=(BooleanLiteralToken? left, BooleanLiteralToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a string literal.
/// </summary>
public class StringLiteralToken
    : Token
    , IEquatable<StringLiteralToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<StringLiteralToken, StringLiteralToken, bool>
#endif
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

    /// <summary>
    /// Checks if another string literal token is equal to this token.
    /// </summary>
    /// <param name="other">The token to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal, <see langword="false"/> otherwise.
    /// </returns>
    public bool Equals(StringLiteralToken? other)
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
        => Equals(other as StringLiteralToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as StringLiteralToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(typeof(StringLiteralToken), Location, Value);
    
    /// <summary>
    /// Checks two string literal tokens for equality.
    /// </summary>
    /// <param name="left">The token at the left of the comparison.</param>
    /// <param name="right">The token at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator ==(StringLiteralToken? left, StringLiteralToken? right)
        => left is null ? right is null : left.Equals(right);
    
    /// <summary>
    /// Checks two string literal tokens for inequality.
    /// </summary>
    /// <param name="left">The token at the left of the comparison.</param>
    /// <param name="right">The token at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator !=(StringLiteralToken? left, StringLiteralToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a number literal.
/// </summary>`
public sealed class NumberToken
    : Token
    , IEquatable<NumberToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<NumberToken, NumberToken, bool>
#endif
{
    /// <summary>
    /// The name of the identifier.
    /// </summary>
    public required double Value { get; init; }

    /// <summary>
    /// Creates an instance of the <see cref="NumberToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public NumberToken(Location location, double value)
        : base(location)
    {
        Value = value;
    }

    /// <summary>
    /// Determines whether the specified <see cref="NumberToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="NumberToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(NumberToken? other)
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
        => Equals(other as NumberToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as NumberToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location, Value);

    /// <summary>
    /// Determines whether two <see cref="NumberToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="NumberToken"/> to compare.</param>
    /// <param name="right">The second <see cref="NumberToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(NumberToken? left, NumberToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="NumberToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="NumberToken"/> to compare.</param>
    /// <param name="right">The second <see cref="NumberToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(NumberToken? left, NumberToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

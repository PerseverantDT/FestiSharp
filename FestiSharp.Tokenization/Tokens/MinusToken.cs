using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token that represents the subtraction operator (<c>-</c>).
/// </summary>
public sealed class MinusToken
    : Token
    , IEquatable<MinusToken>
#if NET7_0_OR_GREATER
            , IEqualityOperators<MinusToken, MinusToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="MinusToken"/>.
    /// </summary>
    /// <param name="location">The location of the subtraction operator in the script.</param>
    [SetsRequiredMembers]
    public MinusToken(Location location)
        : base(location) { }

    /// <summary>
    /// Determines whether the specified <see cref="MinusToken"/> is equal to the current token.
    /// </summary>
    /// <param name="other">The other <see cref="MinusToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(MinusToken? other) {
        if (other is null) {
            return false;
        }

        if (ReferenceEquals(this, other)) {
            return true;
        }

        return Location == other.Location;
    }

    /// <inheritdoc/>
    public override bool Equals(Token? other)
        => Equals(other as MinusToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as MinusToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="MinusToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="MinusToken"/> to compare.</param>
    /// <param name="right">The second <see cref="MinusToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(MinusToken? left, MinusToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="MinusToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="MinusToken"/> to compare.</param>
    /// <param name="right">The second <see cref="MinusToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(MinusToken? left, MinusToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

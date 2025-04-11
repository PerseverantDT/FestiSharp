using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the less than operator <c>&lt;</c>.
/// </summary>
public sealed class LessThanToken
    : Token
    , IEquatable<LessThanToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<LessThanToken, LessThanToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="LessThanToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public LessThanToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="LessThanToken"/> is equal to the current token.
    /// </summary>
    /// <param name="other">The other <see cref="LessThanToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(LessThanToken? other)
    {
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
        => Equals(other as LessThanToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as LessThanToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="LessThanToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="LessThanToken"/> to compare.</param>
    /// <param name="right">The second <see cref="LessThanToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(LessThanToken? left, LessThanToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="LessThanToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="LessThanToken"/> to compare.</param>
    /// <param name="right">The second <see cref="LessThanToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(LessThanToken? left, LessThanToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

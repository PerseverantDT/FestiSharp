using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the greater than operator (<c>&gt;</c>).
/// </summary>
public sealed class GreaterThanToken
    : Token
    , IEquatable<GreaterThanToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<GreaterThanToken, GreaterThanToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="GreaterThanToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public GreaterThanToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="GreaterThanToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="GreaterThanToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(GreaterThanToken? other)
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
        => Equals(other as GreaterThanToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as GreaterThanToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="GreaterThanToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="GreaterThanToken"/> to compare.</param>
    /// <param name="right">The second <see cref="GreaterThanToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(GreaterThanToken? left, GreaterThanToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="GreaterThanToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="GreaterThanToken"/> to compare.</param>
    /// <param name="right">The second <see cref="GreaterThanToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(GreaterThanToken? left, GreaterThanToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

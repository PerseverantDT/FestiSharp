using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a double colon (<c>::</c>).
/// 
/// This is used in Luau for type casting.
/// </summary>
public sealed class DoubleColonToken
    : Token
    , IEquatable<DoubleColonToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<DoubleColonToken, DoubleColonToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="DoubleColonToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public DoubleColonToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="DoubleColonToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="DoubleColonToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(DoubleColonToken? other)
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
        => Equals(other as DoubleColonToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as DoubleColonToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="DoubleColonToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="DoubleColonToken"/> to compare.</param>
    /// <param name="right">The second <see cref="DoubleColonToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(DoubleColonToken? left, DoubleColonToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="DoubleColonToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="DoubleColonToken"/> to compare.</param>
    /// <param name="right">The second <see cref="DoubleColonToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(DoubleColonToken? left, DoubleColonToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

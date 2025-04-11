using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a hash (<c>#</c>).
/// 
/// This is used in Luau to get the length of a table's array portion.
/// </summary>
public sealed class HashToken
    : Token
    , IEquatable<HashToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<HashToken, HashToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="HashToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public HashToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="HashToken"/> is equal to the current token.
    /// </summary>
    /// <param name="other">The other <see cref="HashToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(HashToken? other)
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
        => Equals(other as HashToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as HashToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="HashToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="HashToken"/> to compare.</param>
    /// <param name="right">The second <see cref="HashToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(HashToken? left, HashToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="HashToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="HashToken"/> to compare.</param>
    /// <param name="right">The second <see cref="HashToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(HashToken? left, HashToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

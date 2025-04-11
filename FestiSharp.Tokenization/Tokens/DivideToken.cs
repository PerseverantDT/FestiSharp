using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the division operator (<c>/</c>).
/// </summary>
public sealed class DivideToken
    : Token
    , IEquatable<DivideToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<DivideToken, DivideToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="DivideToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public DivideToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="DivideToken"/> is equal to the current token.
    /// </summary>
    /// <param name="other">The other <see cref="DivideToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(DivideToken? other)
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
        => Equals(other as DivideToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as DivideToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="DivideToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="DivideToken"/> to compare.</param>
    /// <param name="right">The second <see cref="DivideToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(DivideToken? left, DivideToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="DivideToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="DivideToken"/> to compare.</param>
    /// <param name="right">The second <see cref="DivideToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(DivideToken? left, DivideToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

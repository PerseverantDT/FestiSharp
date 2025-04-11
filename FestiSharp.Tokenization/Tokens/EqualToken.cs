using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the equality operator (<c>==</c>).
/// </summary>
public sealed class EqualToken
    : Token
    , IEquatable<EqualToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<EqualToken, EqualToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="EqualToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public EqualToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="EqualToken"/> is equal to the current token.
    /// </summary>
    /// <param name="other">The other <see cref="EqualToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(EqualToken? other)
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
        => Equals(other as EqualToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as EqualToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="EqualToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="EqualToken"/> to compare.</param>
    /// <param name="right">The second <see cref="EqualToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(EqualToken? left, EqualToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="EqualToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="EqualToken"/> to compare.</param>
    /// <param name="right">The second <see cref="EqualToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(EqualToken? left, EqualToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

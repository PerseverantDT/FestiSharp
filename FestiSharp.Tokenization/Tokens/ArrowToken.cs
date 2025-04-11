using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents an arrow operator (<c>-&gt;</c>).
/// 
/// In Luau, this is used to specify the return type of a function type.
/// </summary>
public sealed class ArrowToken
    : Token
    , IEquatable<ArrowToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<ArrowToken, ArrowToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="ArrowToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public ArrowToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="ArrowToken"/> is equal to the current token.
    /// </summary>
    /// <param name="other">The other <see cref="ArrowToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(ArrowToken? other)
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
        => Equals(other as ArrowToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as ArrowToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="ArrowToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="ArrowToken"/> to compare.</param>
    /// <param name="right">The second <see cref="ArrowToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(ArrowToken? left, ArrowToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="ArrowToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="ArrowToken"/> to compare.</param>
    /// <param name="right">The second <see cref="ArrowToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(ArrowToken? left, ArrowToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

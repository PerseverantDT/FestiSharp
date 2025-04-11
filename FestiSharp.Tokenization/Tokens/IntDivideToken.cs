using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents an integer division operator (<c>//</c>).
/// </summary>
public sealed class IntDivideToken
    : Token
    , IEquatable<IntDivideToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<IntDivideToken, IntDivideToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="IntDivideToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public IntDivideToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="IntDivideToken"/> is equal to the current token.
    /// </summary>
    /// <param name="other">The other <see cref="IntDivideToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(IntDivideToken? other)
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
        => Equals(other as IntDivideToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as IntDivideToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="IntDivideToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="IntDivideToken"/> to compare.</param>
    /// <param name="right">The second <see cref="IntDivideToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(IntDivideToken? left, IntDivideToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="IntDivideToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="IntDivideToken"/> to compare.</param>
    /// <param name="right">The second <see cref="IntDivideToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(IntDivideToken? left, IntDivideToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

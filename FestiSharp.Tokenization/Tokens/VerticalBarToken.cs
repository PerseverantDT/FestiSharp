using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the vertical bar operator (<c>|</c>).
///
/// This is used in Luau to specify type unions. A variable whose type is a union of two or more
/// types can have a value of either one of the types.
/// </summary>
public sealed class VerticalBarToken
    : Token
    , IEquatable<VerticalBarToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<VerticalBarToken, VerticalBarToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="VerticalBarToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public VerticalBarToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="VerticalBarToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="VerticalBarToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(VerticalBarToken? other)
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
        => Equals(other as VerticalBarToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as VerticalBarToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="VerticalBarToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="VerticalBarToken"/> to compare.</param>
    /// <param name="right">The second <see cref="VerticalBarToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(VerticalBarToken? left, VerticalBarToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="VerticalBarToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="VerticalBarToken"/> to compare.</param>
    /// <param name="right">The second <see cref="VerticalBarToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(VerticalBarToken? left, VerticalBarToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

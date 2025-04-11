using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the subtraction assignment operator (<c>-=</c>).
/// </summary>
public sealed class MinusAssignToken
    : Token
    , IEquatable<MinusAssignToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<MinusAssignToken, MinusAssignToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="MinusAssignToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public MinusAssignToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="MinusAssignToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="MinusAssignToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(MinusAssignToken? other)
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
        => Equals(other as MinusAssignToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as MinusAssignToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="MinusAssignToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="MinusAssignToken"/> to compare.</param>
    /// <param name="right">The second <see cref="MinusAssignToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(MinusAssignToken? left, MinusAssignToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="MinusAssignToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="MinusAssignToken"/> to compare.</param>
    /// <param name="right">The second <see cref="MinusAssignToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(MinusAssignToken? left, MinusAssignToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

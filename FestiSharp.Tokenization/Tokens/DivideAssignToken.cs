using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the division assignment operator (<c>/=</c>).
/// </summary>
public sealed class DivideAssignToken
    : Token
    , IEquatable<DivideAssignToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<DivideAssignToken, DivideAssignToken, bool>
#endif
{
    /// <summary>
    /// Creates a new addition operator token.
    /// </summary>
    [SetsRequiredMembers]
    public DivideAssignToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="DivideAssignToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="DivideAssignToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(DivideAssignToken? other)
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
        => Equals(other as DivideAssignToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as DivideAssignToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="DivideAssignToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="DivideAssignToken"/> to compare.</param>
    /// <param name="right">The second <see cref="DivideAssignToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(DivideAssignToken? left, DivideAssignToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="DivideAssignToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="DivideAssignToken"/> to compare.</param>
    /// <param name="right">The second <see cref="DivideAssignToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(DivideAssignToken? left, DivideAssignToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the multiplication assignment operator (<c>*=</c>).
/// </summary>
public sealed class StarAssignToken
    : Token
    , IEquatable<StarAssignToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<StarAssignToken, StarAssignToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="StarAssignToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public StarAssignToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="StarAssignToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="StarAssignToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(StarAssignToken? other)
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
        => Equals(other as StarAssignToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as StarAssignToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="StarAssignToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="StarAssignToken"/> to compare.</param>
    /// <param name="right">The second <see cref="StarAssignToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(StarAssignToken? left, StarAssignToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="StarAssignToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="StarAssignToken"/> to compare.</param>
    /// <param name="right">The second <see cref="StarAssignToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(StarAssignToken? left, StarAssignToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

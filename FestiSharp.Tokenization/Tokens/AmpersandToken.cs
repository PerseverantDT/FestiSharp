using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the ampersand character (<c>&amp;</c>).
/// 
/// This is used in Luau to represent type intersections. An intersection represents a type whose
/// values conform to both sides at the same time.
/// </summary>
public sealed class AmpersandToken
    : Token
    , IEquatable<AmpersandToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<AmpersandToken, AmpersandToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="AmpersandToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public AmpersandToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="AmpersandToken"/> is equal to the current token.
    /// </summary>
    /// <param name="other">The other <see cref="AmpersandToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(AmpersandToken? other)
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
        => Equals(other as AmpersandToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as AmpersandToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="AmpersandToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="AmpersandToken"/> to compare.</param>
    /// <param name="right">The second <see cref="AmpersandToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(AmpersandToken? left, AmpersandToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="AmpersandToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="AmpersandToken"/> to compare.</param>
    /// <param name="right">The second <see cref="AmpersandToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(AmpersandToken? left, AmpersandToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the triple dot operator (<c>...</c>).
///
/// This is used in Luau to pack variable arguments/types.
/// </summary>
public sealed class TripleDotToken
    : Token
    , IEquatable<TripleDotToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<TripleDotToken, TripleDotToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="TripleDotToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public TripleDotToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="TripleDotToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="TripleDotToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(TripleDotToken? other)
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
        => Equals(other as TripleDotToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as TripleDotToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="TripleDotToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="TripleDotToken"/> to compare.</param>
    /// <param name="right">The second <see cref="TripleDotToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(TripleDotToken? left, TripleDotToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="TripleDotToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="TripleDotToken"/> to compare.</param>
    /// <param name="right">The second <see cref="TripleDotToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(TripleDotToken? left, TripleDotToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

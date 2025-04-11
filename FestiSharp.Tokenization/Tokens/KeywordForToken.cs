using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the <c>for</c> keyword.
/// </summary>
public sealed class KeywordForToken
    : Token
    , IEquatable<KeywordForToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<KeywordForToken, KeywordForToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="KeywordForToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public KeywordForToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="KeywordForToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="KeywordForToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(KeywordForToken? other)
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
        => Equals(other as KeywordForToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as KeywordForToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="KeywordForToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordForToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordForToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(KeywordForToken? left, KeywordForToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="KeywordForToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordForToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordForToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(KeywordForToken? left, KeywordForToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

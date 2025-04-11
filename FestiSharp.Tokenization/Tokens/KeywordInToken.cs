using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the <c>in</c> keyword.
/// </summary>
public sealed class KeywordInToken
    : Token
    , IEquatable<KeywordInToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<KeywordInToken, KeywordInToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="KeywordInToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public KeywordInToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="KeywordInToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="KeywordInToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(KeywordInToken? other)
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
        => Equals(other as KeywordInToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as KeywordInToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="KeywordInToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordInToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordInToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(KeywordInToken? left, KeywordInToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="KeywordInToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordInToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordInToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(KeywordInToken? left, KeywordInToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

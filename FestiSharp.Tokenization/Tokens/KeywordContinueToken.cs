using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the <c>continue</c> keyword.
/// </summary>
public sealed class KeywordContinueToken
    : Token
    , IEquatable<KeywordContinueToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<KeywordContinueToken, KeywordContinueToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="KeywordContinueToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public KeywordContinueToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="KeywordContinueToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="KeywordContinueToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(KeywordContinueToken? other)
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
        => Equals(other as KeywordContinueToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as KeywordContinueToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="KeywordContinueToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordContinueToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordContinueToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(KeywordContinueToken? left, KeywordContinueToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="KeywordContinueToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordContinueToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordContinueToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(KeywordContinueToken? left, KeywordContinueToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

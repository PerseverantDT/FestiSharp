using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the <c>not</c> keyword.
/// </summary>
public sealed class KeywordNotToken
    : Token
    , IEquatable<KeywordNotToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<KeywordNotToken, KeywordNotToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="KeywordNotToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public KeywordNotToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="KeywordNotToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="KeywordNotToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(KeywordNotToken? other)
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
        => Equals(other as KeywordNotToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as KeywordNotToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="KeywordNotToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordNotToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordNotToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(KeywordNotToken? left, KeywordNotToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="KeywordNotToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordNotToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordNotToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(KeywordNotToken? left, KeywordNotToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

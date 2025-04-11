using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the <c>if</c> keyword.
/// </summary>
public sealed class KeywordIfToken
    : Token
    , IEquatable<KeywordIfToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<KeywordIfToken, KeywordIfToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="KeywordIfToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public KeywordIfToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="KeywordIfToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="KeywordIfToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(KeywordIfToken? other)
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
        => Equals(other as KeywordIfToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as KeywordIfToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="KeywordIfToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordIfToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordIfToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(KeywordIfToken? left, KeywordIfToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="KeywordIfToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordIfToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordIfToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(KeywordIfToken? left, KeywordIfToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

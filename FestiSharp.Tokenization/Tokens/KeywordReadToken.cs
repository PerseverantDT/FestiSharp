using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the <c>read</c> keyword.
/// </summary>
public sealed class KeywordReadToken
    : Token
    , IEquatable<KeywordReadToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<KeywordReadToken, KeywordReadToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="KeywordReadToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public KeywordReadToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="KeywordReadToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="KeywordReadToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise, 
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(KeywordReadToken? other)
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
        => Equals(other as KeywordReadToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as KeywordReadToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="KeywordReadToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordReadToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordReadToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(KeywordReadToken? left, KeywordReadToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="KeywordReadToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordReadToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordReadToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(KeywordReadToken? left, KeywordReadToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

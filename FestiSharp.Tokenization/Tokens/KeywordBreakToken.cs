using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a <c>break</c> keyword.
/// </summary>
public sealed class KeywordBreakToken
    : Token
    , IEquatable<KeywordBreakToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<KeywordBreakToken, KeywordBreakToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="KeywordBreakToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public KeywordBreakToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="KeywordBreakToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="KeywordBreakToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(KeywordBreakToken? other)
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
        => Equals(other as KeywordBreakToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as KeywordBreakToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="KeywordBreakToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordBreakToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordBreakToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(KeywordBreakToken? left, KeywordBreakToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="KeywordBreakToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordBreakToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordBreakToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(KeywordBreakToken? left, KeywordBreakToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

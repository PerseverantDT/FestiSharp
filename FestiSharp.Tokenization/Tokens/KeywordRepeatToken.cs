using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the <c>repeat</c> keyword.
/// </summary>
public sealed class KeywordRepeatToken
    : Token
    , IEquatable<KeywordRepeatToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<KeywordRepeatToken, KeywordRepeatToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="KeywordRepeatToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public KeywordRepeatToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="KeywordRepeatToken"/> is equal to the
    /// current token.
    /// </summary>
    /// <param name="other">The other <see cref="KeywordRepeatToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(KeywordRepeatToken? other)
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
        => Equals(other as KeywordRepeatToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as KeywordRepeatToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="KeywordRepeatToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordRepeatToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordRepeatToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(KeywordRepeatToken? left, KeywordRepeatToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="KeywordRepeatToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordRepeatToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordRepeatToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(KeywordRepeatToken? left, KeywordRepeatToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

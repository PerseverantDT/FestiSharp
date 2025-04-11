using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the <c>write</c> keyword.
/// </summary>
public sealed class KeywordWriteToken
    : Token
    , IEquatable<KeywordWriteToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<KeywordWriteToken, KeywordWriteToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="KeywordWriteToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public KeywordWriteToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="KeywordWriteToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="KeywordWriteToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(KeywordWriteToken? other)
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
        => Equals(other as KeywordWriteToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as KeywordWriteToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="KeywordWriteToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordWriteToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordWriteToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(KeywordWriteToken? left, KeywordWriteToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="KeywordWriteToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordWriteToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordWriteToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(KeywordWriteToken? left, KeywordWriteToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

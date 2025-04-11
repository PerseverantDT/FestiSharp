using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the <c>nil</c> keyword.
/// </summary>
public sealed class KeywordNilToken
    : Token
    , IEquatable<KeywordNilToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<KeywordNilToken, KeywordNilToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="KeywordNilToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public KeywordNilToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="KeywordNilToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="KeywordNilToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(KeywordNilToken? other)
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
        => Equals(other as KeywordNilToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as KeywordNilToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="KeywordNilToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordNilToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordNilToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(KeywordNilToken? left, KeywordNilToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="KeywordNilToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordNilToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordNilToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(KeywordNilToken? left, KeywordNilToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

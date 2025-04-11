using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the <c>or</c> keyword.
/// </summary>
public sealed class KeywordOrToken
    : Token
    , IEquatable<KeywordOrToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<KeywordOrToken, KeywordOrToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="KeywordOrToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public KeywordOrToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="KeywordOrToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="KeywordOrToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(KeywordOrToken? other)
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
        => Equals(other as KeywordOrToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as KeywordOrToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="KeywordOrToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordOrToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordOrToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(KeywordOrToken? left, KeywordOrToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="KeywordOrToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordOrToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordOrToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(KeywordOrToken? left, KeywordOrToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the <c>export</c> keyword.
/// </summary>
public sealed class KeywordExportToken
    : Token
    , IEquatable<KeywordExportToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<KeywordExportToken, KeywordExportToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="KeywordExportToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public KeywordExportToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="KeywordExportToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="KeywordExportToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(KeywordExportToken? other)
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
        => Equals(other as KeywordExportToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as KeywordExportToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="KeywordExportToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordExportToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordExportToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(KeywordExportToken? left, KeywordExportToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="KeywordExportToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="KeywordExportToken"/> to compare.</param>
    /// <param name="right">The second <see cref="KeywordExportToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(KeywordExportToken? left, KeywordExportToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

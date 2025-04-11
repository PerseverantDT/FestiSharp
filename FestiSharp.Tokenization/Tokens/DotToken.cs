using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a dot (<c>.</c>).
/// 
/// This is used in Luau to specify member access.
/// </summary>
public sealed class DotToken
    : Token
    , IEquatable<DotToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<DotToken, DotToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="DotToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public DotToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="DotToken"/> is equal to the current token.
    /// </summary>
    /// <param name="other">The other <see cref="DotToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(DotToken? other)
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
        => Equals(other as DotToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as DotToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="DotToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="DotToken"/> to compare.</param>
    /// <param name="right">The second <see cref="DotToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(DotToken? left, DotToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="DotToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="DotToken"/> to compare.</param>
    /// <param name="right">The second <see cref="DotToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(DotToken? left, DotToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

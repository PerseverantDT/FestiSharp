using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a closing brace (<c>}</c>).
/// 
/// This is used in Luau for creating tables and table types.
/// </summary>
public sealed class ClosingBraceToken
    : Token
    , IEquatable<ClosingBraceToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<ClosingBraceToken, ClosingBraceToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="ClosingBraceToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public ClosingBraceToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="ClosingBraceToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="ClosingBraceToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(ClosingBraceToken? other)
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
        => Equals(other as ClosingBraceToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as ClosingBraceToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="ClosingBraceToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="ClosingBraceToken"/> to compare.</param>
    /// <param name="right">The second <see cref="ClosingBraceToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(ClosingBraceToken? left, ClosingBraceToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="ClosingBraceToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="ClosingBraceToken"/> to compare.</param>
    /// <param name="right">The second <see cref="ClosingBraceToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(ClosingBraceToken? left, ClosingBraceToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

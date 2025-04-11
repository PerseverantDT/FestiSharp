using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a colon (<c>:</c>).
/// 
/// This is used in Luau for method calls and type annotations.
/// </summary>
public sealed class ColonToken
    : Token
    , IEquatable<ColonToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<ColonToken, ColonToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="ColonToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public ColonToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="ColonToken"/> is equal to the current token.
    /// </summary>
    /// <param name="other">The other <see cref="ColonToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(ColonToken? other)
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
        => Equals(other as ColonToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as ColonToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="ColonToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="ColonToken"/> to compare.</param>
    /// <param name="right">The second <see cref="ColonToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(ColonToken? left, ColonToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="ColonToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="ColonToken"/> to compare.</param>
    /// <param name="right">The second <see cref="ColonToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(ColonToken? left, ColonToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

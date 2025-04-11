using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents an open brace (<c>{</c>).
///
/// This is used in Luau for creating tables and table types.
/// </summary>
public sealed class OpenBraceToken
    : Token
    , IEquatable<OpenBraceToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<OpenBraceToken, OpenBraceToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="OpenBraceToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public OpenBraceToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="OpenBraceToken"/> is equal to the current token.
    /// </summary>
    /// <param name="other">The other <see cref="OpenBraceToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(OpenBraceToken? other)
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
        => Equals(other as OpenBraceToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as OpenBraceToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="OpenBraceToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="OpenBraceToken"/> to compare.</param>
    /// <param name="right">The second <see cref="OpenBraceToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(OpenBraceToken? left, OpenBraceToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="OpenBraceToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="OpenBraceToken"/> to compare.</param>
    /// <param name="right">The second <see cref="OpenBraceToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(OpenBraceToken? left, OpenBraceToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

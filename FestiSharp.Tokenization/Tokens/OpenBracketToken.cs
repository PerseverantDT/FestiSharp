using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents an open bracket (<c>[</c>).
///
/// This is used in Luau for field and table indexing.
/// </summary>
public sealed class OpenBracketToken
    : Token
    , IEquatable<OpenBracketToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<OpenBracketToken, OpenBracketToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="OpenBracketToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public OpenBracketToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="OpenBracketToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="OpenBracketToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(OpenBracketToken? other)
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
        => Equals(other as OpenBracketToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as OpenBracketToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="OpenBracketToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="OpenBracketToken"/> to compare.</param>
    /// <param name="right">The second <see cref="OpenBracketToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(OpenBracketToken? left, OpenBracketToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="OpenBracketToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="OpenBracketToken"/> to compare.</param>
    /// <param name="right">The second <see cref="OpenBracketToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(OpenBracketToken? left, OpenBracketToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

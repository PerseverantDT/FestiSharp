using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents an open parenthesis (<c>(</c>).
///
/// This is used in Luau to specify function parameters and arguments; and tuple types.
/// </summary>
public sealed class OpenParenthesisToken
    : Token
    , IEquatable<OpenParenthesisToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<OpenParenthesisToken, OpenParenthesisToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="OpenParenthesisToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public OpenParenthesisToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="OpenParenthesisToken"/> is equal to the
    /// current token.
    /// </summary>
    /// <param name="other">The other <see cref="OpenParenthesisToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(OpenParenthesisToken? other)
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
        => Equals(other as OpenParenthesisToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as OpenParenthesisToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="OpenParenthesisToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="OpenParenthesisToken"/> to compare.</param>
    /// <param name="right">The second <see cref="OpenParenthesisToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(OpenParenthesisToken? left, OpenParenthesisToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="OpenParenthesisToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="OpenParenthesisToken"/> to compare.</param>
    /// <param name="right">The second <see cref="OpenParenthesisToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(OpenParenthesisToken? left, OpenParenthesisToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

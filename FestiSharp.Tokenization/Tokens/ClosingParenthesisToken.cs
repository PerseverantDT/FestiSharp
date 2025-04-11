using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a closing parenthesis (<c>)</c>).
/// 
/// This is used in Luau to specify function parameters and arguments; and tuple types.
/// </summary>
public sealed class ClosingParenthesisToken
    : Token
    , IEquatable<ClosingParenthesisToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<ClosingParenthesisToken, ClosingParenthesisToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="ClosingParenthesisToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public ClosingParenthesisToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="ClosingParenthesisToken"/> is equal to the
    /// current token.
    /// </summary>
    /// <param name="other">The other <see cref="ClosingParenthesisToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(ClosingParenthesisToken? other)
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
        => Equals(other as ClosingParenthesisToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as ClosingParenthesisToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="ClosingParenthesisToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="ClosingParenthesisToken"/> to compare.</param>
    /// <param name="right">The second <see cref="ClosingParenthesisToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(ClosingParenthesisToken? left, ClosingParenthesisToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="ClosingParenthesisToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="ClosingParenthesisToken"/> to compare.</param>
    /// <param name="right">The second <see cref="ClosingParenthesisToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(ClosingParenthesisToken? left, ClosingParenthesisToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

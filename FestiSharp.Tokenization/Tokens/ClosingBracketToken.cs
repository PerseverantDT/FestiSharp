using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a closing bracket (<c>]</c>).
/// 
/// This is used in Luau to specify table indexing and function attributes.
/// </summary>
public sealed class ClosingBracketToken
    : Token
    , IEquatable<ClosingBracketToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<ClosingBracketToken, ClosingBracketToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="ClosingBracketToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public ClosingBracketToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="ClosingBracketToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="ClosingBracketToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(ClosingBracketToken? other)
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
        => Equals(other as ClosingBracketToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as ClosingBracketToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="ClosingBracketToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="ClosingBracketToken"/> to compare.</param>
    /// <param name="right">The second <see cref="ClosingBracketToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(ClosingBracketToken? left, ClosingBracketToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="ClosingBracketToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="ClosingBracketToken"/> to compare.</param>
    /// <param name="right">The second <see cref="ClosingBracketToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(ClosingBracketToken? left, ClosingBracketToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a comma (<c>,</c>).
/// 
/// This is used in Luau to separate function arguments and parameters, field lists, expression
/// lists, etc.
/// </summary>
public sealed class CommaToken
    : Token
    , IEquatable<CommaToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<CommaToken, CommaToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="CommaToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public CommaToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="CommaToken"/> is equal to the current token.
    /// </summary>
    /// <param name="other">The other <see cref="CommaToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(CommaToken? other)
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
        => Equals(other as CommaToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as CommaToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="CommaToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="CommaToken"/> to compare.</param>
    /// <param name="right">The second <see cref="CommaToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(CommaToken? left, CommaToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="CommaToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="CommaToken"/> to compare.</param>
    /// <param name="right">The second <see cref="CommaToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(CommaToken? left, CommaToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

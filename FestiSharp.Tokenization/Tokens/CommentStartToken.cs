using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the start of a comment (<c>--</c>).
/// </summary>
public sealed class CommentStartToken
    : Token
    , IEquatable<CommentStartToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<CommentStartToken, CommentStartToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="CommentStartToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public CommentStartToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="CommentStartToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="CommentStartToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(CommentStartToken? other)
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
        => Equals(other as CommentStartToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as CommentStartToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="CommentStartToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="CommentStartToken"/> to compare.</param>
    /// <param name="right">The second <see cref="CommentStartToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(CommentStartToken? left, CommentStartToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="CommentStartToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="CommentStartToken"/> to compare.</param>
    /// <param name="right">The second <see cref="CommentStartToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(CommentStartToken? left, CommentStartToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the contents of a comment.
/// </summary>`
public sealed class CommentToken
    : Token
    , IEquatable<CommentToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<CommentToken, CommentToken, bool>
#endif
{
    /// <summary>
    /// The contents of the comment.
    /// </summary>
    public required string Value { get; init; }

    /// <summary>
    /// Creates an instance of the <see cref="CommentToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public CommentToken(Location location, string value)
        : base(location)
    {
        Value = value;
    }

    /// <summary>
    /// Determines whether the specified <see cref="CommentToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="CommentToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(CommentToken? other)
    {
        if (other is null) {
            return false;
        }

        if (ReferenceEquals(this, other)) {
            return true;
        }

        return Location == other.Location && Value == other.Value;
    }

    /// <inheritdoc/>
    public override bool Equals(Token? other)
        => Equals(other as CommentToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as CommentToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location, Value);

    /// <summary>
    /// Determines whether two <see cref="CommentToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="CommentToken"/> to compare.</param>
    /// <param name="right">The second <see cref="CommentToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(CommentToken? left, CommentToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="CommentToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="CommentToken"/> to compare.</param>
    /// <param name="right">The second <see cref="CommentToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(CommentToken? left, CommentToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

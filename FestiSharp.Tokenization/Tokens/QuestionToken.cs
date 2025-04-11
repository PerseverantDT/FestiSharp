using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the question mark (<c>?</c>).
///
/// This is used in Luau to specify that a type is optional.
/// </summary>
public sealed class QuestionToken
    : Token
    , IEquatable<QuestionToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<QuestionToken, QuestionToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="QuestionToken"/>.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public QuestionToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="QuestionToken"/> is equal to the current token.
    /// </summary>
    /// <param name="other">The other <see cref="QuestionToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(QuestionToken? other)
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
        => Equals(other as QuestionToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as QuestionToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="QuestionToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="QuestionToken"/> to compare.</param>
    /// <param name="right">The second <see cref="QuestionToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(QuestionToken? left, QuestionToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="QuestionToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="QuestionToken"/> to compare.</param>
    /// <param name="right">The second <see cref="QuestionToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(QuestionToken? left, QuestionToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

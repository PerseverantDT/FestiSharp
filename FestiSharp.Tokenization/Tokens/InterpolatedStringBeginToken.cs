using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the start of an interpolated string.
/// </summary>`
public sealed class InterpolatedStringBeginToken
    : Token
    , IEquatable<InterpolatedStringBeginToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<InterpolatedStringBeginToken, InterpolatedStringBeginToken, bool>
#endif
{

    /// <summary>
    /// Creates an instance of the <see cref="InterpolatedStringBeginToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public InterpolatedStringBeginToken(Location location)
        : base(location)
    {
    }

    /// <summary>
    /// Determines whether the specified <see cref="InterpolatedStringBeginToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="InterpolatedStringBeginToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(InterpolatedStringBeginToken? other)
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
        => Equals(other as InterpolatedStringBeginToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as InterpolatedStringBeginToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="InterpolatedStringBeginToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="InterpolatedStringBeginToken"/> to compare.</param>
    /// <param name="right">The second <see cref="InterpolatedStringBeginToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(InterpolatedStringBeginToken? left, InterpolatedStringBeginToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="InterpolatedStringBeginToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="InterpolatedStringBeginToken"/> to compare.</param>
    /// <param name="right">The second <see cref="InterpolatedStringBeginToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(InterpolatedStringBeginToken? left, InterpolatedStringBeginToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

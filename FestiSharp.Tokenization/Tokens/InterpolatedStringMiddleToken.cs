using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the middle of an interpolated string.
/// </summary>`
public sealed class InterpolatedStringMiddleToken
    : Token
    , IEquatable<InterpolatedStringMiddleToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<InterpolatedStringMiddleToken, InterpolatedStringMiddleToken, bool>
#endif
{
    /// <summary>
    /// The name of the identifier.
    /// </summary>
    public required string Value { get; init; }

    /// <summary>
    /// Creates an instance of the <see cref="InterpolatedStringMiddleToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public InterpolatedStringMiddleToken(Location location, string value)
        : base(location)
    {
        Value = value;
    }

    /// <summary>
    /// Determines whether the specified <see cref="InterpolatedStringMiddleToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="InterpolatedStringMiddleToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(InterpolatedStringMiddleToken? other)
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
        => Equals(other as InterpolatedStringMiddleToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as InterpolatedStringMiddleToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location, Value);

    /// <summary>
    /// Determines whether two <see cref="InterpolatedStringMiddleToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="InterpolatedStringMiddleToken"/> to compare.</param>
    /// <param name="right">The second <see cref="InterpolatedStringMiddleToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(InterpolatedStringMiddleToken? left, InterpolatedStringMiddleToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="InterpolatedStringMiddleToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="InterpolatedStringMiddleToken"/> to compare.</param>
    /// <param name="right">The second <see cref="InterpolatedStringMiddleToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(InterpolatedStringMiddleToken? left, InterpolatedStringMiddleToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

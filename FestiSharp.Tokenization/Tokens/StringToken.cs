using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents a string literal
/// </summary>`
public sealed class StringToken
    : Token
    , IEquatable<StringToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<StringToken, StringToken, bool>
#endif
{
    /// <summary>
    /// The name of the identifier.
    /// </summary>
    public required string Value { get; init; }

    /// <summary>
    /// Creates an instance of the <see cref="StringToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public StringToken(Location location, string value)
        : base(location)
    {
        Value = value;
    }

    /// <summary>
    /// Determines whether the specified <see cref="StringToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="StringToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(StringToken? other)
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
        => Equals(other as StringToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as StringToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location, Value);

    /// <summary>
    /// Determines whether two <see cref="StringToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="StringToken"/> to compare.</param>
    /// <param name="right">The second <see cref="StringToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(StringToken? left, StringToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="StringToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="StringToken"/> to compare.</param>
    /// <param name="right">The second <see cref="StringToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(StringToken? left, StringToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

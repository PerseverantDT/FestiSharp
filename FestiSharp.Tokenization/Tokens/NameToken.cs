using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the name of an identifier.
/// </summary>`
public sealed class NameToken
    : Token
    , IEquatable<NameToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<NameToken, NameToken, bool>
#endif
{
    /// <summary>
    /// The name of the identifier.
    /// </summary>
    public required string Value { get; init; }

    /// <summary>
    /// Creates an instance of the <see cref="NameToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public NameToken(Location location, string value)
        : base(location)
    {
        Value = value;
    }

    /// <summary>
    /// Determines whether the specified <see cref="NameToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="NameToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(NameToken? other)
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
        => Equals(other as NameToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as NameToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location, Value);

    /// <summary>
    /// Determines whether two <see cref="NameToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="NameToken"/> to compare.</param>
    /// <param name="right">The second <see cref="NameToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(NameToken? left, NameToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="NameToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="NameToken"/> to compare.</param>
    /// <param name="right">The second <see cref="NameToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(NameToken? left, NameToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the exponentiation operator (<c>^</c>).
/// </summary>
public sealed class CaretToken
    : Token
    , IEquatable<CaretToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<CaretToken, CaretToken, bool>
#endif
{
    /// <summary>
    /// Creates a new exponentiation operator token.
    /// </summary>
    [SetsRequiredMembers]
    public CaretToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="CaretToken"/> is equal to the current token.
    /// </summary>
    /// <param name="other">The other <see cref="CaretToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(CaretToken? other)
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
        => Equals(other as CaretToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as CaretToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="CaretToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="CaretToken"/> to compare.</param>
    /// <param name="right">The second <see cref="CaretToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(CaretToken? left, CaretToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="CaretToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="CaretToken"/> to compare.</param>
    /// <param name="right">The second <see cref="CaretToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(CaretToken? left, CaretToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

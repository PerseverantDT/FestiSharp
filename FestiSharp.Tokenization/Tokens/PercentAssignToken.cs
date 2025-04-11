using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the addition operator.
/// </summary>
public sealed class PercentAssignToken
    : Token
    , IEquatable<PercentAssignToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<PercentAssignToken, PercentAssignToken, bool>
#endif
{
    /// <summary>
    /// Creates a new addition operator token.
    /// </summary>
    [SetsRequiredMembers]
    public PercentAssignToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="PercentAssignToken"/> is equal to the current token.
    /// </summary>
    /// <param name="other">The other <see cref="PercentAssignToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise, <see langword="false"/>.
    /// </returns>
    public bool Equals(PercentAssignToken? other)
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
        => Equals(other as PercentAssignToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as PercentAssignToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="PercentAssignToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="PercentAssignToken"/> to compare.</param>
    /// <param name="right">The second <see cref="PercentAssignToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(PercentAssignToken? left, PercentAssignToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="PercentAssignToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="PercentAssignToken"/> to compare.</param>
    /// <param name="right">The second <see cref="PercentAssignToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(PercentAssignToken? left, PercentAssignToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

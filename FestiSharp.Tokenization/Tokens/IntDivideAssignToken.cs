using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents an integer division assignment operator (<c>//=</c>).
/// </summary>
public sealed class IntDivideAssignToken
    : Token
    , IEquatable<IntDivideAssignToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<IntDivideAssignToken, IntDivideAssignToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of the <see cref="IntDivideAssignToken"/>.
    /// </summary>
    [SetsRequiredMembers]
    public IntDivideAssignToken(Location location)
        : base(location)
    {}

    /// <summary>
    /// Determines whether the specified <see cref="IntDivideAssignToken"/> is equal to the current
    /// token.
    /// </summary>
    /// <param name="other">The other <see cref="IntDivideAssignToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the specified token is equal to the current token; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool Equals(IntDivideAssignToken? other)
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
        => Equals(other as IntDivideAssignToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as IntDivideAssignToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Location);

    /// <summary>
    /// Determines whether two <see cref="IntDivideAssignToken"/> instances are equal.
    /// </summary>
    /// <param name="left">The first <see cref="IntDivideAssignToken"/> to compare.</param>
    /// <param name="right">The second <see cref="IntDivideAssignToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(IntDivideAssignToken? left, IntDivideAssignToken? right)
        => left is null ? right is null : left.Equals(right);

    /// <summary>
    /// Determines whether two <see cref="IntDivideAssignToken"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="IntDivideAssignToken"/> to compare.</param>
    /// <param name="right">The second <see cref="IntDivideAssignToken"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(IntDivideAssignToken? left, IntDivideAssignToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

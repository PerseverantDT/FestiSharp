using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization.Tokens;

/// <summary>
/// A token which represents the end-of-file of the Luau script.
/// </summary>
public class EndOfFileToken
    : Token
    , IEquatable<EndOfFileToken>
#if NET7_0_OR_GREATER
    , IEqualityOperators<EndOfFileToken, EndOfFileToken, bool>
#endif
{
    /// <summary>
    /// Creates an instance of an end-of-file token.
    /// </summary>
    /// <param name="location">The location of the token.</param>
    [SetsRequiredMembers]
    public EndOfFileToken(Location location)
        : base(location)
    {
    }

    /// <summary>
    /// Checks if another end-of-file token is equal to this token.
    /// </summary>
    /// <param name="other">The token to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal, <see langword="false"/> otherwise.
    /// </returns>
    public bool Equals(EndOfFileToken? other)
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
        => Equals(other as EndOfFileToken);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as EndOfFileToken);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(typeof(EndOfFileToken), Location);
    
    /// <summary>
    /// Checks two end-of-file tokens for equality.
    /// </summary>
    /// <param name="left">The token at the left of the comparison.</param>
    /// <param name="right">The token at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator ==(EndOfFileToken? left, EndOfFileToken? right)
        => left is null ? right is null : left.Equals(right);
    
    /// <summary>
    /// Checks two end-of-file tokens for inequality.
    /// </summary>
    /// <param name="left">The token at the left of the comparison.</param>
    /// <param name="right">The token at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator !=(EndOfFileToken? left, EndOfFileToken? right)
        => left is null ? right is not null : !left.Equals(right);
}

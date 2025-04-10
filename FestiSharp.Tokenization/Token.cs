using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace FestiSharp.Tokenization;

/// <summary>
/// A token in a Luau script.
///
/// To determine which type of token an instance of this class represents, use pattern matching to
/// check the underlying class of the instance.
/// </summary>
public abstract class Token
    : IEquatable<Token>
#if NET7_0_OR_GREATER
    , IEqualityOperators<Token, Token, bool>
#endif
{
    /// <summary>
    /// The location where the token is located.
    /// </summary>
    public required Location Location { get; init; }

    /// <summary>
    /// Initializes an instance of a token.
    /// </summary>
    /// <param name="location">The location of the token</param>
    [SetsRequiredMembers]
    protected Token(Location location)
    {
        Location = location;
    }

    /// <summary>
    /// Checks if another token is equal to this token.
    /// </summary>
    /// <param name="other">The token to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal, <see langword="false"/> otherwise.
    /// </returns>
    public abstract bool Equals(Token? other);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as Token);
    
    /// <inheritdoc/>
    public abstract override int GetHashCode();

    /// <summary>
    /// Checks two tokens for equality.
    /// </summary>
    /// <param name="left">The token at the left of the comparison.</param>
    /// <param name="right">The token at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are equal, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator ==(Token? left, Token? right)
        => left is null ? right is null : left.Equals(right);
    
    /// <summary>
    /// Checks two tokens for inequality.
    /// </summary>
    /// <param name="left">The token at the left of the comparison.</param>
    /// <param name="right">The token at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the two tokens are not equal, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator !=(Token? left, Token? right)
        => left is null ? right is not null : !left.Equals(right);
};

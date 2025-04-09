using System.Diagnostics.CodeAnalysis;

namespace FestiSharp.Tokenization;

/// <summary>
/// A token in a Luau script.
///
/// To determine which type of token an instance of this class represents, use pattern matching to
/// check the underlying class of the instance.
/// </summary>
public abstract class Token
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
};

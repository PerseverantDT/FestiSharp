using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace FestiSharp.Tokenization;

/// <summary>
/// Represents the region where a token is located in a Luau script.
/// </summary>
[DebuggerDisplay("Location [{Start.Line}:{Start.Column} - {End.Line}:{End.Column}]")]
public readonly struct Location
    : IEquatable<Location>
    , IFormattable
#if NET6_0_OR_GREATER
    , ISpanFormattable
#if NET7_0_OR_GREATER
    , IEqualityOperators<Location, Location, bool>
#endif
#endif
{
    /// <summary>
    /// The position of the first character of the token.
    /// </summary>
    public required Position Start { get; init; }

    /// <summary>
    /// The position of the last character of the token.
    /// </summary>
    public required Position End { get; init; }

    /// <summary>
    /// Creates a new location instance.
    /// </summary>
    /// <param name="start">The start of the location.</param>
    /// <param name="end">The end of the location.</param>
    [SetsRequiredMembers]
    public Location(Position start, Position end)
    {
        Start = start;
        End = end;
    }

    /// <summary>
    /// Checks if two locations are equal. Two locations are equal if they have the same start and
    /// end positions.
    /// </summary>
    /// <param name="other">The other location to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the locations are equal, <see langword="false"/> otherwise.
    /// </returns>
    public bool Equals(Location other)
        => Start.Equals(other.Start) && End.Equals(other.End);

    /// <summary>
    /// Tries to format this location into the given destination span.
    /// </summary>
    /// <param name="destination">The destination span.</param>
    /// <param name="charsWritten">How many characters were written to the destination.</param>
    /// <param name="format">
    /// A format string to use for the line and column numbers of the positions.
    /// </param>
    /// <param name="provider">
    /// An object that supplies culture-specific formatting information.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the location was successfully formatted, <see langword="false"/>
    /// </returns>
    public bool TryFormat(
        Span<char> destination,
        out int charsWritten,
        [StringSyntax(StringSyntaxAttribute.NumericFormat)] ReadOnlySpan<char> format = default,
        IFormatProvider? provider = null)
    {
        charsWritten = 0;

        if (!nameof(Location).AsSpan().TryCopyTo(destination)) {
            return false;
        }
        charsWritten = nameof(Location).Length;

        if (!("( ").AsSpan().TryCopyTo(destination[charsWritten..])) {
            return false;
        }
        charsWritten += 2;

        if (!Start.TryFormat(destination[charsWritten..], out int startCharsWritten, format, provider)) {
            return false;
        }
        charsWritten += startCharsWritten;

        if (!" -> ".AsSpan().TryCopyTo(destination[charsWritten..])) {
            return false;
        }
        charsWritten += 4;

        if (!End.TryFormat(destination[charsWritten..], out int endCharsWritten, format, provider)) {
            return false;
        }
        charsWritten += endCharsWritten;

        if (!")".AsSpan().TryCopyTo(destination[charsWritten..])) {
            return false;
        }
        charsWritten += 1;

        return true;
    }

    /// <summary>
    /// Returns a string representation of the location.
    /// </summary>
    /// <param name="format">The format to use for the line and column numbers.</param>
    /// <param name="formatProvider">
    /// An object that supplies culture-specific formatting information.
    /// </param>
    /// <returns>The string representation of the location.</returns>
    public string ToString(
        [StringSyntax(StringSyntaxAttribute.NumericFormat)] string? format = null,
        IFormatProvider? formatProvider = null)
    {
        Span<char> buffer = stackalloc char[128];
        if (!Start.TryFormat(buffer, out int startLength, format, formatProvider)) {
            // Use fallback if span formatting fails
            return ToStringWithStringInterpolation(format, formatProvider);
        }
        if (!End.TryFormat(buffer, out int endLength, format, formatProvider)) {
            // Use fallback if span formatting fails
            return ToStringWithStringInterpolation(format, formatProvider);
        }

        return string.Create(
            startLength + endLength + nameof(Location).Length + 7,
            this,
            (destination, state) => state.TryFormat(destination, out _, format, formatProvider)
        );
    }

    private string ToStringWithStringInterpolation(
        [StringSyntax(StringSyntaxAttribute.NumericFormat)] string? format = null,
        IFormatProvider? formatProvider = null)
    {
        return $"{nameof(Location)}({Start.ToString(format, formatProvider)} -> {End.ToString(format, formatProvider)})";
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is Location other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(Start, End);

    /// <summary>
    /// Checks if two locations are equal. Two locations are equal if they have the same start and
    /// end positions.
    /// </summary>
    /// <param name="left">The location at the left of the comparison.</param>
    /// <param name="right">The location at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the locations are equal, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator ==(Location left, Location right)
        => left.Equals(right);

    /// <summary>
    /// Checks if two locations are not equal. Two locations are equal if they have the same start
    /// and end positions.
    /// </summary>
    /// <param name="left">The location at the left of the comparison.</param>
    /// <param name="right">The location at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the locations are not equal, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator !=(Location left, Location right)
        => !left.Equals(right);
}

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
    /// Determines whether the specified location completely encloses another location.
    /// </summary>
    /// <param name="location">The enclosing location.</param>
    /// <param name="otherLocation">The location to check for enclosure.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="location"/> completely encloses
    /// <paramref name="otherLocation"/>; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool Encloses(Location location, Location otherLocation)
    {
        return location.Start <= otherLocation.Start && location.End >= otherLocation.End;
    }

    /// <summary>
    /// Determines whether the specified location overlaps with another location.
    /// </summary>
    /// <param name="location">The first location.</param>
    /// <param name="otherLocation">The second location.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="location"/> overlaps with
    /// <paramref name="otherLocation"/>; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool Overlaps(Location location, Location otherLocation)
    {
        return (location.Start <= otherLocation.Start && location.End >= otherLocation.Start)
            || (location.Start <= otherLocation.End && location.End >= otherLocation.End)
            || (location.Start >= otherLocation.Start && location.End <= otherLocation.End);
    }

    /// <summary>
    /// Determines whether the specified location contains a given position (exclusive end).
    /// </summary>
    /// <param name="location">The location.</param>
    /// <param name="position">The position to check.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="location"/> contains <paramref name="position"/>;
    /// otherwise, <see langword="false"/>. The end position is exclusive.
    /// </returns>
    public static bool Contains(Location location, Position position)
    {
        return location.Start <= position && position < location.End;
    }

    /// <summary>
    /// Determines whether the specified location contains a given position (inclusive end).
    /// </summary>
    /// <param name="location">The location.</param>
    /// <param name="position">The position to check.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="location"/> contains <paramref name="position"/>;
    /// otherwise, <see langword="false"/>. The end position is inclusive.
    /// </returns>
    public static bool ContainsClosed(Location location, Position position)
    {
        return location.Start <= position && position <= location.End;
    }

    /// <summary>
    /// Creates a new location that encompasses both specified locations.
    /// </summary>
    /// <param name="location">The first location.</param>
    /// <param name="otherLocation">The second location.</param>
    /// <returns>
    /// A new <see cref="Location"/> that starts at the earliest start position and ends at the
    /// latest end position of the two input locations.
    /// </returns>
    public static Location Extend(Location location, Location otherLocation)
    {
        return new Location(
            location.Start < otherLocation.Start ? location.Start : otherLocation.Start,
            location.End > otherLocation.End ? location.End : otherLocation.End
        );
    }

    /// <summary>
    /// Shifts the provided location in response to a change in script contents that occurred
    /// elsewhere.
    /// </summary>
    /// <param name="location">The location to shift.</param>
    /// <param name="start">The position where the content change starts.</param>
    /// <param name="oldEnd">
    /// The position immediately after the text that was originally present before the change.
    /// </param>
    /// <param name="newEnd">
    /// The position immediately after the text that is now present after the change.
    /// </param>
    /// <returns>A new <see cref="Location"/> representing the shifted region.</returns>
    public static Location Shift(
        Location location,
        Position start,
        Position oldEnd,
        Position newEnd)
    {
        return new Location(
            Position.Shift(location.Start, start, oldEnd, newEnd),
            Position.Shift(location.End, start, oldEnd, newEnd)
        );
    }

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

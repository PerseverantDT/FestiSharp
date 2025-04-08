using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace FestiSharp.Tokenization;

/// <summary>
/// The position of a character in a Luau script.
/// </summary>
[DebuggerDisplay("[{Line}:{Column}]")]
public readonly struct Position
    : IEquatable<Position>
    , IComparable<Position>
    , IFormattable
#if NET6_0_OR_GREATER
    , ISpanFormattable
#if NET7_0_OR_GREATER
    , IEqualityOperators<Position, Position, bool>
    , IComparisonOperators<Position, Position, bool>
#endif
#endif
{
    /// <summary>
    /// The line where the item is positioned. The top-most line represents Line 1.
    /// </summary>
    public required int Line {
        get;
        init {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfLessThan(value, 1, nameof(Line));
#else
            if (value < 1) {
                throw new ArgumentOutOfRangeException(nameof(Line), value, "Value must be at least 1.");
            }
#endif
            field = value;
        }
    }

    /// <summary>
    /// The column where the item is positioned. The left-most column represents Line 1.
    /// </summary>
    public required int Column {
        get;
        init {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfLessThan(value, 1, nameof(Column));
#else
            if (value < 1) {
                throw new ArgumentOutOfRangeException(nameof(Column), value, "Value must be at least 1.");
            }
#endif
            field = value;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Position"/> struct.
    /// </summary>
    /// <param name="line">The line where the item is positioned.</param>
    /// <param name="column">The column where the item is positioned.</param>
    [SetsRequiredMembers]
    public Position(int line, int column)
    {
        Line = line;
        Column = column;
    }

    /// <summary>
    /// Checks if a position represents the same position as this instance. Two positions are the
    /// same if they have the same line and column.
    /// </summary>
    /// <param name="other">The other position to compare.</param>
    /// <returns>
    /// <see langword="true"/> if the positions are equal, <see langword="false"/> otherwise.
    /// </returns>
    public bool Equals(Position other)
        => Line == other.Line && Column == other.Column;

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is Position other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode()
        => HashCode.Combine(Line, Column);

    /// <summary>
    /// Checks if a position is ahead or behind this position.
    /// </summary>
    /// <param name="other">The other position to compare.</param>
    /// <returns>
    /// A signed number indicating whether this position is ahead, behind, or in the same place
    /// as the other position.
    /// 
    /// <list type="table">
    ///     <listheader>
    ///         <term>Return Value</term>
    ///         <description>When the value is returned.</description>
    ///     </listheader>
    ///     <item>
    ///         <term>Positive</term>
    ///         <description>This position is ahead of the other position.</description>
    ///     </item>
    ///     <item>
    ///         <term>Negative</term>
    ///         <description>This position is behind the other position.</description>
    ///     </item>
    ///     <item>
    ///         <term>Zero</term>
    ///         <description>This position is at the same place as the other position.</description>
    ///     </item>
    /// </list>
    /// </returns>
    public int CompareTo(Position other)
    {
        int compare = Line.CompareTo(other.Line);
        if (compare != 0) {
            return compare;
        }

        return Column.CompareTo(other.Column);
    }

    /// <summary>
    /// Tries to format the position into the destination span.
    /// </summary>
    /// <param name="destination">The destination span.</param>
    /// <param name="charsWritten">How many characters were written to the destination.</param>
    /// <param name="format">A format string to use for the line and column numbers.</param>
    /// <param name="provider">
    /// An object that supplies culture-specific formatting information.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the position was successfully formatted, <see langword="false"/>
    /// otherwise.
    /// </returns>
    public bool TryFormat(
        Span<char> destination,
        out int charsWritten,
        [StringSyntax(StringSyntaxAttribute.NumericFormat)] ReadOnlySpan<char> format = default,
        IFormatProvider? provider = null)
    {
        charsWritten = 0;

        if (!nameof(Position).AsSpan().TryCopyTo(destination)) {
            return false;
        }
        charsWritten = nameof(Position).Length;

        if (!("(").AsSpan().TryCopyTo(destination[charsWritten..])) {
            return false;
        }
        charsWritten += 1;

        if (!Line.TryFormat(destination[charsWritten..], out int lineLength, format, provider)) {
            return false;
        }
        charsWritten += lineLength;

        if (!":".AsSpan().TryCopyTo(destination[charsWritten..])) {
            return false;
        }
        charsWritten += 1;

        if (!Column.TryFormat(destination[charsWritten..], out int columnLength, format, provider)) {
            return false;
        }
        charsWritten += columnLength;

        if (!")".AsSpan().TryCopyTo(destination[charsWritten..])) {
            return false;
        }
        charsWritten += 1;

        return true;
    }

    /// <summary>
    /// Returns a string representation of the position.
    /// </summary>
    /// <param name="format">The format to use for the line and column numbers.</param>
    /// <param name="formatProvider">
    /// An object that supplies culture-specific formatting information.
    /// </param>
    /// <returns>The string representation of the position.</returns>
    public string ToString(
        [StringSyntax(StringSyntaxAttribute.NumericFormat)] string? format = null,
        IFormatProvider? formatProvider = null)
    {
        // Determine how long the line and column will be when formatted.
        Span<char> buffer = stackalloc char[64]; // 64 characters should be more than enough to
                                                 // handle all possible formats.
        if (!Line.TryFormat(buffer, out int lineLength, format, formatProvider)) {
            // Use fallback if span formatting fails
            return ToStringWithStringInterpolation(format, formatProvider);
        }
        if (!Column.TryFormat(buffer, out int columnLength, format, formatProvider)) {
            // Use fallback if span formatting fails
            return ToStringWithStringInterpolation(format, formatProvider);
        }

        return string.Create(
            lineLength
            + columnLength
            + nameof(Position).Length
            + 3,
            this,
            (destination, position) => {
                position.TryFormat(destination, out _, format, formatProvider);
            }
        );
    }

    private string ToStringWithStringInterpolation(
        [StringSyntax(StringSyntaxAttribute.NumericFormat)] string? format = null,
        IFormatProvider? formatProvider = null)
    {
        return $"{nameof(Position)}({Line.ToString(format, formatProvider)}:{Column.ToString(format, formatProvider)})";
    }

    /// <summary>
    /// Checks if two positions represent the same position. Two positions are the same if they
    /// have the same line and column.
    /// </summary>
    /// <param name="left">The position at the left of the comparison.</param>
    /// <param name="right">The position at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the positions are equal, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator ==(Position left, Position right)
        => left.Equals(right);

    /// <summary>
    /// Checks if two positions do not represent the same position. Two positions are the same if
    /// they have the same line and column.
    /// </summary>
    /// <param name="left">The position at the left of the comparison.</param>
    /// <param name="right">The position at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the positions are different, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator !=(Position left, Position right)
        => !left.Equals(right);

    /// <summary>
    /// Checks if a position is behind another position.
    /// </summary>
    /// <param name="left">The position at the left of the comparison.</param>
    /// <param name="right">The position at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the left position is behind the right position,
    /// <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator <(Position left, Position right)
        => left.CompareTo(right) < 0;

    /// <summary>
    /// Checks if a position is ahead of another position.
    /// </summary>
    /// <param name="left">The position at the left of the comparison.</param>
    /// <param name="right">The position at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the left position is ahead of the right position,
    /// <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator >(Position left, Position right)
        => left.CompareTo(right) > 0;

    /// <summary>
    /// Checks if a position is behind or at the same place as another position.
    /// </summary>
    /// <param name="left">The position at the left of the comparison.</param>
    /// <param name="right">The position at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the left position is behind or at the same place as the right
    /// position, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator <=(Position left, Position right)
        => left.CompareTo(right) <= 0;

    /// <summary>
    /// Checks if a position is ahead or at the same place as another position.
    /// </summary>
    /// <param name="left">The position at the left of the comparison.</param>
    /// <param name="right">The position at the right of the comparison.</param>
    /// <returns>
    /// <see langword="true"/> if the left position is ahead or at the same place as the right
    /// position, <see langword="false"/> otherwise.
    /// </returns>
    public static bool operator >=(Position left, Position right)
        => left.CompareTo(right) >= 0;
}

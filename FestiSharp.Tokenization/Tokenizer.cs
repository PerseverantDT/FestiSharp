using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FestiSharp.Tokenization;

/// <summary>
/// This class handles the tokenization of Luau scripts into its lexemes.
/// </summary>
public sealed partial class Tokenizer
    : IDisposable
{
    private bool Disposed { get; set; }
    private TextReader ScriptReader { get; init; }

    /// <summary>
    /// Tokenizes the script passed into the tokenizer.
    /// </summary>
    /// <param name="ct">A token that can be used to cancel the operation.</param>
    public IAsyncEnumerable<Token> TokenizeAsync(CancellationToken ct = default)
    {
#if NET7_0_OR_GREATER
        ObjectDisposedException.ThrowIf(Disposed, this);
#else
        if (Disposed) {
            throw new ObjectDisposedException(nameof(Tokenizer));
        }
#endif
        throw new NotImplementedException();
    }

    /// <summary>
    /// Tokenizes the script passed into the tokenizer.
    /// </summary>
    public IEnumerable<Token> Tokenize()
    {
#if NET7_0_OR_GREATER
        ObjectDisposedException.ThrowIf(Disposed, this);
#else
        if (Disposed) {
            throw new ObjectDisposedException(nameof(Tokenizer));
        }
#endif
        throw new NotImplementedException();
    }

    private Tokenizer(TextReader scriptReader)
    {
        ScriptReader = scriptReader;
    }

    /// <summary>
    /// Creates a tokenizer from the contents of a script.
    /// </summary>
    /// <param name="scriptContents">The contents of the script to tokenize.</param>
    public static Tokenizer CreateFromText(string scriptContents)
    {
        return new Tokenizer(new StringReader(scriptContents));
    }

    private void Dispose(bool disposing)
    {
        if (Disposed) {
            return;
        }

        if (disposing) {
            ScriptReader.Dispose();
        }

        Disposed = true;
    }

    /// <inheritdoc/>
    ~Tokenizer()
    {
        Dispose(disposing: false);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}

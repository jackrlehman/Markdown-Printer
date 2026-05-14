namespace MDPrinter.Services;

/// <summary>
/// Reads markdown text from the system clipboard.
/// </summary>
public interface IMarkdownClipboardService
{
	/// <summary>
	/// Reads the current clipboard text.
	/// </summary>
	/// <param name="cancellationToken">Cancels the clipboard request.</param>
	/// <returns>The clipboard text, or <see langword="null"/> when no text is available.</returns>
	Task<string?> GetTextAsync(CancellationToken cancellationToken);
}

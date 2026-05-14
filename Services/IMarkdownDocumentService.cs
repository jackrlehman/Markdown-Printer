using MDPrinter.Models;

namespace MDPrinter.Services;

/// <summary>
/// Generates markdown and HTML export artifacts for the editor content.
/// </summary>
public interface IMarkdownDocumentService
{
	/// <summary>
	/// Saves the generated markdown and HTML files for the current document into the selected output directory.
	/// </summary>
	/// <param name="title">The document title.</param>
	/// <param name="markdown">The normalized markdown content.</param>
	/// <param name="htmlDocument">The rendered HTML document.</param>
	/// <param name="outputDirectory">The user-selected output directory.</param>
	/// <param name="signature">A signature representing the current content state.</param>
	/// <param name="cancellationToken">Cancels the export operation.</param>
	/// <returns>The generated document artifacts.</returns>
	Task<GeneratedDocument> SaveAsync(string title, string markdown, string htmlDocument, string outputDirectory, string signature, CancellationToken cancellationToken);
}

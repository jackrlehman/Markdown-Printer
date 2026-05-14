namespace MDPrinter.Models;

/// <summary>
/// Represents the generated markdown and HTML artifacts used for sharing and printing.
/// </summary>
public sealed class GeneratedDocument
{
	/// <summary>
	/// Initializes a new instance of the <see cref="GeneratedDocument"/> class.
	/// </summary>
	/// <param name="title">The document title.</param>
	/// <param name="markdownFilePath">The full path to the generated markdown file.</param>
	/// <param name="htmlFilePath">The full path to the generated HTML file.</param>
	/// <param name="htmlContent">The rendered HTML content.</param>
	/// <param name="signature">A signature used to determine whether the generated files are current.</param>
	public GeneratedDocument(string title, string markdownFilePath, string htmlFilePath, string htmlContent, string signature)
	{
		Title = title;
		MarkdownFilePath = markdownFilePath;
		HtmlFilePath = htmlFilePath;
		HtmlContent = htmlContent;
		Signature = signature;
	}

	/// <summary>
	/// Gets the document title.
	/// </summary>
	public string Title { get; }

	/// <summary>
	/// Gets the full path to the generated markdown file.
	/// </summary>
	public string MarkdownFilePath { get; }

	/// <summary>
	/// Gets the full path to the generated HTML file.
	/// </summary>
	public string HtmlFilePath { get; }

	/// <summary>
	/// Gets the rendered HTML content used for previewing and printing.
	/// </summary>
	public string HtmlContent { get; }

	/// <summary>
	/// Gets the signature used to validate that the generated artifacts still match the current content.
	/// </summary>
	public string Signature { get; }
}

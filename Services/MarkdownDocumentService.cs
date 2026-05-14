using System.Text;
using MDPrinter.Models;

namespace MDPrinter.Services;

internal sealed class MarkdownDocumentService : IMarkdownDocumentService
{
	public async Task<GeneratedDocument> SaveAsync(string title, string markdown, string htmlDocument, string outputDirectory, string signature, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();

		var safeFileStem = DocumentNameUtility.ToSafeFileStem(title);
		Directory.CreateDirectory(outputDirectory);

		var markdownFilePath = Path.Combine(outputDirectory, $"{safeFileStem}.md");
		var htmlFilePath = Path.Combine(outputDirectory, $"{safeFileStem}.html");

		await File.WriteAllTextAsync(markdownFilePath, markdown, new UTF8Encoding(false), cancellationToken);
		await File.WriteAllTextAsync(htmlFilePath, htmlDocument, new UTF8Encoding(false), cancellationToken);

		return new GeneratedDocument(title, markdownFilePath, htmlFilePath, htmlDocument, signature);
	}
}

using MDPrinter.Models;
using Microsoft.Maui.Controls;

namespace MDPrinter.Services;

/// <summary>
/// Sends rendered markdown documents to the platform print workflow.
/// </summary>
public interface IMarkdownPrinterService
{
	/// <summary>
	/// Opens the platform print workflow for the provided generated document.
	/// </summary>
	/// <param name="title">The document title.</param>
	/// <param name="htmlContent">The rendered HTML content to print.</param>
	/// <param name="previewWebView">The preview web view that is showing the rendered markdown.</param>
	/// <param name="cancellationToken">Cancels the print request.</param>
	Task PrintAsync(string title, string htmlContent, WebView previewWebView, CancellationToken cancellationToken);
}

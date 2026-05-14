using Microsoft.Maui.ApplicationModel;

namespace MDPrinter.Services;

internal sealed class MarkdownClipboardService : IMarkdownClipboardService
{
	public Task<string?> GetTextAsync(CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		return Clipboard.Default.GetTextAsync();
	}
}

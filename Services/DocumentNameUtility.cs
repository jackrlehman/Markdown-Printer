using System.Text;

namespace MDPrinter.Services;

internal static class DocumentNameUtility
{
	private const string DefaultFileStem = "markdown-note";

	public static string ToSafeFileStem(string? title)
	{
		var trimmed = string.IsNullOrWhiteSpace(title) ? DefaultFileStem : title.Trim();
		var builder = new StringBuilder(trimmed.Length);

		foreach (var character in trimmed)
		{
			if (char.IsLetterOrDigit(character))
			{
				builder.Append(char.ToLowerInvariant(character));
				continue;
			}

			if (char.IsWhiteSpace(character) || character is '-' or '_')
			{
				builder.Append('-');
			}
		}

		var normalized = builder.ToString().Trim('-');
		return string.IsNullOrWhiteSpace(normalized) ? DefaultFileStem : normalized;
	}
}

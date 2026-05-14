namespace MDPrinter.Services;

/// <summary>
/// Prompts the user to choose an output directory when saving generated files.
/// </summary>
public interface IOutputDirectoryPickerService
{
	/// <summary>
	/// Opens a folder picker and returns the selected output directory.
	/// </summary>
	/// <param name="cancellationToken">Cancels the picker request.</param>
	/// <returns>The selected directory path, or <see langword="null"/> when the user cancels the picker.</returns>
	Task<string?> PickDirectoryAsync(CancellationToken cancellationToken);
}

#if WINDOWS
using Windows.Storage.Pickers;
using WinRT.Interop;
using WinUIApplication = Microsoft.Maui.Controls.Application;
using WinUIWindow = Microsoft.UI.Xaml.Window;
#endif

namespace MDPrinter.Services;

internal sealed class OutputDirectoryPickerService : IOutputDirectoryPickerService
{
	public Task<string?> PickDirectoryAsync(CancellationToken cancellationToken)
	{
#if WINDOWS
		return PickDirectoryOnWindowsAsync(cancellationToken);
#elif MACCATALYST
		throw new PlatformNotSupportedException("Folder selection is not implemented for Mac Catalyst yet.");
#else
		throw new PlatformNotSupportedException("Folder selection is not supported on this platform.");
#endif
	}

#if WINDOWS
	private static async Task<string?> PickDirectoryOnWindowsAsync(CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();

		var mauiWindow = WinUIApplication.Current?.Windows.FirstOrDefault()
			?? throw new InvalidOperationException("An active window is required before choosing an output directory.");
		var nativeWindow = mauiWindow.Handler?.PlatformView as WinUIWindow
			?? throw new InvalidOperationException("The Windows output directory picker is not available until the main window is ready.");
		var folderPicker = new FolderPicker();
		folderPicker.FileTypeFilter.Add("*");
		InitializeWithWindow.Initialize(folderPicker, WindowNative.GetWindowHandle(nativeWindow));

		var selectedFolder = await folderPicker.PickSingleFolderAsync();
		return selectedFolder?.Path;
	}
#endif
}

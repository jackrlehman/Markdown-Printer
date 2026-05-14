using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using MDPrinter.Services;
using MDPrinter.ViewModels;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
#endif

namespace MDPrinter;

/// <summary>
/// Configures the MAUI host, dependency injection container, and application services.
/// </summary>
public static class MauiProgram
{
	/// <summary>
	/// Creates the configured MAUI application instance.
	/// </summary>
	/// <returns>The built MAUI application.</returns>
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		EditorHandler.Mapper.AppendToMapping("RedEditorFocus", (handler, view) =>
		{
#if WINDOWS
			if (handler.PlatformView is TextBox textBox)
			{
				var accentBrush = new Microsoft.UI.Xaml.Media.SolidColorBrush(ColorHelper.FromArgb(0xFF, 0xB9, 0x1C, 0x1C));
				var borderBrush = new Microsoft.UI.Xaml.Media.SolidColorBrush(ColorHelper.FromArgb(0xFF, 0x99, 0x1B, 0x1B));

				textBox.BorderBrush = borderBrush;
				textBox.Resources["TextControlBorderBrush"] = borderBrush;
				textBox.Resources["TextControlBorderBrushPointerOver"] = borderBrush;
				textBox.Resources["TextControlBorderBrushFocused"] = accentBrush;
				textBox.Resources["TextControlBorderBrushPointerOverFocused"] = accentBrush;
				textBox.Resources["SystemControlHighlightAccentBrush"] = accentBrush;
			}
#endif
		});

		builder.Services.AddSingleton<IMarkdownFormatterService, MarkdownFormatterService>();
		builder.Services.AddSingleton<IMarkdownDocumentService, MarkdownDocumentService>();
		builder.Services.AddSingleton<IMarkdownClipboardService, MarkdownClipboardService>();
		builder.Services.AddSingleton<IOutputDirectoryPickerService, OutputDirectoryPickerService>();
		builder.Services.AddSingleton<IMarkdownPrinterService, MarkdownPrinterService>();
		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddSingleton<MainPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

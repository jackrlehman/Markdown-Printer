using MDPrinter.ViewModels;

namespace MDPrinter;

/// <summary>
/// Provides the markdown editing, preview, export, share, and print user interface.
/// </summary>
public partial class MainPage : ContentPage
{
	private readonly MainPageViewModel viewModel;

	/// <summary>
	/// Initializes the main page with its view model.
	/// </summary>
	/// <param name="viewModel">The view model that powers the page.</param>
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;
		BindingContext = viewModel;
	}

	private async void OnPrintClicked(object? sender, EventArgs e)
	{
		await viewModel.PrintFromPreviewAsync(ExpandedPreviewWebView);
	}

	private async void OnPrintIconTapped(object? sender, TappedEventArgs e)
	{
		await viewModel.PrintFromPreviewAsync(ExpandedPreviewWebView);
	}
}

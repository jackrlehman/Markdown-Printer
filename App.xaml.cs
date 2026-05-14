namespace MDPrinter;

/// <summary>
/// Hosts the Markdown Printer application lifecycle.
/// </summary>
public partial class App : Application
{
	private const string ApplicationWindowTitle = "Markdown Printer";
	private readonly MainPage mainPage;

	/// <summary>
	/// Initializes the application with the main page resolved from dependency injection.
	/// </summary>
	/// <param name="mainPage">The primary page shown when the application starts.</param>
	public App(MainPage mainPage)
	{
		InitializeComponent();
		this.mainPage = mainPage;
		this.mainPage.Title = ApplicationWindowTitle;
	}

	/// <summary>
	/// Creates the main application window.
	/// </summary>
	/// <param name="activationState">The activation state provided by the host platform.</param>
	/// <returns>The configured application window.</returns>
	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(mainPage)
		{
			Title = ApplicationWindowTitle
		};
	}
}
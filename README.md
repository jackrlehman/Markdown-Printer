# Markdown Printer

Markdown Printer is a desktop-focused .NET MAUI app for turning raw markdown into a print-ready document.

Paste or type markdown on the left, review the rendered result on the right, then open the output preview to:

- save the generated files
- print the rendered document
- switch between portrait and landscape
- increase or decrease the base text size
- optionally include page numbers

## Highlights

- Desktop-only targets:
  - `net10.0-windows10.0.19041.0`
  - `net10.0-maccatalyst`
- Side-by-side raw markdown and rendered preview
- Minimal red-themed UI with icon-based actions
- Automatic markdown normalization before preview, save, and print
- Output preview overlay with layout controls
- Save exports both:
  - `.md`
  - `.html`
- Print does **not** save files first
- File names are derived from the first markdown heading when possible

## Requirements

### Windows

- .NET 10 SDK
- MAUI workload installed
- WebView2 runtime available
- Visual Studio 2022 or later with MAUI support recommended

### Mac

- .NET 10 SDK
- MAUI workload installed
- Xcode and Mac Catalyst tooling

## Getting started

1. Clone the repository.
2. Open a terminal in the project folder.
3. Restore workloads/packages if needed.
4. Build and run the app.

## Build

### Windows

```powershell
dotnet build -f net10.0-windows10.0.19041.0
```

### Mac Catalyst

```powershell
dotnet build -f net10.0-maccatalyst
```

## Run

### Windows

```powershell
dotnet build -t:Run -f net10.0-windows10.0.19041.0
```

### Mac Catalyst

```powershell
dotnet build -t:Run -f net10.0-maccatalyst
```

## How to use

### Main editor

- **Paste** icon: pulls text from the clipboard into the raw markdown pane
- **Clear** icon: clears the current markdown
- **Save** icon: opens the output preview configured for saving
- **Print** icon: opens the output preview configured for printing

### Raw markdown pane

- Paste or type markdown directly
- The editor is intended to fill the panel height before scrolling
- Markdown is normalized automatically as part of preview/export generation

### Rendered preview pane

- Shows the current rendered output as HTML
- Updates as the markdown changes

### Output preview overlay

The output preview is the full-window modal used before saving or printing.

Available options:

- **Page layout**: Portrait or Landscape
- **Base text size**: adjust with the minus and plus icons
- **Page numbers**: toggle on or off
- **Save** icon: write files to a selected folder
- **Print** icon: open the system print dialog
- **X**: close the overlay

## Save behavior

When you save:

1. Open the output preview.
2. Adjust layout, text size, and page number settings.
3. Click the save icon.
4. Choose an output folder.

The app writes:

- a normalized markdown file (`.md`)
- a rendered HTML file (`.html`)

The app does **not** silently save into app storage for normal save operations.

## Print behavior

When you print:

1. Open the output preview.
2. Adjust layout, text size, and page number settings.
3. Click the print icon.

Behavior by platform:

- **Windows**: prints from the visible WebView-based preview using the system print UI
- **Mac Catalyst**: uses native Apple print services

Printing does **not** save files first.

## Markdown behavior

The app uses Markdig plus a normalization step before rendering/exporting.

Normalization currently helps standardize:

- unordered lists
- ordered lists
- task lists
- headings
- block quotes
- fenced code blocks

This reduces malformed output from inconsistent pasted markdown.

## File naming

The output file name is generated from the first markdown heading if one exists.

Example:

```md
# Sprint Summary
```

produces a file stem based on `Sprint Summary`.

If no heading is found, the fallback name is:

```text
markdown-note
```

## Project structure

```text
MD Printer/
├── App.xaml
├── App.xaml.cs
├── MainPage.xaml
├── MainPage.xaml.cs
├── MauiProgram.cs
├── MDPrinter.csproj
├── Models/
├── Resources/
├── Services/
└── ViewModels/
```

Important files:

- `MainPage.xaml` - main UI layout and output preview overlay
- `MainPage.xaml.cs` - print event handlers for the preview WebView
- `ViewModels/MainPageViewModel.cs` - editor state, preview state, save/print commands, layout options
- `Services/MarkdownFormatterService.cs` - markdown normalization and HTML generation
- `Services/MarkdownPrinterService.cs` - platform print integration
- `Services/MarkdownDocumentService.cs` - file export logic
- `Services/OutputDirectoryPickerService.cs` - output folder selection

## Dependencies

- `CommunityToolkit.Mvvm`
- `Markdig`
- `Microsoft.Maui.Controls`
- `Microsoft.Extensions.Logging.Debug`

## Known limitations

- **Mac Catalyst folder selection is not implemented yet**. Save currently throws a platform-not-supported exception there.
- This project is currently optimized around desktop workflows.
- Printing depends on the platform print stack and available runtime support.

## Public repository notes

The project uses the neutral app identifier:

```text
com.mdprinter.app
```

The repository `.gitignore` is set up to exclude common local/build/publish artifacts such as:

- `.vs/`
- `bin/`
- `obj/`
- `*.pubxml`
- `*.azurePubxml`
- `*.publishsettings`
- `*.pfx`

## License

Add the license that matches how you want to publish the project.

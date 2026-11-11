using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Layout;
using Avalonia.Themes.Fluent;

// Start the GUI application.
AppBuilder.Configure<App>()
    .UsePlatformDetect()
    .StartWithClassicDesktopLifetime(args);

// The application: loads the visual theme and opens the main window.
class App : Application
{
    public override void Initialize() => Styles.Add(new FluentTheme());

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = new MainWindow();
        base.OnFrameworkInitializationCompleted();
    }
}

// The window with a name field, a button and the greeting text.
class MainWindow : Window
{
    public MainWindow()
    {
        Title = "Hello";
        Width = 400;
        Height = 220;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;

        var label = new TextBlock { Text = "What's your name?" };
        var nameBox = new TextBox();
        var button = new Button
        {
            Content = "Greet me",
            IsDefault = true, // pressing Enter also clicks the button
            HorizontalAlignment = HorizontalAlignment.Center,
        };
        var greeting = new TextBlock
        {
            FontSize = 18,
            HorizontalAlignment = HorizontalAlignment.Center,
        };

        button.Click += (_, _) =>
        {
            var name = nameBox.Text?.Trim();
            greeting.Text = string.IsNullOrEmpty(name)
                ? "Please type your name first."
                : $"Hello, {name}! Welcome to C#.";
        };

        Content = new StackPanel
        {
            Margin = new Thickness(20),
            Spacing = 12,
            Children = { label, nameBox, button, greeting },
        };

        Opened += (_, _) => nameBox.Focus();
    }
}

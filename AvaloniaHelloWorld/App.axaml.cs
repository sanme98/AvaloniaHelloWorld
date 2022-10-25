using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using System;
using System.Runtime.InteropServices;

namespace AvaloniaHelloWorld
{
    public partial class App : Application
    {
        // https://docs.microsoft.com/en-us/answers/questions/715081/how-to-detect-windows-dark-mode.html
        [DllImport("UXTheme.dll", SetLastError = true, EntryPoint = "#138")]
        private static extern bool ShouldSystemUseDarkMode();

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            SetWindowsTheme();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void SetWindowsTheme()
        {
            if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 18362) && ShouldSystemUseDarkMode() && Application.Current != null)
            {
                ((FluentTheme)(Application.Current.Styles[0])).Mode = FluentThemeMode.Dark;
            }
        }
    }
}
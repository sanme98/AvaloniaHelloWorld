using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaHelloWorld
{
    public partial class MainWindow : Window
    {
        int count = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCounterClick(object sender, RoutedEventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Content = $"Clicked {count} time";
            else
                CounterBtn.Content = $"Clicked {count} times";
        }

    }
}
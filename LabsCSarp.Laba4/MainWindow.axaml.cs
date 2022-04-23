using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace LabsCSharp.Laba4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void ButtonOnClick([JetBrains.Annotations.CanBeNull] object sender, RoutedEventArgs e)
        {
            var database = DataContext as DataBase;
            database?.LoadAllData();
        }
    }
}
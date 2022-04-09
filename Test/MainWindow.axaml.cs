using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Test.Models;

namespace Test
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

        private void ButtonOnClick(object? sender, RoutedEventArgs e)
        {
            var database = DataContext as DataBase;
            database?.LoadAllData();
        }
    }
}
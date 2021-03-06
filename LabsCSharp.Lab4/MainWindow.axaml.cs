using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using LabsCharp.Lab4.Entities;

namespace LabsCharp.Lab4
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

        private async void ButtonOnClick(object? sender, RoutedEventArgs e)
        {
            if (DataContext is not DataBase database)
                throw new Exception();

            var message = this.FindControl<TextBox>("MessageTextBox");
            var login = this.FindControl<TextBox>("NameTextBox").Text;

            var user = database.GetUserByLogin(login);

            if (user == null)
                throw new Exception();

            await database.Client.From<HistoryChat>().Insert(
                new HistoryChat
                {
                    Id = Guid.NewGuid(),
                    SendingTime = DateTime.Now,
                    Text = message.Text,
                    UserId = user.Id
                });

            message.Text = "";
        }
    }
}
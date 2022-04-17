﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using LabsCSharp.Laba4.Models;
using Supabase;

namespace LabsCSharp.Laba4
{
    public class DataBase : INotifyPropertyChanged
    {
        private const string Url = "https://xtmtvukbgjrzvuccrosq.supabase.co";
        private const string Key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inh0bXR2dWtiZ2pyenZ1Y2Nyb3NxIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTY0NTI4NDQ4MiwiZXhwIjoxOTYwODYwNDgyfQ.0y-GQLb59IPkXEzWjcMldTbUCwnDbXIv4OUU6ZHKsMA";

        public List<User> Users { get; set; } = new();
        public List<HistoryChat> HistoryChats { get; set; } = new();

        private Client Client { get; }

        public DataBase()
        {
            Client.InitializeAsync(Url, Key, new SupabaseOptions()
            {
                AutoConnectRealtime = true,
                ShouldInitializeRealtime = true
            });

            Client = Client.Instance;

            // И подписываемся на события изменения в базе данных
            Client.From<User>().On(Client.ChannelEventType.All, (o, args) => LoadAllData());
        }

        public async void LoadAllData()
        {
            await LoadUserData();
            await LoadHistoryChatData();
        }

        private async Task LoadUserData()
        {
            var data = await Client.From<User>().Get();
            Users = data.Models;

            OnPropertyChanged(nameof(Users));
        }

        private async Task LoadHistoryChatData()
        {
            var data = await Client.From<HistoryChat>().Get();
            HistoryChats = data.Models;

            OnPropertyChanged(nameof(HistoryChats));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Supabase;

namespace Test.Models
{
    public class DataBase : INotifyPropertyChanged
    {
        private const string Url = "url";
        private const string Key = "key";

        public List<User> Users { get; set; } = new();
        public List<HistoryChat> HistoryChats { get; set; } = new();
        public List<GeneralChatModel> GeneralModels { get; set; } = new();

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
            Client.From<User>().On(Client.ChannelEventType.All, async (o, args) => await LoadUserData());
            Client.From<HistoryChat>().On(Client.ChannelEventType.All, async (o, args) => await LoadHistoryChatData());
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

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
    }
}

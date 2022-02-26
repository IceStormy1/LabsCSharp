using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LabsCSharp.Laba4.Models;
using Supabase;
using Supabase.Realtime;
using Client = Supabase.Client;

namespace LabsCSharp.Laba4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string url = "https://xtmtvukbgjrzvuccrosq.supabase.co";
            const string key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inh0bXR2dWtiZ2pyenZ1Y2Nyb3NxIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTY0NTI4NDQ4MiwiZXhwIjoxOTYwODYwNDgyfQ.0y-GQLb59IPkXEzWjcMldTbUCwnDbXIv4OUU6ZHKsMA";

            await Client.InitializeAsync(url, key, new SupabaseOptions()
            {
                AutoConnectRealtime = true,
                ShouldInitializeRealtime = true
            });

            var client = Client.Instance;

            await client.From<HistoryChat>().On(Client.ChannelEventType.All, AllEvents);
            var data = await client.From<HistoryChat>().Get();

            Console.ReadLine();
        }

        public static void AllEvents(object sender, SocketResponseEventArgs ev)
        {
            Console.WriteLine($"[{ev.Response.Event}]:{ev.Response.Topic}:\n{ev.Response.Payload.Record}");
        }
    }
}

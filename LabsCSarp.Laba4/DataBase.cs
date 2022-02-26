using System.ComponentModel;
using System.Runtime.CompilerServices;
using LabsCSharp.Laba4.Annotations;

namespace LabsCSharp.Laba4
{
    public class DataBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

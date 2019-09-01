using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HonglornBL
{
    public abstract class NotifyPropertyChangedInformer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged<T>(out T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

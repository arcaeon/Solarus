using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Solarus.Mvvm
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private bool _isLoading;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}

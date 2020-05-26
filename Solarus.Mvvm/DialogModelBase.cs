using System;
using System.Windows.Input;

namespace Solarus.Mvvm
{
    public abstract class DialogModelBase : ViewModelBase, ICloseable
    {
        public event EventHandler CloseRequested;

        public ICommand CloseCommand
        {
            get { return new DelegateCommand(Close); }
        }

        public void Close(object o)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}

using System;
using System.Windows.Input;
using System.Windows.Media;

namespace Solarus.Mvvm
{
    public abstract class DialogModelBase : ViewModelBase, IDialogModel
    {
        public event EventHandler AcceptRequested;
        public event EventHandler CancelRequested;
        public event EventHandler CloseRequested;

        public ImageSource Icon { get; set; }

        public ICommand AcceptCommand
        {
            get { return new ActionCommand(Accept); }
        }

        public ICommand CancelCommand
        {
            get { return new ActionCommand(Cancel); }
        }

        public ICommand CloseCommand
        {
            get { return new ActionCommand(Close); }
        }

        public void Accept(object o)
        {
            OnAcceptRequested();
        }

        public void Cancel(object o)
        {
            OnCancelRequested();
        }

        public void Close(object o)
        {
            OnCloseRequested();
        }

        protected virtual void OnAcceptRequested()
        {
            AcceptRequested?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnCancelRequested()
        {
            CancelRequested?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnCloseRequested()
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}

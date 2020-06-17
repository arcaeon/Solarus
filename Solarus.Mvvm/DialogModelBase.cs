﻿using System;
using System.Windows.Input;

namespace Solarus.Mvvm
{
    public abstract class DialogModelBase : ViewModelBase, ICloseable
    {
        public event EventHandler AcceptRequested;
        public event EventHandler CancelRequested;
        public event EventHandler CloseRequested;

        public ICommand AcceptCommand
        {
            get { return new DelegateCommand(Accept); }
        }

        public ICommand CancelCommand
        {
            get { return new DelegateCommand(Cancel); }
        }

        public ICommand CloseCommand
        {
            get { return new DelegateCommand(Close); }
        }

        public void Accept(object o)
        {
            AcceptRequested?.Invoke(this, EventArgs.Empty);
        }

        public void Cancel(object o)
        {
            CancelRequested?.Invoke(this, EventArgs.Empty);
        }

        public void Close(object o)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}

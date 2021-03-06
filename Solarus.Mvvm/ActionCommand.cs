﻿using System;
using System.Windows.Input;

namespace Solarus.Mvvm
{
    public class ActionCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _predicate;

        public ActionCommand(Action<object> action)
            : this(action, null)
        {
        }

        public ActionCommand(Action<object> action, Predicate<object> predicate)
        {
            _action = action ?? throw new ArgumentException(nameof(action));
            _predicate = predicate;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _predicate == null || _predicate(parameter);
        }

        public void Execute()
        {
            Execute(null);
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

using System;

namespace Solarus.Mvvm.Utilities
{
    public class NotificationEventArgs<T> : EventArgs
    {
        public NotificationEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; protected set; }
    }
}

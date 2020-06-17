using System;

namespace Solarus.Mvvm
{
    public interface ICloseable
    {
        event EventHandler AcceptRequested;
        event EventHandler CancelRequested;
        event EventHandler CloseRequested;
    }
}

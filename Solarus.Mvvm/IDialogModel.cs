using System;

namespace Solarus.Mvvm
{
    public interface IDialogModel : ICloseable
    {
        event EventHandler AcceptRequested;
        event EventHandler CancelRequested;
    }
}

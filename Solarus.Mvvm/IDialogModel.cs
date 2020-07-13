using System;

namespace Solarus.Mvvm
{
    public interface IDialogModel : ICloseable, IViewModel
    {
        event EventHandler AcceptRequested;
        event EventHandler CancelRequested;
    }
}

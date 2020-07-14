using System;
using System.Windows.Media;

namespace Solarus.Mvvm
{
    public interface IDialogModel : ICloseable, IViewModel
    {
        event EventHandler AcceptRequested;
        event EventHandler CancelRequested;
        ImageSource Icon { get; set; }
    }
}

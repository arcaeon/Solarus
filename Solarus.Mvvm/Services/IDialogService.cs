using System.Windows;

namespace Solarus.Mvvm.Services
{
    public interface IDialogService
    {
        void Show(IDialogModel dataContext);
        void Show(IDialogModel dataContext, Style style);
        bool? ShowDialog(IDialogModel dataContext);
        bool? ShowDialog(IDialogModel dataContext, Style style);
        MessageBoxResult ShowMessageBox(MessageBoxType messageBoxType, string message);
        MessageBoxResult ShowMessageBox(MessageBoxType messageBoxType, string message, string title);
    }
}

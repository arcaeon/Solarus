using System.Windows;

namespace Solarus.Mvvm.Services
{
    public interface IDialogService
    {
        void Show(ICloseable dataContext);
        void Show(ICloseable dataContext, Style style);
        bool? ShowDialog(ICloseable dataContext);
        bool? ShowDialog(ICloseable dataContext, Style style);
        MessageBoxResult ShowMessageBox(MessageBoxType messageBoxType, string message);
        MessageBoxResult ShowMessageBox(MessageBoxType messageBoxType, string message, string title);
    }
}

using System.Windows;

namespace Solarus.Mvvm.Services
{
    public interface IDialogService
    {
        void ShowDialog(ICloseable dataContext);
        void ShowDialog(ICloseable dataContext, string title);
        MessageBoxResult ShowMessageBox(MessageBoxType messageBoxType, string message);
        MessageBoxResult ShowMessageBox(MessageBoxType messageBoxType, string message, string title);
    }
}

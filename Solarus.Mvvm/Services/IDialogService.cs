using System.Windows;

namespace Solarus.Mvvm.Services
{
    public interface IDialogService
    {
        void Show(ICloseable dataContext);
        void Show(ICloseable dataContext, string title);
        void Show(ICloseable dataContext, string title, Style style);
        void ShowDialog(ICloseable dataContext);
        void ShowDialog(ICloseable dataContext, string title);
        void ShowDialog(ICloseable dataContext, string title, Style style);
        MessageBoxResult ShowMessageBox(MessageBoxType messageBoxType, string message);
        MessageBoxResult ShowMessageBox(MessageBoxType messageBoxType, string message, string title);
    }
}

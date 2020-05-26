using Solarus.Mvvm.Controls;
using System.ComponentModel;
using System.Windows;

namespace Solarus.Mvvm.Services
{
    public sealed class DialogService : IDialogService
    {
        static DialogService() { }

        private DialogService() { }

        public static DialogService Instance { get; } = new DialogService();

        public void ShowDialog(ICloseable dataContext)
        {
            ShowDialog(dataContext, null);
        }

        public void ShowDialog(ICloseable dataContext, string title)
        {
            title ??= GetMainWindowTitle();
            var dialog = new DialogWindow
            {
                DataContext = dataContext,
                Owner = Application.Current.MainWindow,
                ShowInTaskbar = false,
                Title = title
            };

            dataContext.CloseRequested += (s, e) => dialog.Close();
            dialog.ShowDialog();
        }

        public MessageBoxResult ShowMessageBox(MessageBoxType messageBoxType, string message)
        {
            return ShowMessageBox(messageBoxType, message, null);
        }

        public MessageBoxResult ShowMessageBox(MessageBoxType messageBoxType, string message, string title)
        {
            return messageBoxType switch
            {
                MessageBoxType.Default => ShowDefault(message, title),
                MessageBoxType.Confirmation => ShowConfirmation(message, title),
                MessageBoxType.Error => ShowError(message, title),
                MessageBoxType.Information => ShowInformation(message, title),
                _ => throw new InvalidEnumArgumentException(nameof(messageBoxType), (int)messageBoxType, typeof(MessageBoxType))
            };
        }

        private static string GetMainWindowTitle()
        {
            return Application.Current.MainWindow?.Title;
        }

        private static MessageBoxResult ShowDefault(string message, string title)
        {
            title ??= GetMainWindowTitle();
            return MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.None);
        }

        private static MessageBoxResult ShowConfirmation(string message, string title)
        {
            title ??= "Confirmation";
            return MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Warning);
        }

        private static MessageBoxResult ShowError(string message, string title)
        {
            title ??= "Error";
            return MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private static MessageBoxResult ShowInformation(string message, string title)
        {
            title ??= GetMainWindowTitle();
            return MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

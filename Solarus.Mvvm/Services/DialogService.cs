using Solarus.Wpf.Controls;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace Solarus.Mvvm.Services
{
    public sealed class DialogService : IDialogService
    {
        static DialogService() { }

        private DialogService() { }

        public static DialogService Instance { get; } = new DialogService();

        public void Show(IDialogModel dataContext)
        {
            Show(dataContext, null);
        }

        public void Show(IDialogModel dataContext, Style style)
        {
            DialogWindow dialog = CreateDialog(dataContext, style, false);
            dialog.Show();
        }

        public bool? ShowDialog(IDialogModel dataContext)
        {
            return ShowDialog(dataContext, null);
        }

        public bool? ShowDialog(IDialogModel dataContext, Style style)
        {
            DialogWindow dialog = CreateDialog(dataContext, style, true);
            return dialog.ShowDialog();
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

        private static DialogWindow CreateDialog(IDialogModel dataContext, Style style, bool isModal)
        {
            var dialog = new DialogWindow
            {
                DataContext = dataContext,
                Owner = GetActiveWindow(),
                ShowInTaskbar = false
            };

            if (style != null)
            {
                dialog.Style = style;
            }

            if (isModal)
            {
                dataContext.AcceptRequested += (s, e) => dialog.DialogResult = true;
                dataContext.CancelRequested += (s, e) => dialog.DialogResult = false;
            }

            dataContext.CloseRequested += (s, e) => dialog.Close();
            return dialog;
        }

        private static Window GetActiveWindow()
        {
            return Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);
        }

        private static MessageBoxResult ShowDefault(string message, string title)
        {
            title ??= string.Empty;
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
            title ??= string.Empty;
            return MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

using System.Windows;
using Point = System.Windows.Point;

namespace Solarus.Wpf.Extensions
{
    public static class FrameworkElementExtensions
    {
        public static Rect GetAbsolutePosition(this FrameworkElement element, bool relativeToScreen = false)
        {
            Point absolutePos = element.PointToScreen(new Point(0, 0));
            if (relativeToScreen)
                return new Rect(absolutePos.X, absolutePos.Y, element.ActualWidth, element.ActualHeight);

            Point mwPos = Application.Current.MainWindow.PointToScreen(new Point(0, 0));
            absolutePos = new Point(absolutePos.X - mwPos.X, absolutePos.Y - mwPos.Y);
            return new Rect(absolutePos.X, absolutePos.Y, element.ActualWidth, element.ActualHeight);
        }
    }
}

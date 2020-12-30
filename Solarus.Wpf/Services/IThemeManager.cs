using System;
using System.Windows;

namespace Solarus.Wpf.Services
{
    public interface IThemeManager
    {
        ResourceDictionary CurrentThemeDictionary { get; }
        void SetTheme(Uri source);
    }
}

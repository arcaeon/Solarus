using System;
using System.Windows;

namespace Solarus.Mvvm.Services
{
    public interface IThemeManager
    {
        ResourceDictionary CurrentThemeDictionary { get; }
        void SetTheme(Uri source);
    }
}

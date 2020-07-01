using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Solarus.Mvvm.Services
{
    public sealed class ThemeManager : IThemeManager
    {
        static ThemeManager() { }

        private ThemeManager() { }

        public static ThemeManager Instance { get; } = new ThemeManager();

        public ResourceDictionary CurrentThemeDictionary { get; private set; }

        public void SetTheme(Uri source)
        {
            Collection<ResourceDictionary> dictionaries = Application.Current.Resources.MergedDictionaries;
            var themeDictionary = Application.LoadComponent(source) as ResourceDictionary;
            dictionaries.Add(themeDictionary);

            if (CurrentThemeDictionary != null)
            {
                dictionaries.Remove(CurrentThemeDictionary);
            }

            CurrentThemeDictionary = themeDictionary;
        }
    }
}
